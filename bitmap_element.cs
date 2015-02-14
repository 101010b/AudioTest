using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace audio_test
{
    class bitmap_element
    {
        PictureBox p;
        Bitmap bmap;
        public byte[] bmapdata;
        public int bmapdatawidth;
        public int bmapdataheight;
        public int bmapdatastrd;

        public bitmap_element(PictureBox pb)
        {
            p = pb;

            bmap = new Bitmap(pb.Width, pb.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            //for (int i = 0; i < 1200; i++) for (int j = 0; j < 100; j++) SetPixel(i, j, Color.Black);
            pb.Image = bmap;
            // bmap.MakeTransparent(Color.FromArgb(127, 127, 127));

            System.Drawing.Imaging.BitmapData bmd;
            bmd = bmap.LockBits(new Rectangle(0, 0, bmap.Width, bmap.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            bmapdata = new byte[bmd.Stride * bmap.Height];
            bmapdatawidth = bmap.Width;
            bmapdataheight = bmap.Height;
            bmapdatastrd = bmd.Stride;
            bmap.UnlockBits(bmd);

        }

        public void SetPixel(int x, int y, int r, int g, int b)
        {
            if ((x >= 0) && (x < bmapdatawidth) && (y >= 0) && (y < bmapdataheight))
            {
                int os = y * bmapdatastrd + x * 4;
                bmapdata[os + 2] = (byte)r;
                bmapdata[os + 1] = (byte)g;
                bmapdata[os + 0] = (byte)b;
            }
        }
        
        public void SetPixel(int x, int y, Color c)
        {
            if ((x >= 0) && (x < bmapdatawidth) && (y >= 0) && (y < bmapdataheight))
            {
                int os = y * bmapdatastrd + x * 4;
                bmapdata[os + 2] = c.R;
                bmapdata[os + 1] = c.G;
                bmapdata[os + 0] = c.B;
            }
        }

        public void FillRow(int x, int y1, int y2, Color c)
        {
            if (x < 0) return;
            if (x >= bmapdatawidth) return;
            if (y2 < y1) { int t = y1; y1 = y2; y2 = t; }
            if (y2 < 0) return;
            if (y1 >= bmapdataheight) return;
            if (y1 < 0) y1 = 0;
            if (y2 >= bmapdataheight) y2 = bmapdataheight - 1;
            int os = y1 * bmapdatastrd + x*4;
            for (int y = y1; y <= y2; y++)
            {
                bmapdata[os + 2] = c.R;
                bmapdata[os + 1] = c.G;
                bmapdata[os + 0] = c.B;
                os += bmapdatastrd;
            }            
        }

        public void FillCol(int x1, int x2, int y, Color c) 
        {
            if (y < 0) return;
            if (y >= bmapdataheight) return;
            if (x2 < x1) { int t = x1; x1 = x2; x2 = t; }
            if (x2 < 0) return;
            if (x1 >= bmapdatawidth) return;
            if (x1 < 0) x1 = 0;
            if (x2 >= bmapdatawidth) x2 = bmapdatawidth - 1;
            int os = y * bmapdatastrd + x1 * 4;
            for (int x = x1; x <= x2; x++)
            {
                bmapdata[os++] = c.B;
                bmapdata[os++] = c.G;
                bmapdata[os++] = c.R;
                os++;
            }
        }


        public void SetRed(int x, int y, int v)
        {
            if ((x >= 0) && (x < bmapdatawidth) && (y >= 0) && (y < bmapdataheight))
                bmapdata[y * bmapdatastrd + x * 4 + 2] = (byte)v;
        }

        public void SetGreen(int x, int y, int v)
        {
            if ((x >= 0) && (x < bmapdatawidth) && (y >= 0) && (y < bmapdataheight))
                bmapdata[y * bmapdatastrd + x * 4 + 1] = (byte)v;
        }

        public void SetBlue(int x, int y, int v)
        {
            if ((x >= 0) && (x < bmapdatawidth) && (y >= 0) && (y < bmapdataheight))
                bmapdata[y * bmapdatastrd + x * 4 + 0] = (byte)v;
        }

        public void drawbox(int x1, int y1, int x2, int y2, int cr, int cg, int cb)
        {
            if (x1 > x2) { int t = x1; x1 = x2; x2 = t; }
            if (y1 > y2) { int t = y1; y1 = y2; y2 = t; }
            if ((x2 < 0) || (x1 >= bmapdatawidth) || (y2 < 0) || (y1 >= bmapdataheight)) return;
            if (x1 < 0) x1 = 0;
            if (x2 >= bmapdatawidth) x2 = bmapdatawidth-1;
            if (y1 < 0) y1 = 0;
            if (y2 >= bmapdataheight) y2 = bmapdataheight-1;
            x2=x2-x1;
            for (int y=y1;y<=y2;y++) {
                int os=y*bmapdatastrd+x1*4;
                for (int i=0;i<=x2;i++) {
                    bmapdata[os]=(byte)cb;os++;
                    bmapdata[os]=(byte)cg;os++;
                    bmapdata[os]=(byte)cr;os++;
                    os++;
                }
            }
        }

        public void drawframe(int x1, int y1, int x2, int y2, int ofs, Color c)
        {
            if (x1 > x2) { int t = x1; x1 = x2; x2 = t; }
            if (y1 > y2) { int t = y1; y1 = y2; y2 = t; }
            FillCol(x1 - ofs, x2 + ofs, y1 - ofs, c);
            FillCol(x1 - ofs, x2 + ofs, y2 + ofs, c);
            FillRow(x1 - ofs, y1 - ofs + 1, y2 + ofs - 1, c);
            FillRow(x2 + ofs, y1 - ofs + 1, y2 + ofs - 1, c);
        }

        public void drawframe(Control ctrl, int ofs, Color c)
        {
            int x1 = ctrl.Location.X;
            int y1 = ctrl.Location.Y;
            int x2 = x1 + ctrl.Size.Width - 1;
            int y2 = y1 + ctrl.Size.Height - 1;
            drawframe(x1, y1, x2, y2, ofs, c);
        }

        public void push()
        {
            // int sx = bmap.Height;
            // int w = 1200 - sx;

            System.Buffer.BlockCopy(bmapdata, bmapdatastrd, bmapdata, 0, (bmapdataheight - 1) * bmapdatastrd);
            // for (int y = 1; y < 100; y++) System.Buffer.BlockCopy(bmapdata, y * bmapdatastrd + sx * 4, bmapdata, (y - 1) * bmapdatastrd + sx * 4, w * 4);
        }

        public void actualize()
        {
            System.Drawing.Imaging.BitmapData bmd;
            bmd = bmap.LockBits(new Rectangle(0, 0, bmap.Width, bmap.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            // bmd = bmap.LockBits(new Rectangle(0, 0, bmap.Width, bmap.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, bmap.PixelFormat);
            System.Runtime.InteropServices.Marshal.Copy(bmapdata, 0, bmd.Scan0, bmapdata.Length);
            bmap.UnlockBits(bmd);
            p.Refresh();
        }


        public void clear()
        {
            bmapdata.Initialize();
        }

        public void fill(Color c)
        {
            int os = 0;
            byte r = c.R;
            byte g = c.G;
            byte b = c.B;
            for (int y = 0; y < bmapdataheight; y++)
            {
                int tos=os;
                for (int x = 0; x < bmapdatawidth; x++)
                {
                    bmapdata[tos++] = b;
                    bmapdata[tos++] = g;
                    bmapdata[tos++] = r;
                    tos++;
                }
                os += bmapdatastrd;
            }
        }

        public void fade()
        {
            for (int i = 0; i < bmapdataheight; i++)
            {
                int os = i * bmapdatastrd;
                int es = os + 4 * bmapdatawidth;
                for (int j = os; j < es; j++)
                {
                    int c = bmapdata[j];
                    if (c < 2) c = 0; else c = c * 4 / 5; 
                    bmapdata[j] =(byte) c;
                }
            }
        }

    }
}
