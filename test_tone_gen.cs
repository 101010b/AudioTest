using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio.Wave;

// Test Tone Function generator
// Uses NAudio for Audio Device Access - see http://naudio.codeplex.com/
//
// Supported Waveforms are
//  Sine
//  Triangle
//  SawTooth
//  Rectangular (50/50 ratio)
//  white noise, full bandwidth
//
// Amplidtude is in linear unit FS - so should be <= 1.0 all the time

namespace audio_test
{

    public enum func_form
    {
        sine,
        tri,
        saw,
        rect,
        noise
    }

    public enum mod_type
    {
        off,
        AM,
        FM,
        PWM
    }

    public class func_gen_config
    {
        public bool on;             // Active?

        public double amp;          // Amplitude (1 = FullScale)
        public double freq;         // in Hz
        public func_form func;      // Function
        public double pulsewidth;   // Pulse width for rectangular wave (0..1, 0.5 = 50/50 Pulsing)

        // Frequency Sweep
        public bool fsweep;         // Run a sweep
        public double freqend;      // Sweep upper frequency in Hz
        public bool logsweep;       // sweep is logarithmic
        public double sweeptime;    // Sweeptime in s
        public bool updown;         // Triangular (up-down-up-down...) instead of saw (up-up-up)

        // Modulation
        public mod_type modulate;
        public func_form modfunc;
        public double modfreq;
        public double modamp;

        public func_gen_config()
        {
            on = true;

            amp = 1.0;
            freq = 1000.0;
            func = func_form.sine;
            pulsewidth = 0.5;
            
            fsweep = false;
            freqend = 5000.0;
            logsweep = false;
            sweeptime = 5.0;
            updown = false;

            modulate = mod_type.off;
            modfunc = func_form.sine;
            modfreq = 10.0;
            modamp = 0.5;
        }
    }


    public abstract class WaveProvider16 : IWaveProvider
    {
        private WaveFormat waveFormat;
        public WaveProvider16()
            : this(44100, 1)
        {
        }

        public WaveProvider16(int sampleRate, int channels)
        {
            SetWaveFormat(sampleRate, channels);
        }

        public void SetWaveFormat(int sr, int ch)
        {
            waveFormat = new WaveFormat(sr, 16, ch);
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            WaveBuffer waveBuffer = new WaveBuffer(buffer);
            int samplesRequired = count / 2;
            int samplesRead = Read(waveBuffer.ShortBuffer, offset / 2, samplesRequired);
            return samplesRead * 2;
        }

        public abstract int Read(short[] buffer, int offset, int sampleCount);

        public WaveFormat WaveFormat
        {
            get { return waveFormat; }
        }

    }

    public class func_gen : WaveProvider16
    {

        public volatile func_gen_config setup;

        /*
        public double amp;
        public double freq;
        public func_form func;

        public bool fsweep;
        public bool logsweep;
        public double sweeptime;
        public bool updown;
        public double freqend;
        */

        private double sweepstate;
        private bool sweepup;
        private double phi;
        private double mphi;
        private Random rg;

        public func_gen(func_gen_config fgc)
        {
            /*
            freq = 1000;
            amp = 1.0;
            func = func_form.sine;
            */
            setup = fgc;
            sweepstate = 0.0;
            sweepup = true;
            phi = 0;
            mphi = 0.0;
            rg = new Random();
        }

        double SINE(double phi)
        {
            return Math.Sin(phi*2*Math.PI);
        }

        double TRI(double phi)
        {
            return (phi < 0.5) ? (-1.0 + 4.0 * phi) : (3.0 - 4.0 * phi);
        }

        double SAW(double phi)
        {
            return -1.0 + 2.0 * phi;
        }

        double RECT(double phi,double rmod)
        {
            return (phi < rmod) ? -1.0 : 1.0;
        }

