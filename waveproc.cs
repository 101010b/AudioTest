using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio.Wave;
using FFTWSharp;

// Audio Wave recording and Analysis
// Uses NAudio for Audio Device Access - see http://naudio.codeplex.com/

namespace audio_test
{

    class WaveProcess
    {
        private WaveIn wi;
        private fft fftx;

        public double amp_cf; // Amplitude correction factor - fed through from the FFT
        public double pwr_cf; // Power correction factor - fed through from the FFT

        public double spl = 0.0;
        public double[] fftfreq;
        public List<String> devices;
        log_delegate log;

        public int buffers = 16;
        public process_buffer[] buffer;
        public int buf_wr;
        public int buf_rd;
        public volatile int overflow;
        
        public int overloaded = 0;
        public volatile bool killthread = false;
        public int usedev;
        public System.Threading.Thread workthread;

        public bool testtone;
        public double testtone_freq;
        public double testtone_amp;
        private double testtone_ofs;

        private fft.window_type fft_win;

        public WaveProcess(log_delegate dgt)
        {
            wi = null;
            log = dgt;
            int wid = WaveIn.DeviceCount;
            devices = new List<string>();
            for (int i = 0; i < wid; i++)
            {
                WaveInCapabilities devinf = WaveIn.GetCapabilities(i);
                devices.Add(String.Format("{0}: {1} channels", devinf.ProductName, devinf.Channels));
            }

            overflow = 0;
            buffer = new process_buffer[buffers];
            buf_wr = buf_rd = 0;
            for (int i=0;i<buffers;i++) 
                buffer[i]=new process_buffer(2400);

            fft_win = fft.window_type.hann;
            testtone = false;
            testtone_freq = 1000;
            testtone_amp = 1.0; // FS
            testtone_ofs = 0.0;
        }

        public void start(int dev)
        {
            usedev = dev;
            workthread = new System.Threading.Thread(new System.Threading.ThreadStart(record_thread));
            workthread.Start();
        }

        private void record_thread()
        {
            log("Record Thread Started");
            // set up the recorder
            wi = new WaveIn(WaveCallbackInfo.FunctionCallback());
            wi.WaveFormat = new WaveFormat(48000, 16, 2);
            wi.DeviceNumber = usedev;
            wi.DataAvailable += RecorderOnDataAvailable;
            wi.BufferMilliseconds = 50; // 50 ms = 2400 Samples at 48 kHz fs

            fftx = new fft(2400, fft_win);
            fftfreq = fftx.freq;
            amp_cf = fftx.amp_cf;
            pwr_cf = fftx.pwr_cf;

            wi.StartRecording();
            log("Recording started");
            while (!killthread)
            {
                System.Threading.Thread.Sleep(100);
            }
            wi.StopRecording();
            log("Recording stopped");
        }

        public void set_window(fft.window_type wt)
        {
            if (wt != fft_win)
            {
                fftx.setwindow(wt);
                fft_win = wt;
                amp_cf = fftx.amp_cf;
                pwr_cf = fftx.pwr_cf;
            }
        }

        private void RecorderOnDataAvailable(object sender, WaveInEventArgs waveInEventArgs)
        {
            int bnext = (buf_wr + 1) % buffers;
            int blast = (buf_wr + buffers - 1) % buffers;

            if (bnext == buf_rd)
            {
                // Overflow
                overflow++;
                return;
            }

            if (testtone)
            {
                //Test Tones instead of the audio signal - for calibration or testing
                double w = 2 * Math.PI * testtone_freq;
                double tau = 1 / testtone_freq;
                for (int i = 0; i < 2400; i++)
                {
                    double t = (double)i / 48000.0 + testtone_ofs;
                    int v = (int)Math.Floor(Math.Sin(w * t) * 32767.0 * testtone_amp + 0.5);
                    buffer[buf_wr].wavel[i] = v;
                    buffer[buf_wr].waver[i] = -v;
                    buffer[buf_wr].wave[i] = v - v;
                }
                testtone_ofs = (double)2400.0 / 48000.0 + testtone_ofs;
                testtone_ofs = testtone_ofs - Math.Floor(testtone_ofs/tau)*tau;
                // testtone_ofs = 0;
            }
            else
            {
                for (int i = 0; i < 2400; i++)
                {
                    buffer[buf_wr].wavel[i] = BitConverter.ToInt16(waveInEventArgs.Buffer, i * 4);
                    buffer[buf_wr].waver[i] = BitConverter.ToInt16(waveInEventArgs.Buffer, i * 4 + 2);
                    buffer[buf_wr].wave[i] = buffer[buf_wr].wavel[i] + buffer[buf_wr].waver[i];
                }
            }

            fftx.run(buffer[blast].wavel, buffer[buf_wr].wavel, buffer[buf_wr].fftl1,0);
            fftx.run(buffer[blast].waver, buffer[buf_wr].waver, buffer[buf_wr].fftr1,1);
            fftx.run(null, buffer[buf_wr].fft1, 2);

            fftx.run(buffer[buf_wr].wavel, buffer[buf_wr].fftl2,0);
            fftx.run(buffer[buf_wr].waver, buffer[buf_wr].fftr2,1);
            fftx.run(null, buffer[buf_wr].fft2, 2);

            buf_wr = bnext;
        }

        public void stop()
        {
            // stop recording
            killthread = true;
        }

    }


}
