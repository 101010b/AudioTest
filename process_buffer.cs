using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace audio_test
{
    class process_buffer
    {
        public int len;
        public int fill;
        public double[] wavel;
        public double[] waver;
        public double[] wave;
        public double[] fftl1;
        public double[] fftl2;
        public double[] fftr1;
        public double[] fftr2;
        public double[] fft1;
        public double[] fft2;

        public process_buffer(int n)
        {
            len = n;
            wavel = new double[n];
            waver = new double[n];
            wave = new double[n];

            fftl1 = new double[n / 2];
            fftl2 = new double[n / 2];
            fftr1 = new double[n / 2];
            fftr2 = new double[n / 2];
            fft1 = new double[n / 2];
            fft2 = new double[n / 2];

            fill = 0;
        }

        public bool add(double l, double r)
        {
            if (fill >= len) return true;
            wavel[fill] = l;
            waver[fill] = r;
            wave[fill] = (l+r)/ 2;
            fill++;
            if (fill >= len)
                return true;
            return false;
        }

        public void resetFill()
        {
            fill = 0;
        }




    }
}