        public override int Read(short[] buffer, int offset, int sampleCount)
        {
            if (!setup.on)
            {
                for (int n = 0; n < sampleCount; n++)
                {
                    buffer[n + offset] = (short)0;
                }
                return sampleCount;
            }


            double dphi;
            double amp;
            double pulsew;

            dphi = setup.freq / 48000.0;
            
            amp=setup.amp;
            pulsew = setup.pulsewidth;

            int iamp = (int) Math.Floor(2.0 * 32767 * amp+0.5);
            int jamp = (int) Math.Floor(32767 * amp + 0.5);

  
            for (int n = 0; n < sampleCount; n++)
            {
                double modval = 0.0;
                if (setup.modulate != mod_type.off)
                {
                    mphi += setup.modfreq/48000.0;
                    if ((mphi < 0.0) || (mphi > 1.0)) mphi -= Math.Floor(mphi);
                    switch (setup.modfunc) {
                        default:
                        case func_form.sine: modval = setup.modamp * SINE(mphi);break;
                        case func_form.tri: modval = setup.modamp * TRI(mphi);break;
                        case func_form.saw: modval = setup.modamp * SAW(mphi);break;
                        case func_form.rect: modval = setup.modamp * RECT(mphi,0.5);break;
                    }
                }
                if (setup.modulate == mod_type.AM)
                    amp = setup.amp*(modval + 1.0);
                if (setup.modulate == mod_type.PWM)
                    pulsew = setup.pulsewidth + modval / 2.0;

                switch (setup.func)
                {
                    default:
                    case func_form.sine: buffer[n + offset] = (short)Math.Floor(amp * 32767.0 * SINE(phi)); break;
                    case func_form.tri: buffer[n + offset] = (short)Math.Floor(amp * 32767.0 * TRI(phi)); break;
                    case func_form.saw: buffer[n + offset] = (short)Math.Floor(amp * 32767.0 * SAW(phi)); break;
                    case func_form.rect: buffer[n + offset] = (short)Math.Floor(amp * 32767.0 * RECT(phi, pulsew)); break;
                    case func_form.noise: buffer[n + offset] = (short)(rg.Next(iamp) - jamp); break;
                }

                double f = setup.freq;
                if (setup.fsweep)
                {
                    double fmod;
                    if (!setup.updown || (setup.updown && sweepup))
                    {
                        // Upwards
                        sweepstate += 1.0 / 48000.0 / setup.sweeptime;
                        if (sweepstate > 1.0)
                        {
                            if (setup.updown)
                                sweepup = false;
                            else
                                sweepstate -= Math.Floor(sweepstate);
                        }
                    }
                    else
                    {
                        // Downwards
                        sweepstate -= 1.0 / 48000.0 / setup.sweeptime;
                        if (sweepstate < 0.0)
                        {
                            if (setup.updown)
                                sweepup = true;
                            else
                                sweepstate -= Math.Floor(sweepstate);
                        }
                    }
                    if (setup.logsweep)
                        fmod = ((Math.Exp(sweepstate) -1.0) / (Math.E - 1.0));
                    else
                        fmod = sweepstate;
                    f = (setup.freq * (1.0 - fmod) + fmod * setup.freqend);
                }
                
                if (setup.modulate == mod_type.FM) 
                    f*=(1.0+modval);
                dphi = f / 48000.0;
                phi += dphi;
                if (phi < 0.0)
                    phi += Math.Floor(phi);
                if (phi > 1.0)
                    phi -= Math.Floor(phi);
            }

            return sampleCount;
        }
    }

    class test_tone_gen
    {

        private WaveOut wo;

        public List<String> devices;

        public int overloaded = 0;
        public volatile bool killthread = false;
        public int usedev;
        public System.Threading.Thread workthread;

        public func_gen_config setup;

        /*
        public double freq;
        public double amp;
        public func_form func;
        public bool on;
        */

        log_delegate log;

        public test_tone_gen(log_delegate dgt)
        {
            log = dgt;

            setup = new func_gen_config();

            int wid = WaveOut.DeviceCount;
            devices = new List<string>();
            for (int i = 0; i < wid; i++)
            {
                WaveOutCapabilities devinf = WaveOut.GetCapabilities(i);
                devices.Add(String.Format("{0}: {1} channels", devinf.ProductName, devinf.Channels));
            }

            /*
            freq = 1000;
            amp = 1;
            on = true;
            func = func_form.sine;
            */

        }

        public void start(int dev)
        {
            usedev = dev;
            workthread = new System.Threading.Thread(new System.Threading.ThreadStart(play_thread));
            workthread.Start();
        }
        
        private void play_thread()
        {
            log("Record Thread Started");
            func_gen fg = new func_gen(setup);
            fg.SetWaveFormat(48000,1);
            wo = new WaveOut(WaveCallbackInfo.FunctionCallback());
            wo.DeviceNumber = usedev;
            wo.Init(fg);
            wo.Play();

            log("Playing started");
            while (!killthread)
            {
                System.Threading.Thread.Sleep(50);
                /*fg.freq = freq;
                fg.amp = amp;
                fg.func = func;
                fg.on = on;
                 */
            }
            wo.Stop();
            log("Playing stopped");
        }

        public void stop()
        {
            killthread = true;
        }

    }
}
