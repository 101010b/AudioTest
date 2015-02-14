using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Implements Power integration filters of different kind
// Special Notes
// Flat - just flat, as the name says ;-)
// Flat10k - Flat, but bandwidth limited to 10kHz
// A - Classic A-Weighting Filter
// A10k - Classic A with reduced bandwidth (to 10kHz)
// B, C - Classic B and C-Weighting filters
// Phone - simple A-Type filter with reduced bandwidth from 300 to 3400 Hz (kind of standard telephone line)
// HDPhone - simpla A-Type filter with reduced bandwidth from 50 to 7000 Hz (kind of HD telephony)
// The formulas for A, B and C-Type filters were taken from http://en.wikipedia.org/wiki/A-weighting

namespace audio_test
{
    public enum filter_type
    {
        Flat,
        Flat10k,
        A,
        A10k,
        B,
        C,
        Phone,
        HDPhone
    }

    class filter
    {

        public int N;
        public double[] f; // Frequency in Hz
        public double[] w; // weighting - As Voltage ratio (NOT POWER)
        filter_type type;

        public filter(int n, double fmax, filter_type ft)
        {
            N = n;
            f = new double[N];
            w = new double[N];
            type = ft;

            for (int i = 0; i < N; i++) f[i] = (double)i * fmax / N;

            build_filter();
        }

        public filter(int n, double fmax)
        {
            N = n;
            f = new double[N];
            w = new double[N];
            type = filter_type.Flat;

            for (int i = 0; i < N; i++) f[i] = (double)i * fmax / N;

            build_filter();
        }

        public static List<String> getList()
        {
            List<String> L;
            L = new List<string>();
            L.Add("Flat");
            L.Add("Flat10k");
            L.Add("A");
            L.Add("A10k");
            L.Add("B");
            L.Add("C");
            L.Add("Phone");
            L.Add("HDPhone");
            return L;
        }

        public static String getName(filter_type ft)
        {
            switch (ft)
            {
                case filter_type.Flat: return "Flat";
                case filter_type.Flat10k: return "Flat10k";
                case filter_type.A: return "A";
                case filter_type.A10k: return "A10k";
                case filter_type.B: return "B";
                case filter_type.C: return "C";
                case filter_type.Phone: return "Phone";
                case filter_type.HDPhone: return "HDPhone";
                default: return "unknown";
            }
        }

        public static filter_type getID(String s)
        {
            if (s.Equals("Flat")) return filter_type.Flat;
            if (s.Equals("Flat10k")) return filter_type.Flat10k;
            if (s.Equals("A")) return filter_type.A;
            if (s.Equals("A10k")) return filter_type.A10k;
            if (s.Equals("B")) return filter_type.B;
            if (s.Equals("C")) return filter_type.C;
            if (s.Equals("Phone")) return filter_type.Phone;
            if (s.Equals("HDPhone")) return filter_type.HDPhone;
            // Default
            return filter_type.Flat;
        }

        public static int getIndex(filter_type ft)
        {
            return (int)ft;
        }

        public static int getIndex(String s)
        {
            return (int)getID(s);
        }

        public int getIndex() {
            return (int)type;
        }

        public String get_filter_unit(String baseunit)
        {
            switch (type)
            {
                default:
                case filter_type.Flat:
                    return baseunit;
                case filter_type.Flat10k:
                    return baseunit + "*";
                case filter_type.A:
                    return baseunit + "(A)";
                case filter_type.A10k:
                    return baseunit + "(A)*";
                case filter_type.B:
                    return baseunit + "(B)";
                case filter_type.C:
                    return baseunit + "(C)";
                case filter_type.Phone:
                    return baseunit + "(P)";
                case filter_type.HDPhone:
                    return baseunit + "(HDP)";
            }
        }

        private double filter_A_dB(double f)
        {
            if (f <= 0) return -999;
            double ra = 12200 * 12200 * f * f * f * f /
                ((f * f + 20.6 * 20.6) * Math.Sqrt((f * f + 107.7 * 107.7) * (f * f + 737.9 * 737.9)) * (f * f + 12200 * 12200));
            return 2.0 + 20 * Math.Log10(ra);
        }

        private double filter_B_dB(double f)
        {
            if (f <= 0) return -999;
            double rb = 12200 * 12200 * f * f * f /
                ((f * f + 20.6 * 20.6) * Math.Sqrt(f * f + 158.2 * 158.2) * (f * f + 12200 * 12200));
            return 0.17 + 20 * Math.Log10(rb);
        }

        private double filter_C_dB(double f)
        {
            if (f <= 0) return -999;
            double rc = 12200 * 12200 * f * f /
                ((f * f + 20.6 * 20.6) * (f * f + 12200 * 12200));
            return 0.06 + 20 * Math.Log10(rc);
        }

        private void build_filter() {
            w[0] = 0.0; // DC component alway zero

            switch (type)
            {
                default:
                case filter_type.Flat:
                    for (int i = 1; i < N; i++)
                        w[i] = 1.0;
                    break;
                case filter_type.Flat10k:
                    for (int i = 1; i < N; i++)
                    {
                        if (f[i] <= 10000) w[i] = 1.0; else w[i] = 0.0;
                    }
                    break;
                case filter_type.A:
                    for (int i = 1; i < N; i++)
                    {
                        w[i] = Math.Pow(10, filter_A_dB(f[i]) / 20);
                    }
                    break;
                case filter_type.A10k:
                    for (int i = 1; i < N; i++)
                    {
                        if (f[i] <= 10000)
                            w[i] = Math.Pow(10, filter_A_dB(f[i]) / 20);
                        else
                            w[i] = 0.0;
                    }
                    break;
                case filter_type.B:
                    for (int i = 1; i < N; i++)
                    {
                        w[i] = Math.Pow(10, filter_B_dB(f[i]) / 20);
                    }
                    break;
                case filter_type.C:
                    for (int i = 1; i < N; i++)
                    {
                        w[i] = Math.Pow(10, filter_C_dB(f[i]) / 20);
                    }
                    break;
                case filter_type.Phone:
                    for (int i = 1; i < N; i++)
                    {
                        if ((f[i] >= 300) && (f[i] <= 3400)) w[i] = Math.Pow(10, filter_A_dB(f[i]) / 20); else w[i] = 0.0;
                    }
                    break;
                case filter_type.HDPhone:
                    for (int i = 1; i < N; i++)
                    {
                        if ((f[i] >= 50) && (f[i] <= 7000)) w[i] = Math.Pow(10, filter_A_dB(f[i]) / 20); else w[i] = 0.0;
                    }
                    break;

            }

        }

        public void update_to(filter_type ft)
        {
            type = ft;
            build_filter();
        }



    }
}
