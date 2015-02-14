using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using FFTWSharp;

// FFT uses FFTW - see http://www.fftw.org/index.html
// C# Wrapper based on the documentation of FFTWSharp - see https://github.com/tszalay/FFTWSharp for details

namespace audio_test
{
    class fft
    {
        public enum window_type {
            flat,
            hann,
            hamming,
            blackman };

        IntPtr pin, pout;
        int fftLength;
        double[] fout1,fout2, fin;
        IntPtr fplan;
        double[] window;
        public double[] freq;
        window_type winfunc;
        public double amp_cf;
        public double pwr_cf;

        public fft(int n, window_type wt)
        {
            fftLength = n;
            pin = fftw.malloc(n * 2 * sizeof(double));
            pout = fftw.malloc(n * 2 * sizeof(double));

            fin = new double[2 * n];
            fout1 = new double[2 * n];
            fout2 = new double[2 * n];
            window = new double[n];
            freq = new double[n / 2];

            winfunc = wt;
            makewindow();

            for (int i = 0; i < 2 * n; i++) fin[i] = 0.0;
            for (int i = 0; i < n / 2; i++) freq[i] = (double)i / (n / 2) * 48000 / 2;

            fplan = fftw.dft_r2c_1d(n, pin, pout, fftw_flags.Estimate);
        }
        
        private void makewindow()
        {
            double alpha, a0, a1, a2;

            switch (winfunc)
            {
                case window_type.hann:
                    for (int i = 0; i < fftLength; i++)
                        window[i] = 0.5 - 0.5*Math.Cos((double)i * 2 * Math.PI / (fftLength-1));
                    amp_cf = 6;
                    pwr_cf = 4.3;
                    break;
                    
                case window_type.hamming:
                    for (int i = 0; i < fftLength; i++)
                        window[i] = 0.54 -0.46*Math.Cos((double)i * 2 * Math.PI / (fftLength - 1));
                    amp_cf = 5.35;
                    pwr_cf = 4.0;
                    break;
                    
                case window_type.blackman:
                    alpha=0.16;
                    a0=(1.0-alpha)/2.0;
                    a1=0.5;
                    a2=alpha/2;
                    for (int i = 0; i < fftLength; i++)
                        window[i] = 
                                a0 
                            - a1 * Math.Cos((double)i * 2 * Math.PI / (fftLength - 1))
                            + a2 * Math.Cos((double)i * 4 * Math.PI / (fftLength - 1));
                    amp_cf = 7.54;
                    pwr_cf = 5.2;
                    break;
                    
                case window_type.flat:
                default:
                    for (int i = 0; i < fftLength; i++)
                        window[i] = 1.0;
                    amp_cf = 0;
                    pwr_cf = 0;
                    break;

            }

        }

        public void setwindow(window_type wf) {
            if (wf != winfunc)
            {
                winfunc = wf;
                makewindow();
            }
        }


        // Doing dirty trick here to save processing time:
        // Idea: This program runs an FFT on the left and one on the right channel --> FFT_left(f) and FFT_right(f)
        // Now, we want the FFT from the sum of the two time signal left(t) + right(t), so we need to calculate the 
        // sum of FFT_left and FFT_right. This must be done WITH the phase information, otherwise,it would be only a power 
        // summation.

        // This function returns |FFT_left + FFT_right|, NOT |FFT_left| + |FFT_right|
        // The Real/imaginary data from the last two runs fout1 and fout2 will be used 
        private void ret_sum_fft(double [] outp) {
            double c = fftLength * fftLength;
            double cf = 2.0 / 32767.0;

            for (int i = 0; i < fftLength / 2; i++)
            {
                double fa = fout1[2 * i] + fout2[2 * i];
                double fb = fout1[2 * i + 1] + fout2[2 * i + 1];
                outp[i] = cf * Math.Sqrt((fa * fa + fb * fb) / c);
            }
        }

        // grp can be 0 or 1 to specify the left or right channel. 
        // This has no impact on the actual output data, but only on the internally stored real- and imaginary data sets
        private void do_fft(double [] outp, int grp) {

            double c = fftLength * fftLength;
            double cf = 2.0/32767.0;

            Marshal.Copy(fin, 0, pin, fftLength * 2);
            fftwf.execute(fplan);
            if (grp == 0)
            { // Store in fout1
                Marshal.Copy(pout, fout1, 0, fftLength * 2);
                for (int i = 0; i < fftLength / 2; i++)
                    outp[i] = cf * Math.Sqrt((fout1[2 * i] * fout1[2 * i] + fout1[2 * i + 1] * fout1[2 * i + 1]) / c);
            }
            else
            { // Store in fout2
                Marshal.Copy(pout, fout2, 0, fftLength * 2);
                for (int i = 0; i < fftLength / 2; i++)
                    outp[i] = cf * Math.Sqrt((fout2[2 * i] * fout2[2 * i] + fout2[2 * i + 1] * fout2[2 * i + 1]) / c);
            }
        }

        // Output is in Voltage, not Power!
        // if grp is 0 or 1, an full fft will be run. grp decides where to store the real/imaginary data
        // if grp is 2, the function returns the sum of the previous created real/imaginary data
        public void run(double[] inp, double[] outp, int grp)
        {
            if ( (grp < 0) || (grp > 1)) { ret_sum_fft(outp); return; }
            for (int i = 0; i < fftLength; i++) 
                fin[i] = inp[i] * window[i];
            do_fft(outp,grp);
        }

        // Output is in Voltage, not Power!
        // This second way to call the fft saves some data copying time compared to the fuctuion above.
        // it takes the second half of array inp1 and the first half of inp2 as fft source
        public void run(double[] inp1, double[] inp2, double[] outp, int grp)
        {
            if ( (grp < 0) || (grp > 1)) { ret_sum_fft(outp); return; }
            for (int i = 0; i < fftLength / 2; i++)
            {
                int j = i + fftLength / 2;
                fin[i] = inp1[j] * window[i];
                fin[j] = inp2[i] * window[j];
            }
            do_fft(outp,grp);
        }

    }
}
