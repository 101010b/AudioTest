using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace audio_test
{
    delegate void audio_delegate(int mode);
    delegate void log_delegate(String s);


    public partial class mainwin : Form
    {

        // Special hack to allow grabbing and moving the window 
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        // Test Tone
        WaveProcess waveproc;
        test_tone_gen test_tone_out;
        bool test_tone_connected;
        bool test_tone_active;

        bitmap_element fftstream;
        bitmap_element fftdisp;
        bitmap_element osc;
        bitmap_element sterosc;
        bitmap_element pwr_l;
        bitmap_element pwr_r;

        Boolean fft_stream_on, fft_spek_on, osc_on, pwr_on, test_tone_on, log_on, config_on;

        List<group_element> fft_stream_grp;
        List<group_element> fft_spek_grp;
        List<group_element> fft_grp;
        List<group_element> osc_grp;
        List<group_element> pwr_grp;
        List<group_element> test_tone_grp;
        List<group_element> log_grp;

        log_delegate log_dgt;

        bool closing;

        int[] stereomap;

        // State 
        bool connected;
        bool playing = false;

        int fft_sel_source = 0;
        double fft_sel_stream_gain = 20.0;
        double fft_sel_spek_gain = 20.0;
        int osc_sel_gain = 1;
        filter pwr_filter;
        String pwr_unit;
        double pwr_ref_level;
        double fft_spek_ref_level;
        int[] maxspek = new int[1200];
        double addCircOfsF = 0;
        double addCircOfsPhi = 0;

        // Size and Dimensions
        float fontsize = 8F;
        int split_config = 0;
        int split_fft_stream = 0;
        int split_fft_spek = 0;
        int split_fft = 0;
        int split_osc = 0;
        int split_pwr = 0;
        int split_test_tone = 0;
        int split_log = 0;
        int split_fullwinx = 0;
        int split_fullwiny = 0;

        // Calibration
        double cal_raw;
        double cal_tgt;
        String cal_ut;
        bool cal_active;
        double plraw, prraw;

        // Color Tables
        color_table fft_stream_table;
        color_table fft_spek_table;
        color_table osc_stereo_table;
        
        public mainwin()
        {
            InitializeComponent();

            LOG.Text += "Starting Application\r\n";
            log_dgt = new log_delegate(log);

            waveproc = new WaveProcess(log_dgt);
            for (int i = 0; i < waveproc.devices.Count; i++) audioDevs.Items.Add(waveproc.devices[i]);
            if (waveproc.devices.Count > 0) audioDevs.SelectedIndex = 0;
            connected = false;

            test_tone_out = new test_tone_gen(log_dgt);
            for (int i = 0; i < test_tone_out.devices.Count; i++) test_tone_devs.Items.Add(test_tone_out.devices[i]);
            if (test_tone_out.devices.Count > 0) test_tone_devs.SelectedIndex = 0;
            test_tone_connected = false;
            test_tone_active = false;

            fftstream = new bitmap_element(fft_stream_display);
            fftdisp = new bitmap_element(fft_spek_display);
            osc = new bitmap_element(osc_wave_display);
            sterosc = new bitmap_element(osc_stereo_display);
            pwr_l = new bitmap_element(pwr_l_display);
            pwr_r = new bitmap_element(pwr_r_display);

            stereomap = new int[sterosc.bmapdataheight * sterosc.bmapdatawidth];

            timer1.Interval = 25; // 25 ms 
            closing = false;

            cal_raw = 0.0;
            cal_tgt = 0.0;
            cal_ut = "dBV";
            cal_active = false;
            
            // Window Configuration
            fft_stream_on = fft_spek_on = osc_on = test_tone_on = log_on = config_on = pwr_on = true;

            split_fullwinx = this.ClientSize.Width;
            split_fullwiny = this.ClientSize.Height;

            split_config = this.ClientSize.Width - fft_stream_gain.Location.X;

            split_fft_stream = fft_spek_display.Location.Y - fft_stream_display.Location.Y;
            split_fft_spek = fft_horz_axis.Location.Y - fft_spek_display.Location.Y;
            split_fft = osc_wave_display.Location.Y - fft_horz_axis.Location.Y;
            split_osc = pwr_l_val.Location.Y - osc_wave_display.Location.Y;
            split_pwr = test_tone_label1.Location.Y - pwr_l_val.Location.Y;
            split_test_tone = LOG.Location.Y - test_tone_label1.Location.Y;
            split_log = this.ClientSize.Height - LOG.Location.Y;
            
            Point top = new Point(0, fft_stream_vert_axis.Location.Y);
            fft_stream_grp = new List<group_element>();
            fft_stream_grp.Add(new group_element(fft_stream_vert_axis, top));
            fft_stream_grp.Add(new group_element(fft_stream_display, top));
            fft_stream_grp.Add(new group_element(fft_stream_label, top));
            fft_stream_grp.Add(new group_element(fft_stream_gain, top));
            fft_stream_grp.Add(new group_element(fft_stream_label2, top));
            fft_stream_grp.Add(new group_element(fft_stream_color, top));

            top.Y = fft_spek_vert_axis.Location.Y;
            fft_spek_grp = new List<group_element>();
            fft_spek_grp.Add(new group_element(fft_spek_vert_axis, top));
            fft_spek_grp.Add(new group_element(fft_spek_display, top));
            fft_spek_grp.Add(new group_element(fft_spek_label, top));
            fft_spek_grp.Add(new group_element(fft_spek_gain, top));
            fft_spek_grp.Add(new group_element(fft_spek_label2, top));
            fft_spek_grp.Add(new group_element(fft_spek_color, top));

            top.Y = fft_horz_axis.Location.Y;
            fft_grp = new List<group_element>();
            fft_grp.Add(new group_element(fft_horz_axis, top));
            fft_grp.Add(new group_element(fft_source_label, top));
            fft_grp.Add(new group_element(fft_source, top));

            top.Y = osc_vert_axis.Location.Y;
            osc_grp = new List<group_element>();
            osc_grp.Add(new group_element(osc_vert_axis, top));
            osc_grp.Add(new group_element(osc_wave_display, top));
            osc_grp.Add(new group_element(osc_stereo_display, top));
            osc_grp.Add(new group_element(osc_gain_label, top));
            osc_grp.Add(new group_element(osc_gain, top));
            osc_grp.Add(new group_element(osc_circ_ofs_label, top));
            osc_grp.Add(new group_element(osc_circ_ofs, top));
            osc_grp.Add(new group_element(osc_horz_axis, top));
            osc_grp.Add(new group_element(osc_color_label, top));
            osc_grp.Add(new group_element(osc_color, top));

            top.Y = pwr_l_val.Location.Y;
            pwr_grp = new List<group_element>();
            pwr_grp.Add(new group_element(pwr_l_label, top));
            pwr_grp.Add(new group_element(pwr_l_display, top));
            pwr_grp.Add(new group_element(pwr_l_val, top));
            pwr_grp.Add(new group_element(pwr_l_unit, top));
            pwr_grp.Add(new group_element(pwr_r_label, top));
            pwr_grp.Add(new group_element(pwr_r_display, top));
            pwr_grp.Add(new group_element(pwr_r_val, top));
            pwr_grp.Add(new group_element(pwr_r_unit, top));
            pwr_grp.Add(new group_element(pwr_int_label, top));
            pwr_grp.Add(new group_element(pwr_int_filter, top));
            pwr_grp.Add(new group_element(pwr_horz_axis, top));

            top.Y = test_tone_label1.Location.Y;
            test_tone_grp = new List<group_element>();
            test_tone_grp.Add(new group_element(test_tone_label1, top));
            test_tone_grp.Add(new group_element(test_tone_connect, top));
            test_tone_grp.Add(new group_element(test_tone_devs, top));
            test_tone_grp.Add(new group_element(test_tone_out_dev, top));
            test_tone_grp.Add(new group_element(test_tone_label2, top));
            test_tone_grp.Add(new group_element(test_tone_label3, top));
            test_tone_grp.Add(new group_element(test_tone_waveform, top));
            test_tone_grp.Add(new group_element(test_tone_amp, top));
            test_tone_grp.Add(new group_element(test_tone_label4, top));
            test_tone_grp.Add(new group_element(test_tone_freq, top));
            test_tone_grp.Add(new group_element(test_tone_fsweep, top));
            test_tone_grp.Add(new group_element(test_tone_label5, top));
            test_tone_grp.Add(new group_element(test_tone_freqstop, top));
            test_tone_grp.Add(new group_element(test_tone_label6, top));
            test_tone_grp.Add(new group_element(test_tone_sweep_time, top));
            test_tone_grp.Add(new group_element(test_tone_logsweep, top));
            test_tone_grp.Add(new group_element(test_tone_updown, top));
            test_tone_grp.Add(new group_element(test_tone_label7, top));
            test_tone_grp.Add(new group_element(test_tone_pw, top));
            test_tone_grp.Add(new group_element(test_tone_label8, top));
            test_tone_grp.Add(new group_element(test_tone_label9, top));
            test_tone_grp.Add(new group_element(test_tone_label10, top));
            test_tone_grp.Add(new group_element(test_tone_mod, top));
            test_tone_grp.Add(new group_element(test_tone_modform, top));
            test_tone_grp.Add(new group_element(test_tone_modfreq, top));
            test_tone_grp.Add(new group_element(test_tone_modamp, top));


            
            top.Y = LOG.Location.Y;
            log_grp = new List<group_element>();
            log_grp.Add(new group_element(LOG, top));
            log_grp.Add(new group_element(en_testtone, top));
            log_grp.Add(new group_element(testtone_amp, top));
            log_grp.Add(new group_element(testtone_freq, top));
            log_grp.Add(new group_element(testtone_label1, top));
            log_grp.Add(new group_element(testtone_label2, top));


            // Fill the Combo Boxes
            fft_window_func.Items.Add("Rectangular");
            fft_window_func.Items.Add("Hann");
            fft_window_func.Items.Add("Hamming");
            fft_window_func.Items.Add("Blackman");
            fft_window_func.SelectedIndex = 1;

            cal_unit.Items.Add("dBV");
            cal_unit.Items.Add("dBm");
            cal_unit.Items.Add("dBPa");
            cal_unit.Items.Add("dBSPL");
            cal_unit.SelectedIndex = 0;
            
            fft_stream_gain.Items.Add("0 db");
            fft_stream_gain.Items.Add("6 db");
            fft_stream_gain.Items.Add("10 db");
            fft_stream_gain.Items.Add("20 db");
            fft_stream_gain.Items.Add("30 db");
            fft_stream_gain.Items.Add("40 db");
            fft_stream_gain.Items.Add("60 db");
            fft_stream_gain.SelectedIndex = 0;

            fft_stream_color.Items.Add("KrYW");
            fft_stream_color.Items.Add("KbBW");
            fft_stream_color.Items.Add("KrgBW");
            fft_stream_color.Items.Add("KW");
            fft_stream_color.Items.Add("KmryGCBW");
            fft_stream_color.SelectedIndex = 0;
            
            fft_spek_gain.Items.Add("0 db");
            fft_spek_gain.Items.Add("6 db");
            fft_spek_gain.Items.Add("10 db");
            fft_spek_gain.Items.Add("20 db");
            fft_spek_gain.Items.Add("30 db");
            fft_spek_gain.Items.Add("40 db");
            fft_spek_gain.Items.Add("60 db");
            fft_spek_gain.SelectedIndex = 0;

            fft_source.Items.Add("L + R");
            fft_source.Items.Add("L");
            fft_source.Items.Add("R");
            fft_source.SelectedIndex = 0;

            fft_spek_color.Items.Add("rRYW");
            fft_spek_color.Items.Add("KbBW");
            fft_spek_color.Items.Add("KrgBW");
            fft_spek_color.Items.Add("KW");
            fft_spek_color.Items.Add("KmryGCBW");
            fft_spek_color.SelectedIndex = 0;

            osc_gain.Items.Add("0 dB");
            osc_gain.Items.Add("6 dB");
            osc_gain.Items.Add("10 dB");
            osc_gain.Items.Add("20 dB");
            osc_gain.Items.Add("30 dB");
            osc_gain.Items.Add("40 dB");
            osc_gain.Items.Add("60 dB");
            osc_gain.SelectedIndex = 0;

            osc_color.Items.Add("KrYW");
            osc_color.Items.Add("KbBW");
            osc_color.Items.Add("KrgBW");
            osc_color.Items.Add("KW");
            osc_color.Items.Add("KmryGCBW");
            osc_color.SelectedIndex = 0;

            List<String> FL = filter.getList();
            for (int i = 0; i < FL.Count; i++) pwr_int_filter.Items.Add(FL[i]);
            pwr_filter = new filter(1200, 24000, filter_type.A);
            pwr_int_filter.SelectedIndex = pwr_filter.getIndex();
            pwr_ref_level = -100;

            test_tone_waveform.Items.Add("Sine");
            test_tone_waveform.Items.Add("/\\/\\/");
            test_tone_waveform.Items.Add("/////");
            test_tone_waveform.Items.Add("_-_-_-_");
            test_tone_waveform.Items.Add("Noise");
            test_tone_waveform.SelectedIndex = 0;

            test_tone_mod.Items.Add("Off");
            test_tone_mod.Items.Add("AM");
            test_tone_mod.Items.Add("FM");
            test_tone_mod.Items.Add("PWM");
            test_tone_mod.SelectedIndex=0;

            test_tone_modform.Items.Add("Sine");
            test_tone_modform.Items.Add("/\\/\\/");
            test_tone_modform.Items.Add("/////");
            test_tone_modform.Items.Add("_-_-_-_");
            test_tone_modform.SelectedIndex = 0;

            osc_circ_ofs.Items.Add("off");
            osc_circ_ofs.Items.Add("6.875 Hz");
            osc_circ_ofs.Items.Add("13.75 Hz");
            osc_circ_ofs.Items.Add("27.5 Hz");
            osc_circ_ofs.Items.Add("55 Hz");
            osc_circ_ofs.Items.Add("110 Hz");
            osc_circ_ofs.Items.Add("220 Hz");
            osc_circ_ofs.Items.Add("440 Hz");
            osc_circ_ofs.Items.Add("880 Hz");
            osc_circ_ofs.SelectedIndex = 0;

            // Update Axis Bitmaps
            update_fft_horz_axis();
            update_fft_spek_vert_axis();
            update_fft_stream_vert_axis();
            update_osc_horz_axis();
            update_osc_vert_axis();
            update_pwr_horz_axis();

            fft_stream_table = new color_table(1000, "KrYW");
            fft_spek_table = new color_table(fftdisp.bmapdataheight, "rRYW");
            osc_stereo_table = new color_table(1000, "KRYW");

            // Resize the window
            setup_window();
        }        

        void setup_window()
        {
            bool update_needed = false;
            if (fft_stream_on != fft_stream_onoff.Checked) { fft_stream_on = fft_stream_onoff.Checked; update_needed = true; }
            if (fft_spek_on != fft_spek_onoff.Checked) { fft_spek_on = fft_spek_onoff.Checked; update_needed = true; }
            if (osc_on != osc_onoff.Checked) { osc_on = osc_onoff.Checked; update_needed = true; }
            if (pwr_on != pwr_onoff.Checked) { pwr_on = pwr_onoff.Checked; update_needed = true; }
            if (test_tone_on != test_tone_onoff.Checked) { test_tone_on = test_tone_onoff.Checked; update_needed = true; }
            if (log_on != log_onoff.Checked) { log_on = log_onoff.Checked; update_needed = true; }
            if (config_on != config_onoff.Checked) { config_on = config_onoff.Checked; update_needed = true; }

            if (!update_needed) return;

            int winheight = split_fullwiny - split_fft_stream - split_fft_spek - split_fft - split_osc - split_pwr - split_test_tone - split_log;
            int winwidth = split_fullwinx - split_config;

            if (config_on) winwidth += split_config;

            if (fft_stream_on) winheight += split_fft_stream;
            if (fft_spek_on) winheight += split_fft_spek;
            if (fft_spek_on || fft_stream_on) winheight += split_fft;
            if (osc_on) winheight += split_osc;
            if (pwr_on) winheight += split_pwr;
            if (test_tone_on) winheight += split_test_tone;
            if (log_on) winheight += split_log;

            this.ClientSize = new Size(winwidth, winheight);
            Point top = new Point(0, split_fullwiny - split_fft_stream - split_fft_spek - split_fft - split_osc - split_pwr - split_test_tone - split_log);


            if (fft_stream_on)
            {
                foreach (group_element g in fft_stream_grp) g.show(top);
                top.Y += split_fft_stream;
            }
            else
            {
                foreach (group_element g in fft_stream_grp) g.hide();
            }

            if (fft_spek_on)
            {
                foreach (group_element g in fft_spek_grp) g.show(top);
                top.Y += split_fft_spek;
            }
            else
            {
                foreach (group_element g in fft_spek_grp) g.hide();
            }

            if (fft_stream_on || fft_spek_on)
            {
                foreach (group_element g in fft_grp) g.show(top);
                top.Y += split_fft;
            }
            else
            {
                foreach (group_element g in fft_grp) g.hide();
            }

            if (osc_on)
            {
                foreach (group_element g in osc_grp) g.show(top);
                top.Y += split_osc;
            }
            else
            {
                foreach (group_element g in osc_grp) g.hide();
            }

            if (pwr_on)
            {
                foreach (group_element g in pwr_grp) g.show(top);
                top.Y += split_pwr;                
            }
            else
            {
                foreach (group_element g in pwr_grp) g.hide();
            }

            if (test_tone_on)
            {
                foreach (group_element g in test_tone_grp) g.show(top);
                top.Y += split_test_tone;
            }
            else
            {
                foreach (group_element g in test_tone_grp) g.hide();
            }
            
            if (log_on)
            {
                foreach (group_element g in log_grp) g.show(top);
                top.Y += split_log;
            }
            else
            {
                foreach (group_element g in log_grp) g.hide();
            }

            bkgbx.Size = new Size(winwidth, winheight);
            bitmap_element bme = new bitmap_element(bkgbx);
            bme.fill(Color.FromArgb(0, 0, 0));

            bme.drawframe(0, 0, winwidth - 1, winheight - 1, 0, Color.FromArgb(255, 255, 255));
            bme.drawframe(0, 0, winwidth - 1, winheight - 1, -1, Color.FromArgb(127, 127, 127));

            if (fft_stream_on) bme.drawframe(fft_stream_display, 1, Color.FromArgb(0, 127, 0));
            if (fft_spek_on) bme.drawframe(fft_spek_display, 1, Color.FromArgb(0, 127, 0));
            if (osc_on)
            {
                bme.drawframe(osc_wave_display, 1, Color.FromArgb(0, 127, 0));
                bme.drawframe(osc_stereo_display, 1, Color.FromArgb(0, 127, 0));
            }

            bme.actualize();
        }
         
        String get_pwr_filter_unit(String baseunit)
        {
            return pwr_filter.get_filter_unit(baseunit);
        }

        String get_pwr_filter_unit()
        {
            if (!cal_active)
            {
                return pwr_filter.get_filter_unit("dBFS");
            }
            else
            {
                return pwr_filter.get_filter_unit(cal_ut);
            }
        }

        int limit(int i, int min, int max)
        {
            if (i < min) return min;
            if (i > max) return max;
            return i;
        }
        
        private void Connect_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                if (playing)
                {
                    playing = false;
                    Connect.Text = "Play";
                }
                else
                {
                    playing = true;
                    Connect.Text = "Pause";
                }
            }
            else
            {
                if (waveproc.devices.Count > 0)
                {
                    LOG.Text += "Connecting Audio\r\n";
                    waveproc.start(audioDevs.SelectedIndex);
                    // waveproc.start(audioDevs.SelectedIndex, new audio_delegate(update_audio));
                    device_label.Text = (String)audioDevs.Items[audioDevs.SelectedIndex];

                    timer1.Enabled = true;

                    playing = true;
                    Connect.Text = "Pause";
                    audioDevs.Visible = false;
                    device_label.Visible = true;
                    connected = true;
                }
            }
        }

        // Log to the Text Log Window
        void log(String s)
        {
            if (closing) return;
            if (LOG.InvokeRequired)
            {
                LOG.Invoke(log_dgt, s);
            }
            else
            {
                LOG.Text += s + "\r\n";
            }
        }

        void drawtxt(Graphics g, Font fnt, Color fntcol, vector pos, vector along, int ax, int ay, String txt) {
	        float xofs;
	        float yofs;
	        SizeF size;
	        float phi;
	        vector vx,vy;
	        RectangleF bb;

            xofs = yofs = 0;

	        if (pos.len() > 1e6) return;

	        txt=txt.Replace('|','\n');

	        GraphicsPath gp=new GraphicsPath();
	
	        StringFormat sf=new StringFormat();
	        switch (ax) {
	        case -1: // Left
		        sf.Alignment=StringAlignment.Near;
		        break;
	        case 0: // Center
		        sf.Alignment=StringAlignment.Center;
		        break;
	        case 1: // Right
		        sf.Alignment=StringAlignment.Far;
		        break;
	        }
	        gp.AddString(txt,fnt.FontFamily,(int) fnt.Style,fnt.Height,new PointF(0,0),sf);

	        bb=gp.GetBounds();

	        bb.Inflate(new SizeF(2F,2F));

            size = new SizeF(bb.Width, bb.Height);

	        if (along.len() <= 0) along=new vector(1,0);
	        phi=(float) (Math.Atan2(along.y,along.x)*180.0/Math.PI);

	        vx=along/along.len();
	        vy=new vector(-vx.y,vx.x);

	        if ((phi > 90) || (phi < -90)) {
		        if (phi > 90) phi=phi-180; else phi=phi+180;
		        ax=-ax;
		        ay=-ay;
		        vx=vx*(-1);
		        vy=new vector(-vx.y,vx.x);
	        }

	        switch (ax) {
	        case -1 : xofs=bb.Left;break;
	        case 0: xofs=(bb.Right+bb.Left)/2;break;
	        case 1: xofs=bb.Right;break;
	        }
	        switch (ay) {
	        case -1: yofs=bb.Top;break;
	        case 0: yofs=(bb.Bottom+bb.Top)/2;break;
	        case 1: yofs=bb.Bottom;break;
	        }
	        Matrix mt = new Matrix();
	        mt.Translate(-xofs,-yofs);
	        gp.Transform(mt);

	        g.TranslateTransform((float)pos.x,(float)pos.y);
	        g.RotateTransform(phi);

	        SolidBrush fb=new SolidBrush(fntcol);
	        g.FillPath(fb,gp);

	        g.ResetTransform();
        }


        // Axis Updates
        void update_fft_horz_axis()
        {
            int w, h;
            Color drawcol = Color.FromArgb(0, 255, 0);
            w = fft_horz_axis.Width;
            h = fft_horz_axis.Height;
            Bitmap bmap = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            Graphics g = Graphics.FromImage(bmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.Clear(this.BackColor);

            Pen p = new Pen(drawcol);
            Font fnt = new Font(FontFamily.GenericSansSerif, fontsize, FontStyle.Regular, GraphicsUnit.Pixel);

            for (float f = 0; f <= 24000; f += 1000)
            {
                float xpos=f*(w-1)/24000;
                if (xpos < 0) xpos=0;
                if (xpos >= w) xpos=w-1;
                g.DrawLine(p, xpos, 0, xpos, 5);

                String s = String.Format("{0,2}k", f/1000.0f);
                if (f == 0)
                    drawtxt(g, fnt, drawcol, new vector(xpos, 10), new vector(0, 1), -1, 1, s);
                else if (f == 24000)
                    drawtxt(g, fnt, drawcol, new vector(xpos, 10), new vector(0, 1), -1, -1, s);
                else
                    drawtxt(g, fnt, drawcol, new vector(xpos, 10), new vector(0, 1), -1, 0, s);
            }
            drawtxt(g, fnt, drawcol, new vector(w / 2, h - 1), new vector(1, 0), 0, 1, "Frequency [Hz]");

            fft_horz_axis.Image = bmap;
            fft_horz_axis.Invalidate();
        }

        void update_fft_spek_vert_axis()
        {
            int w, h;
            Color drawcol = Color.FromArgb(0, 255, 0);
            w = fft_spek_vert_axis.Width;
            h = fft_spek_vert_axis.Height;
            Bitmap bmap = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            Graphics g = Graphics.FromImage(bmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.Clear(this.BackColor);

            Pen p = new Pen(drawcol);
            Font fnt = new Font(FontFamily.GenericSansSerif, fontsize, FontStyle.Regular, GraphicsUnit.Pixel);
            

            if (cal_active)
            {
                fft_spek_ref_level = Math.Floor((0 - fft_sel_spek_gain - cal_raw + cal_tgt)/10+0.5)*10;
            }
            else
            {
                fft_spek_ref_level = Math.Floor((0 - fft_sel_spek_gain)/10+0.5)*10;
            }

            for (float f0 = 0; f0 > -100; f0 -= 10)
            {
                float f = f0 + (float)fft_spek_ref_level;
                float ypos = -f0 * (h - 1.0f) / 100.0f;
                if ((ypos >= 0) && (ypos < h))
                {
                    g.DrawLine(p, w - 5, ypos, w - 1, ypos);

                    String s = String.Format("{0,2}", f);
                    if (ypos < 5)
                        drawtxt(g, fnt, drawcol, new vector(w - 10, ypos), new vector(1, 0), 1, -1, s);
                    else if (ypos >= h-5)
                        drawtxt(g, fnt, drawcol, new vector(w - 10, ypos), new vector(1, 0), 1, 1, s);
                    else
                        drawtxt(g, fnt, drawcol, new vector(w - 10, ypos), new vector(1, 0), 1, 0, s);
                }
            }
            if (cal_active)
                drawtxt(g, fnt, drawcol, new vector(0,h / 2), new vector(0, -1), 0, -1, "Level [" + cal_ut + "]");
            else
                drawtxt(g, fnt, drawcol, new vector(0, h / 2), new vector(0, -1), 0, -1, "Level [dBFS]");

            fft_spek_vert_axis.Image = bmap;
            fft_spek_vert_axis.Invalidate();
        }

        void update_fft_stream_vert_axis()
        {
            int w, h;
            Color drawcol = Color.FromArgb(0, 255, 0);
            w = fft_stream_vert_axis.Width;
            h = fft_stream_vert_axis.Height;
            Bitmap bmap = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            Graphics g = Graphics.FromImage(bmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.Clear(this.BackColor);

            Pen p = new Pen(drawcol);
            Font fnt = new Font(FontFamily.GenericSansSerif, fontsize, FontStyle.Regular, GraphicsUnit.Pixel);

            for (float f = 0; f < 20;f=f + 0.5F)
            {
                float ypos = h-1 - f/25e-3f;
                if ((ypos >= 0) && (ypos < h))
                {
                    g.DrawLine(p, w - 5, ypos, w - 1, ypos);

                    String s = String.Format("{0,2}", f);
                    if (ypos < 5)
                        drawtxt(g, fnt, drawcol, new vector(w - 10, ypos), new vector(1, 0), 1, -1, s);
                    else if (ypos >= h - 5)
                        drawtxt(g, fnt, drawcol, new vector(w - 10, ypos), new vector(1, 0), 1, 1, s);
                    else
                        drawtxt(g, fnt, drawcol, new vector(w - 10, ypos), new vector(1, 0), 1, 0, s);
                }
            }
            drawtxt(g, fnt, drawcol, new vector(0, h / 2), new vector(0, -1), 0, -1, "Time [-s]");

            fft_stream_vert_axis.Image = bmap;
            fft_stream_vert_axis.Invalidate();
        }

        void update_osc_horz_axis()
        {
            int w, h;
            Color drawcol = Color.FromArgb(0, 255, 0);
            w = osc_horz_axis.Width;
            h = osc_horz_axis.Height;
            Bitmap bmap = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            Graphics g = Graphics.FromImage(bmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.Clear(this.BackColor);

            Pen p = new Pen(drawcol);
            Font fnt = new Font(FontFamily.GenericSansSerif, fontsize, FontStyle.Regular, GraphicsUnit.Pixel);

            for (float f = 0; f <= 20; f += 0.5f)
            {
                float xpos = f/1000 * 48000;
                if ((xpos >= 0) && (xpos < w))
                {
                    g.DrawLine(p, xpos, 0, xpos, 5);

                    String s = String.Format("{0,2}", f);
                    if (xpos < 5)
                        drawtxt(g, fnt, drawcol, new vector(xpos, 10), new vector(0, 1), -1, 1, s);
                    else if (xpos > w - 5)
                        drawtxt(g, fnt, drawcol, new vector(xpos, 10), new vector(0, 1), -1, -1, s);
                    else
                        drawtxt(g, fnt, drawcol, new vector(xpos, 10), new vector(0, 1), -1, 0, s);
                }
            }
            drawtxt(g, fnt, drawcol, new vector(w / 2, h - 1), new vector(1, 0), 0, 1, "Time [ms]");

            osc_horz_axis.Image = bmap;
            osc_horz_axis.Invalidate();
        }

        void update_osc_vert_axis()
        {
            int w, h;
            Color drawcol = Color.FromArgb(0, 255, 0);
            w = osc_vert_axis.Width;
            h = osc_vert_axis.Height;
            Bitmap bmap = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            Graphics g = Graphics.FromImage(bmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.Clear(this.BackColor);

            Pen p = new Pen(drawcol);
            Font fnt = new Font(FontFamily.GenericSansSerif, fontsize, FontStyle.Regular, GraphicsUnit.Pixel);

            float maxval, step, scale;
            String u;
            switch (osc_sel_gain)
            {
                default:
                case 1: maxval = 1F; step = 0.2F; scale = 1f; u = ""; break;
                case 2: maxval = 0.5F; step = 0.1F; scale = 1f; u = ""; break;
                case 3: maxval = 0.33333F; step = 0.1F; scale = 1f; u = ""; break;
                case 10: maxval = 0.1F; step = 0.02F; scale = 1f; u = ""; break;
                case 32: maxval = 0.03333F; step = 0.01F; scale = 1f; u = ""; break;
                case 100: maxval = 0.01F; step = 0.002F; scale = 1000f; u = "m"; break;
                case 1000: maxval = 0.001F; step = 0.0002F; scale = 1000f; u = "m"; break;
            }

            int n = (int)Math.Floor(maxval / step+0.5);
            for (int i = -n;i<=n;i++)
            {
                float f = (float)i * step;
                float ypos = h / 2 - (f * (h - 1) / 2 / maxval);
                if ((ypos >= 0) && (ypos < h))
                {
                    g.DrawLine(p, w - 5, ypos, w - 1, ypos);

                    String s = String.Format("{0:0.00}", f * scale);
                    if (ypos < 5)
                        drawtxt(g, fnt, drawcol, new vector(w - 10, ypos), new vector(1, 0), 1, -1, s);
                    else if (ypos >= h - 5)
                        drawtxt(g, fnt, drawcol, new vector(w - 10, ypos), new vector(1, 0), 1, 1, s);
                    else
                        drawtxt(g, fnt, drawcol, new vector(w - 10, ypos), new vector(1, 0), 1, 0, s);
                }
            }
            drawtxt(g, fnt, drawcol, new vector(0, h / 2), new vector(0, -1), 0, -1, String.Format("V [{0}FS]",u));

            osc_vert_axis.Image = bmap;
            osc_vert_axis.Invalidate();
        }

        void update_pwr_horz_axis()
        {
            int w, h;
            Color drawcol = Color.FromArgb(0, 255, 0);
            w = pwr_horz_axis.Width;
            h = pwr_horz_axis.Height;
            Bitmap bmap = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            Graphics g = Graphics.FromImage(bmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.Clear(this.BackColor);

            Pen p = new Pen(drawcol);
            Font fnt = new Font(FontFamily.GenericSansSerif, fontsize, FontStyle.Regular, GraphicsUnit.Pixel);

            double ledstart = -100;
            double ledend = 0;

            if (cal_active)
            {
                ledstart = Math.Floor((ledstart - cal_raw + cal_tgt) / 5 + 0.5) * 5;
                ledend = ledstart + 100;
            }
            pwr_ref_level = ledstart;

            for (float f = (float)ledstart; f <= (float)ledend; f += 5.0f)
            {
                float xpos = (f-(float)ledstart)/100 * (w-1);
                if ((xpos >= 0) && (xpos < w))
                {
                    g.DrawLine(p, xpos, 0, xpos, 5);

                    String s = String.Format("{0,2}", f);
                    if (xpos < 5)
                        drawtxt(g, fnt, drawcol, new vector(xpos, 10), new vector(0, 1), -1, 1, s);
                    else if (xpos > w - 5)
                        drawtxt(g, fnt, drawcol, new vector(xpos, 10), new vector(0, 1), -1, -1, s);
                    else
                        drawtxt(g, fnt, drawcol, new vector(xpos, 10), new vector(0, 1), -1, 0, s);
                }
            }
            drawtxt(g, fnt, drawcol, new vector(w / 2, h - 1), new vector(1, 0), 0, 1, 
                String.Format("Power [{0}]",pwr_unit));

            pwr_horz_axis.Image = bmap;
            pwr_horz_axis.Invalidate();
        }

        double sqr(double i) { return i * i; }

        double to_db(double vin) { if (vin <= 0) return -200; else return 20.0 * Math.Log10(vin); }

        // Actual Audio Function
        void update_audio(int sctr)
        {

            double[] db1 = new double[1200];
            double[] db2 = new double[1200];

            if (fft_stream_on || fft_spek_on) {
                switch (fft_sel_source)
                {
                    default:
                    case 0: // Sum L/R
                        for (int i = 0; i < 1200; i++)
                            db1[i] = to_db(waveproc.buffer[waveproc.buf_rd].fft1[i]);
                        for (int i = 0; i < 1200; i++)
                            db2[i] = to_db(waveproc.buffer[waveproc.buf_rd].fft2[i]);
                        break;
                    case 1: // Left
                        for (int i = 0; i < 1200; i++)
                            db1[i] = to_db(waveproc.buffer[waveproc.buf_rd].fftl1[i]);
                        for (int i = 0; i < 1200; i++)
                            db2[i] = to_db(waveproc.buffer[waveproc.buf_rd].fftl2[i]);
                        break;
                    case 2: // Right
                        for (int i = 0; i < 1200; i++)
                            db1[i] = to_db(waveproc.buffer[waveproc.buf_rd].fftr1[i]);
                        for (int i = 0; i < 1200; i++)
                            db2[i] = to_db(waveproc.buffer[waveproc.buf_rd].fftr2[i]);
                        break;
                }
            }

            if (fft_stream_on)
            {
                double cf = waveproc.amp_cf + fft_sel_stream_gain+100.0;
                fftstream.push();
                for (int i = 0; i < 1200; i++)
                {
                    int r, g, b;
                    r = g = b = 0;
                    fft_stream_table.col((db1[i] + cf)/100.0, ref r, ref g, ref b);
                    fftstream.SetPixel(i, fftstream.bmapdataheight - 1, r, g, b);
                }
                fftstream.push();
                for (int i = 0; i < 1200; i++)
                {
                    int r, g, b;
                    r = g = b = 0;
                    fft_stream_table.col((db1[i] + cf)/100.0, ref r, ref g, ref b);
                    fftstream.SetPixel(i, fftstream.bmapdataheight - 1, r, g, b);
                }
            }

            if (fft_spek_on)
            {
                fftdisp.fade();
                double cf = waveproc.amp_cf - fft_spek_ref_level + 100;
                for (int i = 0; i < 1200; i++)
                {
                    double val = db2[i] + cf;
                    //int r, g, b;
                    //r = g = b = 0;
                    if (cal_active)
                    {
                        val = val - cal_raw + cal_tgt;
                    }
                    val = val / 100.0 * fftdisp.bmapdataheight;
                    int ival = limit((int)Math.Floor(val + 0.5), -1, fftdisp.bmapdataheight - 1);
                    if (ival > maxspek[i]) maxspek[i] = ival; else maxspek[i]--;
                    if (maxspek[i] < -1) maxspek[i] = -1;

                    for (int j = 0; j < ival; j++)
                        fftdisp.SetPixel(i, fftdisp.bmapdataheight - 1 - j, 
                            fft_spek_table.RED[j], fft_spek_table.GREEN[j],fft_spek_table.BLUE[j]);
                    if (maxspek[i] >= 0)
                    {
                        fftdisp.SetPixel(i, fftdisp.bmapdataheight - 1 - maxspek[i],
                            fft_spek_table.RED[maxspek[i]],
                            fft_spek_table.GREEN[maxspek[i]],
                            fft_spek_table.BLUE[maxspek[i]]);
                    }
                }
            }

            if (osc_on)
            {
                osc.fade();
                int trigp = 0;
                int maxstart = osc.bmapdatawidth / 2 + 1;
                int maxend = 2400 - osc.bmapdatawidth / 2 - 1;

                trigp = osc.bmapdatawidth / 2 + 1;
                /*
                int tlev = 100;
                for (int i = maxstart; (i < maxend) && (trigp == 0); i++)
                {
                    if ((waveproc.fullbufs[i - 1] < tlev) && (waveproc.fullbufs[i] >= tlev))
                        trigp = i - osc.bmapdatawidth / 2;
                }*/

                for (int i = 0; i < osc.bmapdatawidth; i++)
                {
                    int y = osc_sel_gain*(int)waveproc.buffer[waveproc.buf_rd].wavel[i + trigp];
                    y = y * osc.bmapdataheight >> 16;
                    osc.SetRed(i, osc.bmapdataheight / 2 - y, 255);
                    y = osc_sel_gain*(int)waveproc.buffer[waveproc.buf_rd].waver[i + trigp];
                    y = y * osc.bmapdataheight >> 16;
                    osc.SetGreen(i, osc.bmapdataheight / 2 - y, 255);
                }

                for (int i = 0; i < sterosc.bmapdatawidth * sterosc.bmapdatawidth; i++)
                    stereomap[i] = (stereomap[i] >> 3) + (stereomap[i] >> 2) + (stereomap[i] >> 1);
                //for (int i = 0; i < sterosc.bmapdatawidth * sterosc.bmapdatawidth; i++)
                //    if (stereomap[i] > 20) stereomap[i]-=20;

                for (int i = 0; i < 2400; i++)
                {
                    int x, y;
                    x = osc_sel_gain * (int)waveproc.buffer[waveproc.buf_rd].wavel[i];
                    y = osc_sel_gain * (int)waveproc.buffer[waveproc.buf_rd].waver[i];
                    if (addCircOfsF > 0)
                    {
                        addCircOfsPhi += addCircOfsF / 48000;
                        if (addCircOfsPhi > 1)
                            addCircOfsPhi = addCircOfsPhi - Math.Floor(addCircOfsPhi);
                        int dx = (int)Math.Floor(16384.0 * Math.Sin(addCircOfsPhi * 2 * Math.PI));
                        int dy = (int)Math.Floor(16384.0 * Math.Cos(addCircOfsPhi * 2 * Math.PI));

                        int ax = dx + ((dx * (x+y)) >> 15);
                        int ay = dy + ((dy * (x+y)) >> 15);

                        x = ax;
                        y = ay;
                        //x += dx;
                        //y += dy;
                    }
                    x = (x * sterosc.bmapdatawidth >> 16) + sterosc.bmapdatawidth / 2;
                    y = sterosc.bmapdataheight / 2 - (y * sterosc.bmapdataheight >> 16);
                    if ((x >= 0) && (x < sterosc.bmapdatawidth) && (y >= 0) && (y < sterosc.bmapdataheight))
                    {
                        int ofs = y * sterosc.bmapdatawidth + x;
                        if (stereomap[ofs] < 100) stereomap[ofs] = 600; else stereomap[ofs] += 5;
                    }
                }

                for (int y = 0; y < sterosc.bmapdataheight; y++)
                {
                    int tgt_ofs = y * sterosc.bmapdatastrd;
                    int src_ofs = y * sterosc.bmapdatawidth;
                    for (int x = 0; x < sterosc.bmapdatawidth; x++)
                    {
                        if (stereomap[src_ofs] >= 1000)
                        {
                        }
                        if (stereomap[src_ofs] >= 1000)
                        {
                            sterosc.bmapdata[tgt_ofs] = osc_stereo_table.BLUE[999]; tgt_ofs++;
                            sterosc.bmapdata[tgt_ofs] = osc_stereo_table.GREEN[999]; tgt_ofs++;
                            sterosc.bmapdata[tgt_ofs] = osc_stereo_table.RED[999]; tgt_ofs++;
                            tgt_ofs++;
                            src_ofs++;
                        }
                        else
                        {
                            sterosc.bmapdata[tgt_ofs] = osc_stereo_table.BLUE[stereomap[src_ofs]]; tgt_ofs++;
                            sterosc.bmapdata[tgt_ofs] = osc_stereo_table.GREEN[stereomap[src_ofs]]; tgt_ofs++;
                            sterosc.bmapdata[tgt_ofs] = osc_stereo_table.RED[stereomap[src_ofs]]; tgt_ofs++;
                            tgt_ofs++;
                            src_ofs++;
                        }
                    }

                }
            }

            if (pwr_on)
            {
                double pl,pr;
                pl=pr=0;
                for (int i = 1; i < 1200; i++)
                {
                    pl += sqr(waveproc.buffer[waveproc.buf_rd].fftl2[i] * pwr_filter.w[i]);
                    pr += sqr(waveproc.buffer[waveproc.buf_rd].fftr2[i] * pwr_filter.w[i]);
                }

                if (pl > 0)
                    pl = 10.0 * Math.Log10(pl)+waveproc.pwr_cf;
                else
                    pl = -150.0;
                if (pl < -150) pl = -150;

                if (pr > 0)
                    pr = 10.0 * Math.Log10(pr) + waveproc.pwr_cf;
                else
                    pr = -150.0;
                if (pr < -150) pr = -150;

                plraw = pl;
                prraw = pr;

                if (cal_active)
                {
                    pl = pl - cal_raw + cal_tgt;
                    pr = pr - cal_raw + cal_tgt;
                }

                if (sctr % 4 == 0)
                {
                    pwr_l_val.Text = String.Format("{0:0.0}", pl);
                    pwr_r_val.Text = String.Format("{0:0.0}", pr);
                }

                int fl, fr;
                fl = (int)Math.Floor(pl - pwr_ref_level -1 + 0.5);
                fr = (int)Math.Floor(pr - pwr_ref_level -1 + 0.5);

                if (fl_max > 0) fl_max--;
                if (fr_max > 0) fr_max--;

                if (fl > fl_max) fl_max = fl;
                if (fr > fr_max) fr_max = fr;

                for (int i = 0; i < 100; i++)
                {
                    int cr, cg;
                    cr = cg = 0;
                    if (i < 80)
                    {
                        if (i <= fl) cg = 255; else cg = 80;
                        if (i == fl_max) cg = 255;
                    }
                    else if (i < 95)
                    {
                        if (i <= fl) cr = cg = 255; else cr = cg = 80;
                        if (i == fl_max) cr = cg = 255;
                    }
                    else
                    {
                        if (i <= fl) cr = 255; else cr = 80;
                        if (i == fl_max) cr = 255;
                    }
                    pwr_l.drawbox(i*10 + 1, 1, i * 10 + 8, 8, cr, cg, 0);

                    cr = cg = 0;
                    if (i < 80)
                    {
                        if (i <= fr) cg = 255; else cg = 80;
                        if (i == fr_max) cg = 255;
                    }
                    else if (i < 95)
                    {
                        if (i <= fr) cr = cg = 255; else cr = cg = 80;
                        if (i == fr_max) cr = cg = 255;
                    }
                    else
                    {
                        if (i <= fr) cr = 255; else cr = 80;
                        if (i == fr_max) cr = 255;
                    }
                    pwr_r.drawbox(i * 10 + 1, 1, i * 10 + 8, 8, cr, cg, 0);
                }
            }

            // waveproc.buf_rd = (waveproc.buf_rd + 1) % waveproc.buffers;


                /*
                for (int i=0;i<sterosc.bmapdataheight*sterosc.bmapdatawidth;i++) 
                    stereomap[i]=stereomap[i]*7/8;

                for (int i = 0; i < 2400; i++)
                {
                    int x=2*waveproc.fullbufl[i];
                    int y=2*waveproc.fullbufr[i];
                    x=x*sterosc.bmapdatawidth/65536 + sterosc.bmapdatawidth / 2;
                    y=sterosc.bmapdataheight/2-y*sterosc.bmapdataheight/65536;
                    if (x < 0) x = 0; if (x >= sterosc.bmapdatawidth) x = sterosc.bmapdatawidth - 1;
                    if (y < 0) y = 0; if (y >= sterosc.bmapdataheight) y = sterosc.bmapdataheight - 1;
                    if (stereomap[y * sterosc.bmapdatawidth + x] < 200)
                        stereomap[y * sterosc.bmapdatawidth + x] = 200; else
                        stereomap[y * sterosc.bmapdatawidth + x] +=10;
                }
                for (int x=0;x<sterosc.bmapdatawidth;x++)
                    for (int y = 0; y < sterosc.bmapdataheight; y++)
                    {
                        int cv = stereomap[y * sterosc.bmapdatawidth + x];
                        if (cv < 0) cv = 0; if (cv >= 1000) cv = 999;
                        sterosc.SetPixel(x, y, coltab_r[cv], coltab_g[cv], coltab_b[cv]);
                    }
                sterosc.actualize();
                 */


        }

        int fl_max = 0;
        int fr_max = 0;
        int subctr = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            int maxcall = 5;
            while ((waveproc.buf_rd != waveproc.buf_wr) && (maxcall >= 0))
            {
                if (playing)
                    update_audio(subctr);
                subctr++;
                if (subctr >= 20) subctr = 0;
                // Purge
                waveproc.buf_rd=(waveproc.buf_rd+1) % waveproc.buffers;
                maxcall--;
            }

            if (fft_stream_on)
                fftstream.actualize();
            if (fft_spek_on)
                fftdisp.actualize();
            if (osc_on)
            {
                osc.actualize();
                sterosc.actualize();
            }
            if (pwr_on)
            {
                pwr_l.actualize();
                pwr_r.actualize();
            }

        }

        private void mainwin_FormClosing(object sender, FormClosingEventArgs e)
        {
            closing = true;
            waveproc.stop();
            test_tone_out.stop();
        }

        private void fft_stream_onoff_CheckedChanged(object sender, EventArgs e)
        {
            setup_window();
        }

        private void fft_spek_onoff_CheckedChanged(object sender, EventArgs e)
        {
            setup_window();
        }

        private void osc_onoff_CheckedChanged(object sender, EventArgs e)
        {
            setup_window();
        }

        private void log_onoff_CheckedChanged(object sender, EventArgs e)
        {
            setup_window();
        }

        private void config_onoff_CheckedChanged(object sender, EventArgs e)
        {
            setup_window();
        }

        private void pwr_onoff_CheckedChanged(object sender, EventArgs e)
        {
            setup_window();
        }

        private void test_tone_onoff_CheckedChanged(object sender, EventArgs e)
        {
            setup_window();
        }


        private void fft_stream_gain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (fft_stream_gain.SelectedIndex)
            {
                default:
                case 0: fft_sel_stream_gain = 0.0; break;
                case 1: fft_sel_stream_gain = 6.0; break;
                case 2: fft_sel_stream_gain = 10.0; break;
                case 3: fft_sel_stream_gain = 20.0; break;
                case 4: fft_sel_stream_gain = 30.0; break;
                case 5: fft_sel_stream_gain = 40.0; break;
                case 6: fft_sel_stream_gain = 60.0; break;
            }

        }

        private void fft_spek_gain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (fft_spek_gain.SelectedIndex)
            {
                default:
                case 0: fft_sel_spek_gain = 0.0; break;
                case 1: fft_sel_spek_gain = 6.0; break;
                case 2: fft_sel_spek_gain = 10.0; break;
                case 3: fft_sel_spek_gain = 20.0; break;
                case 4: fft_sel_spek_gain = 30.0; break;
                case 5: fft_sel_spek_gain = 40.0; break;
                case 6: fft_sel_spek_gain = 60.0; break;
            }
            update_fft_spek_vert_axis();
        }

        private void fft_source_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (fft_source.SelectedIndex)
            {
                default:
                case 0: fft_sel_source = 0; break;
                case 1: fft_sel_source = 1; break;
                case 2: fft_sel_source = 2; break;
            }
        }

        private void osc_gain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (osc_gain.SelectedIndex) 
            {
                default:
                case 0: osc_sel_gain = 1; break;
                case 1: osc_sel_gain = 2; break;
                case 2: osc_sel_gain = 3; break;
                case 3: osc_sel_gain = 10; break;
                case 4: osc_sel_gain = 32; break;
                case 5: osc_sel_gain = 100; break;
                case 6: osc_sel_gain = 1000; break;
            }
            update_osc_vert_axis();
        }

        private void pwr_int_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            pwr_filter.update_to((filter_type) pwr_int_filter.SelectedIndex);
            pwr_unit = get_pwr_filter_unit();
            pwr_l_unit.Text = pwr_unit;
            pwr_r_unit.Text = pwr_unit;
            update_pwr_horz_axis();
            cal_unit_label.Text = get_pwr_filter_unit("dBFS") + " =";
        }

        private void fft_window_func_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (fft_window_func.SelectedIndex)
            {
                default:
                case 0: waveproc.set_window(fft.window_type.flat); break;
                case 1: waveproc.set_window(fft.window_type.hann); break;
                case 2: waveproc.set_window(fft.window_type.hamming); break;
                case 3: waveproc.set_window(fft.window_type.blackman); break;
            }

        }

        private void mainwin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void bkgbx_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

        }

        private void quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void do_pickL_Click(object sender, EventArgs e)
        {
            cal_refmeas.Value = (Decimal) plraw;
        }

        private void do_pickR_Click(object sender, EventArgs e)
        {
            cal_refmeas.Value = (Decimal) prraw;
        }

        private void update_pwr_units()
        {
            pwr_unit = get_pwr_filter_unit();
            pwr_l_unit.Text = pwr_unit;
            pwr_r_unit.Text = pwr_unit;
            update_pwr_horz_axis();
        }

        private void do_calibrate_Click(object sender, EventArgs e)
        {
            if (cal_active)
            {
                // Switch it off
                cal_active = false;
                do_calibrate.Text = "Calibrate";
            }
            else
            {
                do_calibrate.Text = "Calibrate Off";
                cal_raw = Decimal.ToDouble(cal_refmeas.Value);
                cal_tgt = Decimal.ToDouble(cal_refset.Value);
                switch (cal_unit.SelectedIndex)
                {
                    default:
                    case 0: cal_ut = "dBV"; break;
                    case 1: cal_ut = "dBm"; break;
                    case 2: cal_ut = "dBPa"; break;
                    case 3: cal_ut = "dBSPL"; break;
                }
                cal_active = true;
            }
            update_pwr_horz_axis();
            update_pwr_units();
            update_fft_spek_vert_axis();
        }


        private void en_testtone_CheckedChanged(object sender, EventArgs e)
        {
            waveproc.testtone = en_testtone.Checked;
        }

        private void testtone_amp_ValueChanged(object sender, EventArgs e)
        {
            waveproc.testtone_amp = Math.Pow(10.0,Decimal.ToDouble(testtone_amp.Value)/20);
        }

        private void testtone_freq_ValueChanged(object sender, EventArgs e)
        {
            waveproc.testtone_freq = Decimal.ToDouble(testtone_freq.Value);
        }

        private void fft_stream_color_TextChanged(object sender, EventArgs e)
        {
            color_table t = new color_table(1000, fft_stream_color.Text);
            fft_stream_table = t;

        }

        private void fft_spek_color_TextChanged(object sender, EventArgs e)
        {
            color_table t = new color_table(fftdisp.bmapdataheight, fft_spek_color.Text);
            fft_spek_table = t;
        }

        private void osc_color_TextChanged(object sender, EventArgs e)
        {
            color_table t = new color_table(1000, osc_color.Text);
            osc_stereo_table = t;
        }

        private void test_tone_connect_Click(object sender, EventArgs e)
        {
            if (test_tone_connected)
            {
                if (test_tone_active)
                {
                    test_tone_active = false;
                    test_tone_connect.Text = "Play";
                    test_tone_out.setup.on = false;
                }
                else
                {
                    test_tone_active = true;
                    test_tone_connect.Text = "Pause";
                    test_tone_out.setup.on = true;
                }
            } else {
                if (test_tone_devs.SelectedIndex < 0) return;
                test_tone_out.start(test_tone_devs.SelectedIndex);
                test_tone_devs.Visible = false;
                test_tone_connected = true;
                test_tone_connect.Text = "Pause";
                test_tone_active = true;
                test_tone_out_dev.Text = (String)test_tone_devs.Items[test_tone_devs.SelectedIndex];
                test_tone_out_dev.Visible = true;
            }

        }

        private void test_tone_amp_ValueChanged(object sender, EventArgs e)
        {
            test_tone_out.setup.amp = Math.Pow(10.0, Decimal.ToDouble(test_tone_amp.Value) / 20);
        }

        private void test_tone_freq_ValueChanged(object sender, EventArgs e)
        {
            test_tone_out.setup.freq = Decimal.ToDouble(test_tone_freq.Value);
        }

        private void test_tone_waveform_SelectedIndexChanged(object sender, EventArgs e)
        {
            test_tone_out.setup.func = (func_form)test_tone_waveform.SelectedIndex;
        }

        private void test_tone_fsweep_CheckedChanged(object sender, EventArgs e)
        {
            test_tone_out.setup.fsweep = test_tone_fsweep.Checked;
        }

        private void test_tone_freqstop_ValueChanged(object sender, EventArgs e)
        {
            test_tone_out.setup.freqend = Decimal.ToDouble(test_tone_freqstop.Value);
        }

        private void test_tone_sweep_time_ValueChanged(object sender, EventArgs e)
        {
            test_tone_out.setup.sweeptime = Decimal.ToDouble(test_tone_sweep_time.Value);
        }

        private void osc_circ_ofs_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (osc_circ_ofs.SelectedIndex)
            {
                case 0:
                    addCircOfsF = 0;
                    addCircOfsPhi = 0;
                    break;
                case 1: addCircOfsF = 6.875; break;
                case 2: addCircOfsF = 13.75; break;
                case 3: addCircOfsF = 27.5; break;
                case 4: addCircOfsF = 55; break;
                case 5: addCircOfsF = 110; break;
                case 6: addCircOfsF = 220; break;
                case 7: addCircOfsF = 440; break;
                case 8: addCircOfsF = 880; break;
            }
        }

        private void test_tone_logsweep_CheckedChanged(object sender, EventArgs e)
        {
            test_tone_out.setup.logsweep = test_tone_logsweep.Checked;

        }

        private void test_tone_updown_CheckedChanged(object sender, EventArgs e)
        {
            test_tone_out.setup.updown = test_tone_updown.Checked;
        }

        private void test_tone_pw_ValueChanged(object sender, EventArgs e)
        {
            test_tone_out.setup.pulsewidth = Decimal.ToDouble(test_tone_pw.Value) / 100.0;
        }

        private void test_tone_mod_SelectedIndexChanged(object sender, EventArgs e)
        {
            test_tone_out.setup.modulate = (mod_type)test_tone_mod.SelectedIndex;
        }

        private void test_tone_modform_SelectedIndexChanged(object sender, EventArgs e)
        {
            test_tone_out.setup.modfunc=(func_form)test_tone_modform.SelectedIndex;    
        }

        private void test_tone_modfreq_ValueChanged(object sender, EventArgs e)
        {
            test_tone_out.setup.modfreq=Decimal.ToDouble(test_tone_modfreq.Value);
        }

        private void test_tone_modamp_ValueChanged(object sender, EventArgs e)
        {
            test_tone_out.setup.modamp=Decimal.ToDouble(test_tone_modamp.Value);        
        }








    }
}
