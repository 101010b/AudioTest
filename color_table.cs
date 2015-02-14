using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace audio_test
{

    class color_table
    {
        public byte[] RED;
        public byte[] GREEN;
        public byte[] BLUE;

        public readonly int N;

        public color_table(int n, String s)
        {
            N = n;

            RED = new byte[N];
            GREEN = new byte[N];
            BLUE = new byte[N];

            build(s);
        }
               

        private bool getcolor(char c, ref double r, ref double g, ref double b)
        {
            char U = char.ToUpper(c);
            switch (U)
            {
                default:
                    return false;
                case 'K': r = 0; g = 0; b = 0; break;

                case 'R': r = 1; g = 0; b = 0; break;
                case 'G': r = 0; g = 1; b = 0; break;
                case 'B': r = 0; g = 0; b = 1; break;

                case 'Y': r = 1; g = 1; b = 0; break;
                case 'M': r = 1; g = 0; b = 1; break;
                case 'C': r = 0; g = 1; b = 1; break;

                case 'W': r = 1; g = 1; b = 1; break;

            }
            if (U != c)
            {
                r /= 2.0;
                g /= 2.0;
                b /= 2.0;
            }
            return true;
        }

        private bool getspacer(char c, ref double w)
        {
            switch (c)
            {
                default:
                    return false;
                case ' ': w = 0.0; break;
                case '-': w = 1.0; break;
                case '.': w = 0.5; break;
            }
            return true;
        }

        private bool isspacer(char c)
        {
            double w=0;
            return getspacer(c, ref w);
        }

        private bool iscolor(char c)
        {
            double r, g, b;
            r = g = b = 0;
            return getcolor(c, ref r, ref g, ref b);
        }

        public void col(int x, ref byte r, ref byte g, ref byte b)
        {
            if (x <= 0)
            {
                r = RED[0];
                g = GREEN[0];
                b = BLUE[0];
                return;
            }
            if (x >= N - 1)
            {
                r = RED[N-1];
                g = GREEN[N-1];
                b = BLUE[N-1];
                return;
            }
            r = RED[x];
            g = GREEN[x];
            b = BLUE[x];
        }

        public void col(int x, ref int r, ref int g, ref int b)
        {
            byte cr, cg, cb;
            cr = cg = cb = 0;
            col(x, ref cr, ref cg, ref cb);
            r = cr; g = cg; b = cb;
        }

        public void col(double x, ref byte r, ref byte g, ref byte b)
        {
            if (x <= 0.0)
            {
                r = RED[0];
                g = GREEN[0];
                b = BLUE[0];
                return;
            }
            if (x >= 1.0)
            {
                r = RED[N - 1];
                g = GREEN[N - 1];
                b = BLUE[N - 1];
                return;
            }
            int X = (int)Math.Floor(x * (N - 1) + 0.5);
            r = RED[X];
            g = GREEN[X];
            b = BLUE[X];
        }

        public void col(double x, ref int r, ref int g, ref int b)
        {
            byte cr, cg, cb;
            cr = cg = cb = 0;
            col(x, ref cr, ref cg, ref cb);
            r = cr; g = cg; b = cb;
        }

        private void build()
        {
            for (int i = 0; i < N; i++)
            {
                RED[i] = 0;
                GREEN[i] = 0;
                BLUE[i] = 0;
            }
        }

        private void build(char c)
        {
            byte r, g, b;
            r = g = b = 0;
            double cr, cg, cb;
            cr = cg = cb = 0.0;
            if (getcolor(c, ref cr, ref cg, ref cb))
            {
                r = to_byte(cr);
                g = to_byte(cg);
                b = to_byte(cb);
            }
            for (int i = 0; i < N; i++)
            {
                RED[i] = r;
                GREEN[i] = g;
                BLUE[i] = b;
            }
        }

        private void build(String s)
        {
            while (s.Length > 0 && isspacer(s[0]))
                s = s.Substring(1);
            while (s.Length > 0 && isspacer(s[s.Length-1]))
                s=s.Substring(0,s.Length-1);

            int M = s.Length;
            if (M <= 0)
            {
                // Bad
                build('R');
                return;
            }

            int clrs = 0;
            int sprs = 0; 

            // Check chain
            for (int i=0;i<M;i++) {
                if (iscolor(s[i]))
                    clrs++;
                else if (isspacer(s[i]))
                    sprs++;
                else {
                    // Bad
                    build();
                    return;
                }
            }

            // Less than two colors?
            if (clrs < 2) {
                for (int i=0;i<M;i++)
                    if (iscolor(s[i]))
                    {
                        build(s[i]);
                        return;
                    }
            }
            
            double[] rx = new double[clrs];
            double[] cr = new double[clrs];
            double[] cg = new double[clrs];
            double[] cb = new double[clrs];

            int idx = 0;
            double ofs = 0;
            for (int i = 0; i < M; i++)
            {
                double w=0;
                double r=0, g=0, b=0; 

                if (getspacer(s[i],ref w)) {
                    ofs+=w;
                } else if (getcolor(s[i], ref r, ref g, ref b)) {
                    rx[idx]=ofs;
                    cr[idx]=r;
                    cg[idx]=g;
                    cb[idx]=b;
                    ofs+=1.0;
                    idx++;
                }
            }

            for (int i=0;i<clrs;i++) {
                rx[i]=rx[i]/rx[clrs-1];
            }

            build(clrs, rx, cr, cg, cb);
        }

        private byte to_byte(double d)
        {
            if (d <= 0) return 0;
            if (d >= 1.0) return 255;
            int m = (int) Math.Floor(d*255.0+0.5);
            if (m < 0) return 0;
            if (m > 255) return 255; // Just for safety reasons - shoudl never happen ;-)
            return (byte) m;
        }

        private void build(int M, double[] rx, double[] cr, double[] cg, double[] cb)
        {
            // Special Cases
            if (M < 1)
            {
                for (int i = 0; i < N; i++)
                {
                    RED[i] = GREEN[i] = BLUE[i] = 0;
                }
                return;
            }
            if (M == 1)
            {
                byte r, g, b;
                r = to_byte(cr[0]);
                g = to_byte(cg[0]);
                b = to_byte(cb[0]);
                for (int i = 0; i < N; i++)
                {
                    RED[i] = r;
                    GREEN[i] = g;
                    BLUE[i] = b;
                }
                return;
            }

            // Sort
            for (int i = 0;i < M-1; i++)
                for (int j = i + 1; j < M; j++)
                {
                    if (rx[j] < rx[i])
                    {
                        double t;
                        t = rx[i]; rx[i] = rx[j]; rx[j] = t;
                        t = cr[i]; cr[i] = cr[j]; cr[j] = t;
                        t = cg[i]; cg[i] = cg[j]; cg[j] = t;
                        t = cb[i]; cb[i] = cb[j]; cb[j] = t;
                    }
                }

            for (int i = 0; i < N; i++)
            {
                double x = (double)i / ((double)N - 1.0);
                int left, right;
                if (x <= rx[0])
                {
                    RED[i]=to_byte(cr[0]);
                    GREEN[i]=to_byte(cg[0]);
                    BLUE[i]=to_byte(cb[0]);
                }
                else if (x >= rx[M - 1])
                {
                    RED[i]=to_byte(cr[M-1]);
                    GREEN[i]=to_byte(cg[M-1]);
                    BLUE[i]=to_byte(cb[M-1]);
                } 
                else 
                {
                    right=1;
                    while (rx[right] < x) right++;
                    left=right-1;
                    double f2 = (x-rx[left])/(rx[right]-rx[left]);
                    double f1 = 1.0-f2;
                    RED[i]=to_byte(cr[left]*f1 + cr[right]*f2);
                    GREEN[i]=to_byte(cg[left]*f1 + cg[right]*f2);
                    BLUE[i]=to_byte(cb[left]*f1 + cb[right]*f2);
                }
            }

        }

    }
}
