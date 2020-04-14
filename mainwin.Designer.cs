namespace audio_test
{
    partial class mainwin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainwin));
            this.Connect = new System.Windows.Forms.Button();
            this.audioDevs = new System.Windows.Forms.ComboBox();
            this.fft_stream_display = new System.Windows.Forms.PictureBox();
            this.LOG = new System.Windows.Forms.TextBox();
            this.fft_spek_display = new System.Windows.Forms.PictureBox();
            this.osc_wave_display = new System.Windows.Forms.PictureBox();
            this.osc_stereo_display = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.fft_source = new System.Windows.Forms.ComboBox();
            this.fft_source_label = new System.Windows.Forms.Label();
            this.fft_stream_gain = new System.Windows.Forms.ComboBox();
            this.fft_stream_label = new System.Windows.Forms.Label();
            this.fft_spek_label = new System.Windows.Forms.Label();
            this.fft_spek_gain = new System.Windows.Forms.ComboBox();
            this.fft_stream_onoff = new System.Windows.Forms.CheckBox();
            this.fft_spek_onoff = new System.Windows.Forms.CheckBox();
            this.osc_onoff = new System.Windows.Forms.CheckBox();
            this.osc_gain_label = new System.Windows.Forms.Label();
            this.osc_gain = new System.Windows.Forms.ComboBox();
            this.fft_horz_axis = new System.Windows.Forms.PictureBox();
            this.fft_spek_vert_axis = new System.Windows.Forms.PictureBox();
            this.fft_stream_vert_axis = new System.Windows.Forms.PictureBox();
            this.osc_vert_axis = new System.Windows.Forms.PictureBox();
            this.osc_horz_axis = new System.Windows.Forms.PictureBox();
            this.log_onoff = new System.Windows.Forms.CheckBox();
            this.config_onoff = new System.Windows.Forms.CheckBox();
            this.pwr_l_display = new System.Windows.Forms.PictureBox();
            this.pwr_r_display = new System.Windows.Forms.PictureBox();
            this.pwr_l_val = new System.Windows.Forms.TextBox();
            this.pwr_int_filter = new System.Windows.Forms.ComboBox();
            this.pwr_int_label = new System.Windows.Forms.Label();
            this.pwr_r_val = new System.Windows.Forms.TextBox();
            this.pwr_l_unit = new System.Windows.Forms.Label();
            this.pwr_r_unit = new System.Windows.Forms.Label();
            this.pwr_horz_axis = new System.Windows.Forms.PictureBox();
            this.pwr_l_label = new System.Windows.Forms.Label();
            this.pwr_r_label = new System.Windows.Forms.Label();
            this.pwr_onoff = new System.Windows.Forms.CheckBox();
            this.fft_window_func = new System.Windows.Forms.ComboBox();
            this.quit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cal_unit = new System.Windows.Forms.ComboBox();
            this.cal_unit_label = new System.Windows.Forms.Label();
            this.cal_refset = new System.Windows.Forms.NumericUpDown();
            this.cal_refmeas = new System.Windows.Forms.NumericUpDown();
            this.do_pickR = new System.Windows.Forms.Button();
            this.do_pickL = new System.Windows.Forms.Button();
            this.do_calibrate = new System.Windows.Forms.Button();
            this.fft_stream_color = new System.Windows.Forms.ComboBox();
            this.fft_stream_label2 = new System.Windows.Forms.Label();
            this.fft_spek_label2 = new System.Windows.Forms.Label();
            this.fft_spek_color = new System.Windows.Forms.ComboBox();
            this.bkgbx = new System.Windows.Forms.PictureBox();
            this.en_testtone = new System.Windows.Forms.CheckBox();
            this.testtone_amp = new System.Windows.Forms.NumericUpDown();
            this.testtone_freq = new System.Windows.Forms.NumericUpDown();
            this.testtone_label1 = new System.Windows.Forms.Label();
            this.testtone_label2 = new System.Windows.Forms.Label();
            this.device_label = new System.Windows.Forms.Label();
            this.osc_color_label = new System.Windows.Forms.Label();
            this.osc_color = new System.Windows.Forms.ComboBox();
            this.test_tone_devs = new System.Windows.Forms.ComboBox();
            this.test_tone_connect = new System.Windows.Forms.Button();
            this.test_tone_label1 = new System.Windows.Forms.Label();
            this.test_tone_label4 = new System.Windows.Forms.Label();
            this.test_tone_label3 = new System.Windows.Forms.Label();
            this.test_tone_freq = new System.Windows.Forms.NumericUpDown();
            this.test_tone_amp = new System.Windows.Forms.NumericUpDown();
            this.test_tone_waveform = new System.Windows.Forms.ComboBox();
            this.test_tone_label2 = new System.Windows.Forms.Label();
            this.test_tone_onoff = new System.Windows.Forms.CheckBox();
            this.test_tone_out_dev = new System.Windows.Forms.Label();
            this.test_tone_fsweep = new System.Windows.Forms.CheckBox();
            this.test_tone_freqstop = new System.Windows.Forms.NumericUpDown();
            this.test_tone_label5 = new System.Windows.Forms.Label();
            this.test_tone_sweep_time = new System.Windows.Forms.NumericUpDown();
            this.test_tone_label6 = new System.Windows.Forms.Label();
            this.test_tone_logsweep = new System.Windows.Forms.CheckBox();
            this.test_tone_updown = new System.Windows.Forms.CheckBox();
            this.test_tone_label7 = new System.Windows.Forms.Label();
            this.test_tone_pw = new System.Windows.Forms.NumericUpDown();
            this.test_tone_mod = new System.Windows.Forms.ComboBox();
            this.test_tone_label8 = new System.Windows.Forms.Label();
            this.test_tone_label9 = new System.Windows.Forms.Label();
            this.test_tone_modfreq = new System.Windows.Forms.NumericUpDown();
            this.test_tone_label10 = new System.Windows.Forms.Label();
            this.test_tone_modamp = new System.Windows.Forms.NumericUpDown();
            this.test_tone_modform = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.osc_circ_ofs_label = new System.Windows.Forms.Label();
            this.osc_circ_ofs = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.fft_stream_display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fft_spek_display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osc_wave_display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osc_stereo_display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fft_horz_axis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fft_spek_vert_axis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fft_stream_vert_axis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osc_vert_axis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osc_horz_axis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwr_l_display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwr_r_display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwr_horz_axis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cal_refset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cal_refmeas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bkgbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testtone_amp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testtone_freq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_tone_freq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_tone_amp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_tone_freqstop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_tone_sweep_time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_tone_pw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_tone_modfreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_tone_modamp)).BeginInit();
            this.SuspendLayout();
            // 
            // Connect
            // 
            this.Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Connect.ForeColor = System.Drawing.Color.Lime;
            this.Connect.Location = new System.Drawing.Point(6, 6);
            this.Connect.Margin = new System.Windows.Forms.Padding(2);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(84, 27);
            this.Connect.TabIndex = 0;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // audioDevs
            // 
            this.audioDevs.BackColor = System.Drawing.Color.Black;
            this.audioDevs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audioDevs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.audioDevs.ForeColor = System.Drawing.Color.Lime;
            this.audioDevs.FormattingEnabled = true;
            this.audioDevs.Location = new System.Drawing.Point(93, 6);
            this.audioDevs.Margin = new System.Windows.Forms.Padding(2);
            this.audioDevs.Name = "audioDevs";
            this.audioDevs.Size = new System.Drawing.Size(302, 21);
            this.audioDevs.TabIndex = 1;
            // 
            // fft_stream_display
            // 
            this.fft_stream_display.Location = new System.Drawing.Point(60, 72);
            this.fft_stream_display.Margin = new System.Windows.Forms.Padding(2);
            this.fft_stream_display.Name = "fft_stream_display";
            this.fft_stream_display.Size = new System.Drawing.Size(1200, 325);
            this.fft_stream_display.TabIndex = 2;
            this.fft_stream_display.TabStop = false;
            // 
            // LOG
            // 
            this.LOG.BackColor = System.Drawing.Color.White;
            this.LOG.Location = new System.Drawing.Point(6, 1141);
            this.LOG.Margin = new System.Windows.Forms.Padding(2);
            this.LOG.Multiline = true;
            this.LOG.Name = "LOG";
            this.LOG.ReadOnly = true;
            this.LOG.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LOG.Size = new System.Drawing.Size(1249, 91);
            this.LOG.TabIndex = 4;
            // 
            // fft_spek_display
            // 
            this.fft_spek_display.Location = new System.Drawing.Point(60, 405);
            this.fft_spek_display.Margin = new System.Windows.Forms.Padding(2);
            this.fft_spek_display.Name = "fft_spek_display";
            this.fft_spek_display.Size = new System.Drawing.Size(1200, 203);
            this.fft_spek_display.TabIndex = 9;
            this.fft_spek_display.TabStop = false;
            // 
            // osc_wave_display
            // 
            this.osc_wave_display.Location = new System.Drawing.Point(60, 670);
            this.osc_wave_display.Margin = new System.Windows.Forms.Padding(2);
            this.osc_wave_display.Name = "osc_wave_display";
            this.osc_wave_display.Size = new System.Drawing.Size(996, 200);
            this.osc_wave_display.TabIndex = 10;
            this.osc_wave_display.TabStop = false;
            // 
            // osc_stereo_display
            // 
            this.osc_stereo_display.Location = new System.Drawing.Point(1060, 670);
            this.osc_stereo_display.Margin = new System.Windows.Forms.Padding(2);
            this.osc_stereo_display.Name = "osc_stereo_display";
            this.osc_stereo_display.Size = new System.Drawing.Size(200, 200);
            this.osc_stereo_display.TabIndex = 11;
            this.osc_stereo_display.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // fft_source
            // 
            this.fft_source.BackColor = System.Drawing.Color.Black;
            this.fft_source.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fft_source.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fft_source.ForeColor = System.Drawing.Color.Lime;
            this.fft_source.FormattingEnabled = true;
            this.fft_source.Location = new System.Drawing.Point(1268, 630);
            this.fft_source.Margin = new System.Windows.Forms.Padding(2);
            this.fft_source.Name = "fft_source";
            this.fft_source.Size = new System.Drawing.Size(123, 21);
            this.fft_source.TabIndex = 13;
            this.fft_source.SelectedIndexChanged += new System.EventHandler(this.fft_source_SelectedIndexChanged);
            // 
            // fft_source_label
            // 
            this.fft_source_label.AutoSize = true;
            this.fft_source_label.ForeColor = System.Drawing.Color.Lime;
            this.fft_source_label.Location = new System.Drawing.Point(1268, 611);
            this.fft_source_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fft_source_label.Name = "fft_source_label";
            this.fft_source_label.Size = new System.Drawing.Size(41, 13);
            this.fft_source_label.TabIndex = 14;
            this.fft_source_label.Text = "Source";
            // 
            // fft_stream_gain
            // 
            this.fft_stream_gain.BackColor = System.Drawing.Color.Black;
            this.fft_stream_gain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fft_stream_gain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fft_stream_gain.ForeColor = System.Drawing.Color.Lime;
            this.fft_stream_gain.FormattingEnabled = true;
            this.fft_stream_gain.Location = new System.Drawing.Point(1268, 91);
            this.fft_stream_gain.Margin = new System.Windows.Forms.Padding(2);
            this.fft_stream_gain.Name = "fft_stream_gain";
            this.fft_stream_gain.Size = new System.Drawing.Size(123, 21);
            this.fft_stream_gain.TabIndex = 15;
            this.fft_stream_gain.SelectedIndexChanged += new System.EventHandler(this.fft_stream_gain_SelectedIndexChanged);
            // 
            // fft_stream_label
            // 
            this.fft_stream_label.AutoSize = true;
            this.fft_stream_label.ForeColor = System.Drawing.Color.Lime;
            this.fft_stream_label.Location = new System.Drawing.Point(1268, 72);
            this.fft_stream_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fft_stream_label.Name = "fft_stream_label";
            this.fft_stream_label.Size = new System.Drawing.Size(29, 13);
            this.fft_stream_label.TabIndex = 16;
            this.fft_stream_label.Text = "Gain";
            // 
            // fft_spek_label
            // 
            this.fft_spek_label.AutoSize = true;
            this.fft_spek_label.ForeColor = System.Drawing.Color.Lime;
            this.fft_spek_label.Location = new System.Drawing.Point(1270, 405);
            this.fft_spek_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fft_spek_label.Name = "fft_spek_label";
            this.fft_spek_label.Size = new System.Drawing.Size(29, 13);
            this.fft_spek_label.TabIndex = 20;
            this.fft_spek_label.Text = "Gain";
            // 
            // fft_spek_gain
            // 
            this.fft_spek_gain.BackColor = System.Drawing.Color.Black;
            this.fft_spek_gain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fft_spek_gain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fft_spek_gain.ForeColor = System.Drawing.Color.Lime;
            this.fft_spek_gain.FormattingEnabled = true;
            this.fft_spek_gain.Location = new System.Drawing.Point(1268, 424);
            this.fft_spek_gain.Margin = new System.Windows.Forms.Padding(2);
            this.fft_spek_gain.Name = "fft_spek_gain";
            this.fft_spek_gain.Size = new System.Drawing.Size(123, 21);
            this.fft_spek_gain.TabIndex = 19;
            this.fft_spek_gain.SelectedIndexChanged += new System.EventHandler(this.fft_spek_gain_SelectedIndexChanged);
            // 
            // fft_stream_onoff
            // 
            this.fft_stream_onoff.AutoSize = true;
            this.fft_stream_onoff.Checked = true;
            this.fft_stream_onoff.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fft_stream_onoff.ForeColor = System.Drawing.Color.Lime;
            this.fft_stream_onoff.Location = new System.Drawing.Point(149, 41);
            this.fft_stream_onoff.Margin = new System.Windows.Forms.Padding(2);
            this.fft_stream_onoff.Name = "fft_stream_onoff";
            this.fft_stream_onoff.Size = new System.Drawing.Size(81, 17);
            this.fft_stream_onoff.TabIndex = 24;
            this.fft_stream_onoff.Text = "FFT Stream";
            this.fft_stream_onoff.UseVisualStyleBackColor = true;
            this.fft_stream_onoff.CheckedChanged += new System.EventHandler(this.fft_stream_onoff_CheckedChanged);
            // 
            // fft_spek_onoff
            // 
            this.fft_spek_onoff.AutoSize = true;
            this.fft_spek_onoff.Checked = true;
            this.fft_spek_onoff.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fft_spek_onoff.ForeColor = System.Drawing.Color.Lime;
            this.fft_spek_onoff.Location = new System.Drawing.Point(257, 41);
            this.fft_spek_onoff.Margin = new System.Windows.Forms.Padding(2);
            this.fft_spek_onoff.Name = "fft_spek_onoff";
            this.fft_spek_onoff.Size = new System.Drawing.Size(93, 17);
            this.fft_spek_onoff.TabIndex = 25;
            this.fft_spek_onoff.Text = "FFT Spektrum";
            this.fft_spek_onoff.UseVisualStyleBackColor = true;
            this.fft_spek_onoff.CheckedChanged += new System.EventHandler(this.fft_spek_onoff_CheckedChanged);
            // 
            // osc_onoff
            // 
            this.osc_onoff.AutoSize = true;
            this.osc_onoff.Checked = true;
            this.osc_onoff.CheckState = System.Windows.Forms.CheckState.Checked;
            this.osc_onoff.ForeColor = System.Drawing.Color.Lime;
            this.osc_onoff.Location = new System.Drawing.Point(380, 41);
            this.osc_onoff.Margin = new System.Windows.Forms.Padding(2);
            this.osc_onoff.Name = "osc_onoff";
            this.osc_onoff.Size = new System.Drawing.Size(86, 17);
            this.osc_onoff.TabIndex = 26;
            this.osc_onoff.Text = "Oscilloscope";
            this.osc_onoff.UseVisualStyleBackColor = true;
            this.osc_onoff.CheckedChanged += new System.EventHandler(this.osc_onoff_CheckedChanged);
            // 
            // osc_gain_label
            // 
            this.osc_gain_label.AutoSize = true;
            this.osc_gain_label.ForeColor = System.Drawing.Color.Lime;
            this.osc_gain_label.Location = new System.Drawing.Point(1268, 670);
            this.osc_gain_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.osc_gain_label.Name = "osc_gain_label";
            this.osc_gain_label.Size = new System.Drawing.Size(29, 13);
            this.osc_gain_label.TabIndex = 28;
            this.osc_gain_label.Text = "Gain";
            // 
            // osc_gain
            // 
            this.osc_gain.BackColor = System.Drawing.Color.Black;
            this.osc_gain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.osc_gain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.osc_gain.ForeColor = System.Drawing.Color.Lime;
            this.osc_gain.FormattingEnabled = true;
            this.osc_gain.Location = new System.Drawing.Point(1268, 689);
            this.osc_gain.Margin = new System.Windows.Forms.Padding(2);
            this.osc_gain.Name = "osc_gain";
            this.osc_gain.Size = new System.Drawing.Size(123, 21);
            this.osc_gain.TabIndex = 27;
            this.osc_gain.SelectedIndexChanged += new System.EventHandler(this.osc_gain_SelectedIndexChanged);
            // 
            // fft_horz_axis
            // 
            this.fft_horz_axis.BackColor = System.Drawing.Color.Black;
            this.fft_horz_axis.Location = new System.Drawing.Point(60, 611);
            this.fft_horz_axis.Margin = new System.Windows.Forms.Padding(2);
            this.fft_horz_axis.Name = "fft_horz_axis";
            this.fft_horz_axis.Size = new System.Drawing.Size(1200, 50);
            this.fft_horz_axis.TabIndex = 29;
            this.fft_horz_axis.TabStop = false;
            // 
            // fft_spek_vert_axis
            // 
            this.fft_spek_vert_axis.BackColor = System.Drawing.Color.Black;
            this.fft_spek_vert_axis.Location = new System.Drawing.Point(6, 405);
            this.fft_spek_vert_axis.Margin = new System.Windows.Forms.Padding(2);
            this.fft_spek_vert_axis.Name = "fft_spek_vert_axis";
            this.fft_spek_vert_axis.Size = new System.Drawing.Size(50, 203);
            this.fft_spek_vert_axis.TabIndex = 30;
            this.fft_spek_vert_axis.TabStop = false;
            // 
            // fft_stream_vert_axis
            // 
            this.fft_stream_vert_axis.BackColor = System.Drawing.Color.Black;
            this.fft_stream_vert_axis.Location = new System.Drawing.Point(6, 72);
            this.fft_stream_vert_axis.Margin = new System.Windows.Forms.Padding(2);
            this.fft_stream_vert_axis.Name = "fft_stream_vert_axis";
            this.fft_stream_vert_axis.Size = new System.Drawing.Size(50, 325);
            this.fft_stream_vert_axis.TabIndex = 31;
            this.fft_stream_vert_axis.TabStop = false;
            // 
            // osc_vert_axis
            // 
            this.osc_vert_axis.BackColor = System.Drawing.Color.Black;
            this.osc_vert_axis.Location = new System.Drawing.Point(6, 670);
            this.osc_vert_axis.Margin = new System.Windows.Forms.Padding(2);
            this.osc_vert_axis.Name = "osc_vert_axis";
            this.osc_vert_axis.Size = new System.Drawing.Size(50, 200);
            this.osc_vert_axis.TabIndex = 33;
            this.osc_vert_axis.TabStop = false;
            // 
            // osc_horz_axis
            // 
            this.osc_horz_axis.BackColor = System.Drawing.Color.Black;
            this.osc_horz_axis.Location = new System.Drawing.Point(60, 874);
            this.osc_horz_axis.Margin = new System.Windows.Forms.Padding(2);
            this.osc_horz_axis.Name = "osc_horz_axis";
            this.osc_horz_axis.Size = new System.Drawing.Size(996, 50);
            this.osc_horz_axis.TabIndex = 34;
            this.osc_horz_axis.TabStop = false;
            // 
            // log_onoff
            // 
            this.log_onoff.AutoSize = true;
            this.log_onoff.ForeColor = System.Drawing.Color.Lime;
            this.log_onoff.Location = new System.Drawing.Point(693, 10);
            this.log_onoff.Margin = new System.Windows.Forms.Padding(2);
            this.log_onoff.Name = "log_onoff";
            this.log_onoff.Size = new System.Drawing.Size(44, 17);
            this.log_onoff.TabIndex = 35;
            this.log_onoff.Text = "Log";
            this.log_onoff.UseVisualStyleBackColor = true;
            this.log_onoff.CheckedChanged += new System.EventHandler(this.log_onoff_CheckedChanged);
            // 
            // config_onoff
            // 
            this.config_onoff.AutoSize = true;
            this.config_onoff.ForeColor = System.Drawing.Color.Lime;
            this.config_onoff.Location = new System.Drawing.Point(693, 41);
            this.config_onoff.Margin = new System.Windows.Forms.Padding(2);
            this.config_onoff.Name = "config_onoff";
            this.config_onoff.Size = new System.Drawing.Size(56, 17);
            this.config_onoff.TabIndex = 36;
            this.config_onoff.Text = "Config";
            this.config_onoff.UseVisualStyleBackColor = true;
            this.config_onoff.CheckedChanged += new System.EventHandler(this.config_onoff_CheckedChanged);
            // 
            // pwr_l_display
            // 
            this.pwr_l_display.Location = new System.Drawing.Point(60, 950);
            this.pwr_l_display.Margin = new System.Windows.Forms.Padding(2);
            this.pwr_l_display.Name = "pwr_l_display";
            this.pwr_l_display.Size = new System.Drawing.Size(1000, 10);
            this.pwr_l_display.TabIndex = 37;
            this.pwr_l_display.TabStop = false;
            // 
            // pwr_r_display
            // 
            this.pwr_r_display.Location = new System.Drawing.Point(60, 973);
            this.pwr_r_display.Margin = new System.Windows.Forms.Padding(2);
            this.pwr_r_display.Name = "pwr_r_display";
            this.pwr_r_display.Size = new System.Drawing.Size(1000, 10);
            this.pwr_r_display.TabIndex = 38;
            this.pwr_r_display.TabStop = false;
            // 
            // pwr_l_val
            // 
            this.pwr_l_val.BackColor = System.Drawing.Color.Black;
            this.pwr_l_val.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pwr_l_val.ForeColor = System.Drawing.Color.Lime;
            this.pwr_l_val.Location = new System.Drawing.Point(1073, 945);
            this.pwr_l_val.Margin = new System.Windows.Forms.Padding(2);
            this.pwr_l_val.Name = "pwr_l_val";
            this.pwr_l_val.ReadOnly = true;
            this.pwr_l_val.Size = new System.Drawing.Size(72, 20);
            this.pwr_l_val.TabIndex = 39;
            this.pwr_l_val.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pwr_int_filter
            // 
            this.pwr_int_filter.BackColor = System.Drawing.Color.Black;
            this.pwr_int_filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pwr_int_filter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pwr_int_filter.ForeColor = System.Drawing.Color.Lime;
            this.pwr_int_filter.FormattingEnabled = true;
            this.pwr_int_filter.Location = new System.Drawing.Point(1268, 964);
            this.pwr_int_filter.Margin = new System.Windows.Forms.Padding(2);
            this.pwr_int_filter.Name = "pwr_int_filter";
            this.pwr_int_filter.Size = new System.Drawing.Size(120, 21);
            this.pwr_int_filter.TabIndex = 40;
            this.pwr_int_filter.SelectedIndexChanged += new System.EventHandler(this.pwr_int_filter_SelectedIndexChanged);
            // 
            // pwr_int_label
            // 
            this.pwr_int_label.AutoSize = true;
            this.pwr_int_label.ForeColor = System.Drawing.Color.Lime;
            this.pwr_int_label.Location = new System.Drawing.Point(1268, 945);
            this.pwr_int_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pwr_int_label.Name = "pwr_int_label";
            this.pwr_int_label.Size = new System.Drawing.Size(82, 13);
            this.pwr_int_label.TabIndex = 41;
            this.pwr_int_label.Text = "Integration Filter";
            // 
            // pwr_r_val
            // 
            this.pwr_r_val.BackColor = System.Drawing.Color.Black;
            this.pwr_r_val.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pwr_r_val.ForeColor = System.Drawing.Color.Lime;
            this.pwr_r_val.Location = new System.Drawing.Point(1073, 967);
            this.pwr_r_val.Margin = new System.Windows.Forms.Padding(2);
            this.pwr_r_val.Name = "pwr_r_val";
            this.pwr_r_val.ReadOnly = true;
            this.pwr_r_val.Size = new System.Drawing.Size(72, 20);
            this.pwr_r_val.TabIndex = 42;
            this.pwr_r_val.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pwr_l_unit
            // 
            this.pwr_l_unit.AutoSize = true;
            this.pwr_l_unit.ForeColor = System.Drawing.Color.Lime;
            this.pwr_l_unit.Location = new System.Drawing.Point(1148, 947);
            this.pwr_l_unit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pwr_l_unit.Name = "pwr_l_unit";
            this.pwr_l_unit.Size = new System.Drawing.Size(33, 13);
            this.pwr_l_unit.TabIndex = 43;
            this.pwr_l_unit.Text = "dBFS";
            // 
            // pwr_r_unit
            // 
            this.pwr_r_unit.AutoSize = true;
            this.pwr_r_unit.ForeColor = System.Drawing.Color.Lime;
            this.pwr_r_unit.Location = new System.Drawing.Point(1148, 970);
            this.pwr_r_unit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pwr_r_unit.Name = "pwr_r_unit";
            this.pwr_r_unit.Size = new System.Drawing.Size(33, 13);
            this.pwr_r_unit.TabIndex = 44;
            this.pwr_r_unit.Text = "dBFS";
            // 
            // pwr_horz_axis
            // 
            this.pwr_horz_axis.BackColor = System.Drawing.Color.Black;
            this.pwr_horz_axis.Location = new System.Drawing.Point(60, 986);
            this.pwr_horz_axis.Margin = new System.Windows.Forms.Padding(2);
            this.pwr_horz_axis.Name = "pwr_horz_axis";
            this.pwr_horz_axis.Size = new System.Drawing.Size(1000, 50);
            this.pwr_horz_axis.TabIndex = 45;
            this.pwr_horz_axis.TabStop = false;
            // 
            // pwr_l_label
            // 
            this.pwr_l_label.AutoSize = true;
            this.pwr_l_label.ForeColor = System.Drawing.Color.Lime;
            this.pwr_l_label.Location = new System.Drawing.Point(37, 947);
            this.pwr_l_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pwr_l_label.Name = "pwr_l_label";
            this.pwr_l_label.Size = new System.Drawing.Size(13, 13);
            this.pwr_l_label.TabIndex = 46;
            this.pwr_l_label.Text = "L";
            // 
            // pwr_r_label
            // 
            this.pwr_r_label.AutoSize = true;
            this.pwr_r_label.ForeColor = System.Drawing.Color.Lime;
            this.pwr_r_label.Location = new System.Drawing.Point(37, 970);
            this.pwr_r_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pwr_r_label.Name = "pwr_r_label";
            this.pwr_r_label.Size = new System.Drawing.Size(15, 13);
            this.pwr_r_label.TabIndex = 47;
            this.pwr_r_label.Text = "R";
            // 
            // pwr_onoff
            // 
            this.pwr_onoff.AutoSize = true;
            this.pwr_onoff.Checked = true;
            this.pwr_onoff.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pwr_onoff.ForeColor = System.Drawing.Color.Lime;
            this.pwr_onoff.Location = new System.Drawing.Point(494, 41);
            this.pwr_onoff.Margin = new System.Windows.Forms.Padding(2);
            this.pwr_onoff.Name = "pwr_onoff";
            this.pwr_onoff.Size = new System.Drawing.Size(56, 17);
            this.pwr_onoff.TabIndex = 48;
            this.pwr_onoff.Text = "Power";
            this.pwr_onoff.UseVisualStyleBackColor = true;
            this.pwr_onoff.CheckedChanged += new System.EventHandler(this.pwr_onoff_CheckedChanged);
            // 
            // fft_window_func
            // 
            this.fft_window_func.BackColor = System.Drawing.Color.Black;
            this.fft_window_func.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fft_window_func.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fft_window_func.ForeColor = System.Drawing.Color.Lime;
            this.fft_window_func.FormattingEnabled = true;
            this.fft_window_func.Location = new System.Drawing.Point(504, 7);
            this.fft_window_func.Margin = new System.Windows.Forms.Padding(2);
            this.fft_window_func.Name = "fft_window_func";
            this.fft_window_func.Size = new System.Drawing.Size(92, 21);
            this.fft_window_func.TabIndex = 49;
            this.fft_window_func.SelectedIndexChanged += new System.EventHandler(this.fft_window_func_SelectedIndexChanged);
            // 
            // quit
            // 
            this.quit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.quit.BackColor = System.Drawing.Color.Red;
            this.quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quit.ForeColor = System.Drawing.Color.White;
            this.quit.Location = new System.Drawing.Point(1361, 1);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(40, 30);
            this.quit.TabIndex = 50;
            this.quit.Text = "X";
            this.quit.UseVisualStyleBackColor = false;
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(413, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "FFT Window";
            // 
            // cal_unit
            // 
            this.cal_unit.BackColor = System.Drawing.Color.Black;
            this.cal_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cal_unit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cal_unit.ForeColor = System.Drawing.Color.Lime;
            this.cal_unit.FormattingEnabled = true;
            this.cal_unit.Location = new System.Drawing.Point(1142, 39);
            this.cal_unit.Name = "cal_unit";
            this.cal_unit.Size = new System.Drawing.Size(75, 21);
            this.cal_unit.TabIndex = 52;
            // 
            // cal_unit_label
            // 
            this.cal_unit_label.AutoSize = true;
            this.cal_unit_label.ForeColor = System.Drawing.Color.Lime;
            this.cal_unit_label.Location = new System.Drawing.Point(983, 42);
            this.cal_unit_label.Name = "cal_unit_label";
            this.cal_unit_label.Size = new System.Drawing.Size(55, 13);
            this.cal_unit_label.TabIndex = 53;
            this.cal_unit_label.Text = "dBFS(A) =";
            // 
            // cal_refset
            // 
            this.cal_refset.DecimalPlaces = 2;
            this.cal_refset.Location = new System.Drawing.Point(1074, 40);
            this.cal_refset.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.cal_refset.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.cal_refset.Name = "cal_refset";
            this.cal_refset.Size = new System.Drawing.Size(62, 20);
            this.cal_refset.TabIndex = 54;
            this.cal_refset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cal_refmeas
            // 
            this.cal_refmeas.DecimalPlaces = 2;
            this.cal_refmeas.Location = new System.Drawing.Point(916, 40);
            this.cal_refmeas.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.cal_refmeas.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.cal_refmeas.Name = "cal_refmeas";
            this.cal_refmeas.Size = new System.Drawing.Size(62, 20);
            this.cal_refmeas.TabIndex = 55;
            this.cal_refmeas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // do_pickR
            // 
            this.do_pickR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do_pickR.ForeColor = System.Drawing.Color.Lime;
            this.do_pickR.Location = new System.Drawing.Point(849, 37);
            this.do_pickR.Name = "do_pickR";
            this.do_pickR.Size = new System.Drawing.Size(62, 27);
            this.do_pickR.TabIndex = 56;
            this.do_pickR.Text = "Pick R";
            this.do_pickR.UseVisualStyleBackColor = true;
            this.do_pickR.Click += new System.EventHandler(this.do_pickR_Click);
            // 
            // do_pickL
            // 
            this.do_pickL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do_pickL.ForeColor = System.Drawing.Color.Lime;
            this.do_pickL.Location = new System.Drawing.Point(784, 37);
            this.do_pickL.Name = "do_pickL";
            this.do_pickL.Size = new System.Drawing.Size(62, 27);
            this.do_pickL.TabIndex = 57;
            this.do_pickL.Text = "Pick L";
            this.do_pickL.UseVisualStyleBackColor = true;
            this.do_pickL.Click += new System.EventHandler(this.do_pickL_Click);
            // 
            // do_calibrate
            // 
            this.do_calibrate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do_calibrate.ForeColor = System.Drawing.Color.Lime;
            this.do_calibrate.Location = new System.Drawing.Point(784, 6);
            this.do_calibrate.Name = "do_calibrate";
            this.do_calibrate.Size = new System.Drawing.Size(433, 27);
            this.do_calibrate.TabIndex = 58;
            this.do_calibrate.Text = "Calibrate";
            this.do_calibrate.UseVisualStyleBackColor = true;
            this.do_calibrate.Click += new System.EventHandler(this.do_calibrate_Click);
            // 
            // fft_stream_color
            // 
            this.fft_stream_color.BackColor = System.Drawing.Color.Black;
            this.fft_stream_color.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fft_stream_color.ForeColor = System.Drawing.Color.Lime;
            this.fft_stream_color.FormattingEnabled = true;
            this.fft_stream_color.Location = new System.Drawing.Point(1268, 143);
            this.fft_stream_color.Name = "fft_stream_color";
            this.fft_stream_color.Size = new System.Drawing.Size(123, 21);
            this.fft_stream_color.TabIndex = 59;
            this.fft_stream_color.TextChanged += new System.EventHandler(this.fft_stream_color_TextChanged);
            // 
            // fft_stream_label2
            // 
            this.fft_stream_label2.AutoSize = true;
            this.fft_stream_label2.ForeColor = System.Drawing.Color.Lime;
            this.fft_stream_label2.Location = new System.Drawing.Point(1268, 123);
            this.fft_stream_label2.Name = "fft_stream_label2";
            this.fft_stream_label2.Size = new System.Drawing.Size(31, 13);
            this.fft_stream_label2.TabIndex = 60;
            this.fft_stream_label2.Text = "Color";
            // 
            // fft_spek_label2
            // 
            this.fft_spek_label2.AutoSize = true;
            this.fft_spek_label2.ForeColor = System.Drawing.Color.Lime;
            this.fft_spek_label2.Location = new System.Drawing.Point(1268, 461);
            this.fft_spek_label2.Name = "fft_spek_label2";
            this.fft_spek_label2.Size = new System.Drawing.Size(31, 13);
            this.fft_spek_label2.TabIndex = 62;
            this.fft_spek_label2.Text = "Color";
            // 
            // fft_spek_color
            // 
            this.fft_spek_color.BackColor = System.Drawing.Color.Black;
            this.fft_spek_color.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fft_spek_color.ForeColor = System.Drawing.Color.Lime;
            this.fft_spek_color.FormattingEnabled = true;
            this.fft_spek_color.Location = new System.Drawing.Point(1268, 481);
            this.fft_spek_color.Name = "fft_spek_color";
            this.fft_spek_color.Size = new System.Drawing.Size(123, 21);
            this.fft_spek_color.TabIndex = 61;
            this.fft_spek_color.TextChanged += new System.EventHandler(this.fft_spek_color_TextChanged);
            // 
            // bkgbx
            // 
            this.bkgbx.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.bkgbx.Location = new System.Drawing.Point(0, 0);
            this.bkgbx.Name = "bkgbx";
            this.bkgbx.Size = new System.Drawing.Size(10, 10);
            this.bkgbx.TabIndex = 64;
            this.bkgbx.TabStop = false;
            this.bkgbx.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bkgbx_MouseDown);
            // 
            // en_testtone
            // 
            this.en_testtone.AutoSize = true;
            this.en_testtone.ForeColor = System.Drawing.Color.Lime;
            this.en_testtone.Location = new System.Drawing.Point(1271, 1149);
            this.en_testtone.Name = "en_testtone";
            this.en_testtone.Size = new System.Drawing.Size(74, 17);
            this.en_testtone.TabIndex = 65;
            this.en_testtone.Text = "Rec Tone";
            this.en_testtone.UseVisualStyleBackColor = true;
            this.en_testtone.CheckedChanged += new System.EventHandler(this.en_testtone_CheckedChanged);
            // 
            // testtone_amp
            // 
            this.testtone_amp.DecimalPlaces = 1;
            this.testtone_amp.Location = new System.Drawing.Point(1336, 1176);
            this.testtone_amp.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.testtone_amp.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.testtone_amp.Name = "testtone_amp";
            this.testtone_amp.Size = new System.Drawing.Size(55, 20);
            this.testtone_amp.TabIndex = 66;
            this.testtone_amp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.testtone_amp.ValueChanged += new System.EventHandler(this.testtone_amp_ValueChanged);
            // 
            // testtone_freq
            // 
            this.testtone_freq.DecimalPlaces = 1;
            this.testtone_freq.Location = new System.Drawing.Point(1322, 1204);
            this.testtone_freq.Maximum = new decimal(new int[] {
            24000,
            0,
            0,
            0});
            this.testtone_freq.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.testtone_freq.Name = "testtone_freq";
            this.testtone_freq.Size = new System.Drawing.Size(69, 20);
            this.testtone_freq.TabIndex = 67;
            this.testtone_freq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.testtone_freq.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.testtone_freq.ValueChanged += new System.EventHandler(this.testtone_freq_ValueChanged);
            // 
            // testtone_label1
            // 
            this.testtone_label1.AutoSize = true;
            this.testtone_label1.ForeColor = System.Drawing.Color.Lime;
            this.testtone_label1.Location = new System.Drawing.Point(1268, 1178);
            this.testtone_label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.testtone_label1.Name = "testtone_label1";
            this.testtone_label1.Size = new System.Drawing.Size(49, 13);
            this.testtone_label1.TabIndex = 68;
            this.testtone_label1.Text = "A [dBFS]";
            // 
            // testtone_label2
            // 
            this.testtone_label2.AutoSize = true;
            this.testtone_label2.ForeColor = System.Drawing.Color.Lime;
            this.testtone_label2.Location = new System.Drawing.Point(1268, 1206);
            this.testtone_label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.testtone_label2.Name = "testtone_label2";
            this.testtone_label2.Size = new System.Drawing.Size(35, 13);
            this.testtone_label2.TabIndex = 69;
            this.testtone_label2.Text = "F [Hz]";
            // 
            // device_label
            // 
            this.device_label.AutoSize = true;
            this.device_label.ForeColor = System.Drawing.Color.Lime;
            this.device_label.Location = new System.Drawing.Point(95, 11);
            this.device_label.Name = "device_label";
            this.device_label.Size = new System.Drawing.Size(51, 13);
            this.device_label.TabIndex = 70;
            this.device_label.Text = "unknown";
            // 
            // osc_color_label
            // 
            this.osc_color_label.AutoSize = true;
            this.osc_color_label.ForeColor = System.Drawing.Color.Lime;
            this.osc_color_label.Location = new System.Drawing.Point(1268, 777);
            this.osc_color_label.Name = "osc_color_label";
            this.osc_color_label.Size = new System.Drawing.Size(31, 13);
            this.osc_color_label.TabIndex = 72;
            this.osc_color_label.Text = "Color";
            // 
            // osc_color
            // 
            this.osc_color.BackColor = System.Drawing.Color.Black;
            this.osc_color.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.osc_color.ForeColor = System.Drawing.Color.Lime;
            this.osc_color.FormattingEnabled = true;
            this.osc_color.Location = new System.Drawing.Point(1268, 797);
            this.osc_color.Name = "osc_color";
            this.osc_color.Size = new System.Drawing.Size(123, 21);
            this.osc_color.TabIndex = 71;
            this.osc_color.TextChanged += new System.EventHandler(this.osc_color_TextChanged);
            // 
            // test_tone_devs
            // 
            this.test_tone_devs.BackColor = System.Drawing.Color.Black;
            this.test_tone_devs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.test_tone_devs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.test_tone_devs.ForeColor = System.Drawing.Color.Lime;
            this.test_tone_devs.FormattingEnabled = true;
            this.test_tone_devs.Location = new System.Drawing.Point(94, 1077);
            this.test_tone_devs.Margin = new System.Windows.Forms.Padding(2);
            this.test_tone_devs.Name = "test_tone_devs";
            this.test_tone_devs.Size = new System.Drawing.Size(302, 21);
            this.test_tone_devs.TabIndex = 73;
            // 
            // test_tone_connect
            // 
            this.test_tone_connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.test_tone_connect.ForeColor = System.Drawing.Color.Lime;
            this.test_tone_connect.Location = new System.Drawing.Point(6, 1075);
            this.test_tone_connect.Margin = new System.Windows.Forms.Padding(2);
            this.test_tone_connect.Name = "test_tone_connect";
            this.test_tone_connect.Size = new System.Drawing.Size(84, 27);
            this.test_tone_connect.TabIndex = 74;
            this.test_tone_connect.Text = "Connect";
            this.test_tone_connect.UseVisualStyleBackColor = true;
            this.test_tone_connect.Click += new System.EventHandler(this.test_tone_connect_Click);
            // 
            // test_tone_label1
            // 
            this.test_tone_label1.AutoSize = true;
            this.test_tone_label1.ForeColor = System.Drawing.Color.Lime;
            this.test_tone_label1.Location = new System.Drawing.Point(8, 1048);
            this.test_tone_label1.Name = "test_tone_label1";
            this.test_tone_label1.Size = new System.Drawing.Size(91, 13);
            this.test_tone_label1.TabIndex = 75;
            this.test_tone_label1.Text = "Test Tone Output";
            // 
            // test_tone_label4
            // 
            this.test_tone_label4.AutoSize = true;
            this.test_tone_label4.ForeColor = System.Drawing.Color.Lime;
            this.test_tone_label4.Location = new System.Drawing.Point(581, 1080);
            this.test_tone_label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.test_tone_label4.Name = "test_tone_label4";
            this.test_tone_label4.Size = new System.Drawing.Size(35, 13);
            this.test_tone_label4.TabIndex = 79;
            this.test_tone_label4.Text = "F [Hz]";
            // 
            // test_tone_label3
            // 
            this.test_tone_label3.AutoSize = true;
            this.test_tone_label3.ForeColor = System.Drawing.Color.Lime;
            this.test_tone_label3.Location = new System.Drawing.Point(416, 1080);
            this.test_tone_label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.test_tone_label3.Name = "test_tone_label3";
            this.test_tone_label3.Size = new System.Drawing.Size(49, 13);
            this.test_tone_label3.TabIndex = 78;
            this.test_tone_label3.Text = "A [dBFS]";
            // 
            // test_tone_freq
            // 
            this.test_tone_freq.DecimalPlaces = 1;
            this.test_tone_freq.Location = new System.Drawing.Point(631, 1078);
            this.test_tone_freq.Maximum = new decimal(new int[] {
            24000,
            0,
            0,
            0});
            this.test_tone_freq.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.test_tone_freq.Name = "test_tone_freq";
            this.test_tone_freq.Size = new System.Drawing.Size(71, 20);
            this.test_tone_freq.TabIndex = 77;
            this.test_tone_freq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.test_tone_freq.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.test_tone_freq.ValueChanged += new System.EventHandler(this.test_tone_freq_ValueChanged);
            // 
            // test_tone_amp
            // 
            this.test_tone_amp.DecimalPlaces = 1;
            this.test_tone_amp.Location = new System.Drawing.Point(484, 1078);
            this.test_tone_amp.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.test_tone_amp.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.test_tone_amp.Name = "test_tone_amp";
            this.test_tone_amp.Size = new System.Drawing.Size(71, 20);
            this.test_tone_amp.TabIndex = 76;
            this.test_tone_amp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.test_tone_amp.ValueChanged += new System.EventHandler(this.test_tone_amp_ValueChanged);
            // 
            // test_tone_waveform
            // 
            this.test_tone_waveform.BackColor = System.Drawing.Color.Black;
            this.test_tone_waveform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.test_tone_waveform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.test_tone_waveform.ForeColor = System.Drawing.Color.Lime;
            this.test_tone_waveform.FormattingEnabled = true;
            this.test_tone_waveform.Location = new System.Drawing.Point(93, 1105);
            this.test_tone_waveform.Margin = new System.Windows.Forms.Padding(2);
            this.test_tone_waveform.Name = "test_tone_waveform";
            this.test_tone_waveform.Size = new System.Drawing.Size(93, 21);
            this.test_tone_waveform.TabIndex = 80;
            this.test_tone_waveform.SelectedIndexChanged += new System.EventHandler(this.test_tone_waveform_SelectedIndexChanged);
            // 
            // test_tone_label2
            // 
            this.test_tone_label2.AutoSize = true;
            this.test_tone_label2.ForeColor = System.Drawing.Color.Lime;
            this.test_tone_label2.Location = new System.Drawing.Point(8, 1110);
            this.test_tone_label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.test_tone_label2.Name = "test_tone_label2";
            this.test_tone_label2.Size = new System.Drawing.Size(62, 13);
            this.test_tone_label2.TabIndex = 81;
            this.test_tone_label2.Text = "Wave Form";
            // 
            // test_tone_onoff
            // 
            this.test_tone_onoff.AutoSize = true;
            this.test_tone_onoff.ForeColor = System.Drawing.Color.Lime;
            this.test_tone_onoff.Location = new System.Drawing.Point(567, 41);
            this.test_tone_onoff.Margin = new System.Windows.Forms.Padding(2);
            this.test_tone_onoff.Name = "test_tone_onoff";
            this.test_tone_onoff.Size = new System.Drawing.Size(93, 17);
            this.test_tone_onoff.TabIndex = 82;
            this.test_tone_onoff.Text = "Function Gen.";
            this.test_tone_onoff.UseVisualStyleBackColor = true;
            this.test_tone_onoff.CheckedChanged += new System.EventHandler(this.test_tone_onoff_CheckedChanged);
            // 
            // test_tone_out_dev
            // 
            this.test_tone_out_dev.AutoSize = true;
            this.test_tone_out_dev.ForeColor = System.Drawing.Color.Lime;
            this.test_tone_out_dev.Location = new System.Drawing.Point(95, 1080);
            this.test_tone_out_dev.Name = "test_tone_out_dev";
            this.test_tone_out_dev.Size = new System.Drawing.Size(51, 13);
            this.test_tone_out_dev.TabIndex = 83;
            this.test_tone_out_dev.Text = "unknown";
            // 
            // test_tone_fsweep
            // 
            this.test_tone_fsweep.AutoSize = true;
            this.test_tone_fsweep.ForeColor = System.Drawing.Color.Lime;
            this.test_tone_fsweep.Location = new System.Drawing.Point(476, 1109);
            this.test_tone_fsweep.Margin = new System.Windows.Forms.Padding(2);
            this.test_tone_fsweep.Name = "test_tone_fsweep";
            this.test_tone_fsweep.Size = new System.Drawing.Size(77, 17);
            this.test_tone_fsweep.TabIndex = 84;
            this.test_tone_fsweep.Text = "Frq.Sweep";
            this.test_tone_fsweep.UseVisualStyleBackColor = true;
            this.test_tone_fsweep.CheckedChanged += new System.EventHandler(this.test_tone_fsweep_CheckedChanged);
            // 
            // test_tone_freqstop
            // 
            this.test_tone_freqstop.DecimalPlaces = 1;
            this.test_tone_freqstop.Location = new System.Drawing.Point(631, 1108);
            this.test_tone_freqstop.Maximum = new decimal(new int[] {
            24000,
            0,
            0,
            0});
            this.test_tone_freqstop.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.test_tone_freqstop.Name = "test_tone_freqstop";
            this.test_tone_freqstop.Size = new System.Drawing.Size(71, 20);
            this.test_tone_freqstop.TabIndex = 85;
            this.test_tone_freqstop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.test_tone_freqstop.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.test_tone_freqstop.ValueChanged += new System.EventHandler(this.test_tone_freqstop_ValueChanged);
            // 
            // test_tone_label5
            // 
            this.test_tone_label5.AutoSize = true;
            this.test_tone_label5.ForeColor = System.Drawing.Color.Lime;
            this.test_tone_label5.Location = new System.Drawing.Point(577, 1110);
            this.test_tone_label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.test_tone_label5.Name = "test_tone_label5";
            this.test_tone_label5.Size = new System.Drawing.Size(38, 13);
            this.test_tone_label5.TabIndex = 86;
            this.test_tone_label5.Text = "to [Hz]";
            // 
            // test_tone_sweep_time
            // 
            this.test_tone_sweep_time.DecimalPlaces = 1;
            this.test_tone_sweep_time.Location = new System.Drawing.Point(821, 1078);
            this.test_tone_sweep_time.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.test_tone_sweep_time.Name = "test_tone_sweep_time";
            this.test_tone_sweep_time.Size = new System.Drawing.Size(71, 20);
            this.test_tone_sweep_time.TabIndex = 87;
            this.test_tone_sweep_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.test_tone_sweep_time.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.test_tone_sweep_time.ValueChanged += new System.EventHandler(this.test_tone_sweep_time_ValueChanged);
            // 
            // test_tone_label6
            // 
            this.test_tone_label6.AutoSize = true;
            this.test_tone_label6.ForeColor = System.Drawing.Color.Lime;
            this.test_tone_label6.Location = new System.Drawing.Point(721, 1080);
            this.test_tone_label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.test_tone_label6.Name = "test_tone_label6";
            this.test_tone_label6.Size = new System.Drawing.Size(73, 13);
            this.test_tone_label6.TabIndex = 88;
            this.test_tone_label6.Text = "Sweeptime [s]";
            // 
            // test_tone_logsweep
            // 
            this.test_tone_logsweep.AutoSize = true;
            this.test_tone_logsweep.ForeColor = System.Drawing.Color.Lime;
            this.test_tone_logsweep.Location = new System.Drawing.Point(716, 1109);
            this.test_tone_logsweep.Margin = new System.Windows.Forms.Padding(2);
            this.test_tone_logsweep.Name = "test_tone_logsweep";
            this.test_tone_logsweep.Size = new System.Drawing.Size(80, 17);
            this.test_tone_logsweep.TabIndex = 89;
            this.test_tone_logsweep.Text = "Log Sweep";
            this.test_tone_logsweep.UseVisualStyleBackColor = true;
            this.test_tone_logsweep.CheckedChanged += new System.EventHandler(this.test_tone_logsweep_CheckedChanged);
            // 
            // test_tone_updown
            // 
            this.test_tone_updown.AutoSize = true;
            this.test_tone_updown.ForeColor = System.Drawing.Color.Lime;
            this.test_tone_updown.Location = new System.Drawing.Point(820, 1107);
            this.test_tone_updown.Margin = new System.Windows.Forms.Padding(2);
            this.test_tone_updown.Name = "test_tone_updown";
            this.test_tone_updown.Size = new System.Drawing.Size(68, 17);
            this.test_tone_updown.TabIndex = 90;
            this.test_tone_updown.Text = "UpDown";
            this.test_tone_updown.UseVisualStyleBackColor = true;
            this.test_tone_updown.CheckedChanged += new System.EventHandler(this.test_tone_updown_CheckedChanged);
            // 
            // test_tone_label7
            // 
            this.test_tone_label7.AutoSize = true;
            this.test_tone_label7.ForeColor = System.Drawing.Color.Lime;
            this.test_tone_label7.Location = new System.Drawing.Point(199, 1110);
            this.test_tone_label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.test_tone_label7.Name = "test_tone_label7";
            this.test_tone_label7.Size = new System.Drawing.Size(42, 13);
            this.test_tone_label7.TabIndex = 92;
            this.test_tone_label7.Text = "PW [%]";
            // 
            // test_tone_pw
            // 
            this.test_tone_pw.DecimalPlaces = 1;
            this.test_tone_pw.Location = new System.Drawing.Point(266, 1108);
            this.test_tone_pw.Name = "test_tone_pw";
            this.test_tone_pw.Size = new System.Drawing.Size(55, 20);
            this.test_tone_pw.TabIndex = 91;
            this.test_tone_pw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.test_tone_pw.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.test_tone_pw.ValueChanged += new System.EventHandler(this.test_tone_pw_ValueChanged);
            // 
            // test_tone_mod
            // 
            this.test_tone_mod.BackColor = System.Drawing.Color.Black;
            this.test_tone_mod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.test_tone_mod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.test_tone_mod.ForeColor = System.Drawing.Color.Lime;
            this.test_tone_mod.FormattingEnabled = true;
            this.test_tone_mod.Location = new System.Drawing.Point(1010, 1077);
            this.test_tone_mod.Margin = new System.Windows.Forms.Padding(2);
            this.test_tone_mod.Name = "test_tone_mod";
            this.test_tone_mod.Size = new System.Drawing.Size(71, 21);
            this.test_tone_mod.TabIndex = 93;
            this.test_tone_mod.SelectedIndexChanged += new System.EventHandler(this.test_tone_mod_SelectedIndexChanged);
            // 
            // test_tone_label8
            // 
            this.test_tone_label8.AutoSize = true;
            this.test_tone_label8.ForeColor = System.Drawing.Color.Lime;
            this.test_tone_label8.Location = new System.Drawing.Point(940, 1080);
            this.test_tone_label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.test_tone_label8.Name = "test_tone_label8";
            this.test_tone_label8.Size = new System.Drawing.Size(51, 13);
            this.test_tone_label8.TabIndex = 94;
            this.test_tone_label8.Text = "Modulate";
            // 
            // test_tone_label9
            // 
            this.test_tone_label9.AutoSize = true;
            this.test_tone_label9.ForeColor = System.Drawing.Color.Lime;
            this.test_tone_label9.Location = new System.Drawing.Point(1091, 1080);
            this.test_tone_label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.test_tone_label9.Name = "test_tone_label9";
            this.test_tone_label9.Size = new System.Drawing.Size(59, 13);
            this.test_tone_label9.TabIndex = 96;
            this.test_tone_label9.Text = "Mod F [Hz]";
            // 
            // test_tone_modfreq
            // 
            this.test_tone_modfreq.DecimalPlaces = 2;
            this.test_tone_modfreq.Location = new System.Drawing.Point(1173, 1078);
            this.test_tone_modfreq.Maximum = new decimal(new int[] {
            24000,
            0,
            0,
            0});
            this.test_tone_modfreq.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.test_tone_modfreq.Name = "test_tone_modfreq";
            this.test_tone_modfreq.Size = new System.Drawing.Size(71, 20);
            this.test_tone_modfreq.TabIndex = 95;
            this.test_tone_modfreq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.test_tone_modfreq.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.test_tone_modfreq.ValueChanged += new System.EventHandler(this.test_tone_modfreq_ValueChanged);
            // 
            // test_tone_label10
            // 
            this.test_tone_label10.AutoSize = true;
            this.test_tone_label10.ForeColor = System.Drawing.Color.Lime;
            this.test_tone_label10.Location = new System.Drawing.Point(1090, 1108);
            this.test_tone_label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.test_tone_label10.Name = "test_tone_label10";
            this.test_tone_label10.Size = new System.Drawing.Size(60, 13);
            this.test_tone_label10.TabIndex = 98;
            this.test_tone_label10.Text = "Mod A [FS]";
            // 
            // test_tone_modamp
            // 
            this.test_tone_modamp.DecimalPlaces = 2;
            this.test_tone_modamp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.test_tone_modamp.Location = new System.Drawing.Point(1173, 1106);
            this.test_tone_modamp.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.test_tone_modamp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.test_tone_modamp.Name = "test_tone_modamp";
            this.test_tone_modamp.Size = new System.Drawing.Size(71, 20);
            this.test_tone_modamp.TabIndex = 97;
            this.test_tone_modamp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.test_tone_modamp.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.test_tone_modamp.ValueChanged += new System.EventHandler(this.test_tone_modamp_ValueChanged);
            // 
            // test_tone_modform
            // 
            this.test_tone_modform.BackColor = System.Drawing.Color.Black;
            this.test_tone_modform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.test_tone_modform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.test_tone_modform.ForeColor = System.Drawing.Color.Lime;
            this.test_tone_modform.FormattingEnabled = true;
            this.test_tone_modform.Location = new System.Drawing.Point(1010, 1105);
            this.test_tone_modform.Margin = new System.Windows.Forms.Padding(2);
            this.test_tone_modform.Name = "test_tone_modform";
            this.test_tone_modform.Size = new System.Drawing.Size(71, 21);
            this.test_tone_modform.TabIndex = 99;
            this.test_tone_modform.SelectedIndexChanged += new System.EventHandler(this.test_tone_modform_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(8, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 100;
            this.label2.Text = "(C) 2015-2020 T. Buck";
            // 
            // osc_circ_ofs_label
            // 
            this.osc_circ_ofs_label.AutoSize = true;
            this.osc_circ_ofs_label.ForeColor = System.Drawing.Color.Lime;
            this.osc_circ_ofs_label.Location = new System.Drawing.Point(1268, 723);
            this.osc_circ_ofs_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.osc_circ_ofs_label.Name = "osc_circ_ofs_label";
            this.osc_circ_ofs_label.Size = new System.Drawing.Size(73, 13);
            this.osc_circ_ofs_label.TabIndex = 102;
            this.osc_circ_ofs_label.Text = "Circular Offset";
            // 
            // osc_circ_ofs
            // 
            this.osc_circ_ofs.BackColor = System.Drawing.Color.Black;
            this.osc_circ_ofs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.osc_circ_ofs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.osc_circ_ofs.ForeColor = System.Drawing.Color.Lime;
            this.osc_circ_ofs.FormattingEnabled = true;
            this.osc_circ_ofs.Location = new System.Drawing.Point(1268, 743);
            this.osc_circ_ofs.Margin = new System.Windows.Forms.Padding(2);
            this.osc_circ_ofs.Name = "osc_circ_ofs";
            this.osc_circ_ofs.Size = new System.Drawing.Size(123, 21);
            this.osc_circ_ofs.TabIndex = 101;
            this.osc_circ_ofs.SelectedIndexChanged += new System.EventHandler(this.osc_circ_ofs_SelectedIndexChanged);
            // 
            // mainwin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1402, 1239);
            this.ControlBox = false;
            this.Controls.Add(this.osc_circ_ofs_label);
            this.Controls.Add(this.osc_circ_ofs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.test_tone_modform);
            this.Controls.Add(this.test_tone_label10);
            this.Controls.Add(this.test_tone_modamp);
            this.Controls.Add(this.test_tone_label9);
            this.Controls.Add(this.test_tone_modfreq);
            this.Controls.Add(this.test_tone_label8);
            this.Controls.Add(this.test_tone_mod);
            this.Controls.Add(this.test_tone_label7);
            this.Controls.Add(this.test_tone_pw);
            this.Controls.Add(this.test_tone_updown);
            this.Controls.Add(this.test_tone_logsweep);
            this.Controls.Add(this.test_tone_label6);
            this.Controls.Add(this.test_tone_sweep_time);
            this.Controls.Add(this.test_tone_label5);
            this.Controls.Add(this.test_tone_freqstop);
            this.Controls.Add(this.test_tone_fsweep);
            this.Controls.Add(this.test_tone_devs);
            this.Controls.Add(this.test_tone_out_dev);
            this.Controls.Add(this.test_tone_onoff);
            this.Controls.Add(this.test_tone_label2);
            this.Controls.Add(this.test_tone_waveform);
            this.Controls.Add(this.test_tone_label4);
            this.Controls.Add(this.test_tone_label3);
            this.Controls.Add(this.test_tone_freq);
            this.Controls.Add(this.test_tone_amp);
            this.Controls.Add(this.test_tone_label1);
            this.Controls.Add(this.test_tone_connect);
            this.Controls.Add(this.osc_color_label);
            this.Controls.Add(this.osc_color);
            this.Controls.Add(this.audioDevs);
            this.Controls.Add(this.device_label);
            this.Controls.Add(this.testtone_label2);
            this.Controls.Add(this.testtone_label1);
            this.Controls.Add(this.testtone_freq);
            this.Controls.Add(this.testtone_amp);
            this.Controls.Add(this.en_testtone);
            this.Controls.Add(this.fft_spek_label2);
            this.Controls.Add(this.fft_spek_color);
            this.Controls.Add(this.fft_stream_label2);
            this.Controls.Add(this.fft_stream_color);
            this.Controls.Add(this.do_calibrate);
            this.Controls.Add(this.do_pickL);
            this.Controls.Add(this.do_pickR);
            this.Controls.Add(this.cal_refmeas);
            this.Controls.Add(this.cal_refset);
            this.Controls.Add(this.cal_unit_label);
            this.Controls.Add(this.cal_unit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quit);
            this.Controls.Add(this.fft_window_func);
            this.Controls.Add(this.pwr_onoff);
            this.Controls.Add(this.pwr_r_label);
            this.Controls.Add(this.pwr_l_label);
            this.Controls.Add(this.pwr_horz_axis);
            this.Controls.Add(this.pwr_r_unit);
            this.Controls.Add(this.pwr_l_unit);
            this.Controls.Add(this.pwr_r_val);
            this.Controls.Add(this.pwr_int_label);
            this.Controls.Add(this.pwr_int_filter);
            this.Controls.Add(this.pwr_l_val);
            this.Controls.Add(this.pwr_r_display);
            this.Controls.Add(this.pwr_l_display);
            this.Controls.Add(this.config_onoff);
            this.Controls.Add(this.log_onoff);
            this.Controls.Add(this.osc_horz_axis);
            this.Controls.Add(this.osc_vert_axis);
            this.Controls.Add(this.fft_stream_vert_axis);
            this.Controls.Add(this.fft_spek_vert_axis);
            this.Controls.Add(this.fft_horz_axis);
            this.Controls.Add(this.osc_gain_label);
            this.Controls.Add(this.osc_gain);
            this.Controls.Add(this.osc_onoff);
            this.Controls.Add(this.fft_spek_onoff);
            this.Controls.Add(this.fft_stream_onoff);
            this.Controls.Add(this.fft_spek_label);
            this.Controls.Add(this.fft_spek_gain);
            this.Controls.Add(this.fft_stream_label);
            this.Controls.Add(this.fft_stream_gain);
            this.Controls.Add(this.fft_source_label);
            this.Controls.Add(this.fft_source);
            this.Controls.Add(this.osc_stereo_display);
            this.Controls.Add(this.osc_wave_display);
            this.Controls.Add(this.fft_spek_display);
            this.Controls.Add(this.LOG);
            this.Controls.Add(this.fft_stream_display);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.bkgbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainwin";
            this.Text = "Simple Audio Signal Analyzer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainwin_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainwin_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.fft_stream_display)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fft_spek_display)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osc_wave_display)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osc_stereo_display)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fft_horz_axis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fft_spek_vert_axis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fft_stream_vert_axis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osc_vert_axis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osc_horz_axis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwr_l_display)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwr_r_display)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwr_horz_axis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cal_refset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cal_refmeas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bkgbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testtone_amp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testtone_freq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_tone_freq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_tone_amp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_tone_freqstop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_tone_sweep_time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_tone_pw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_tone_modfreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_tone_modamp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.ComboBox audioDevs;
        private System.Windows.Forms.PictureBox fft_stream_display;
        private System.Windows.Forms.TextBox LOG;
        private System.Windows.Forms.PictureBox fft_spek_display;
        private System.Windows.Forms.PictureBox osc_wave_display;
        private System.Windows.Forms.PictureBox osc_stereo_display;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox fft_source;
        private System.Windows.Forms.Label fft_source_label;
        private System.Windows.Forms.ComboBox fft_stream_gain;
        private System.Windows.Forms.Label fft_stream_label;
        private System.Windows.Forms.Label fft_spek_label;
        private System.Windows.Forms.ComboBox fft_spek_gain;
        private System.Windows.Forms.CheckBox fft_stream_onoff;
        private System.Windows.Forms.CheckBox fft_spek_onoff;
        private System.Windows.Forms.CheckBox osc_onoff;
        private System.Windows.Forms.Label osc_gain_label;
        private System.Windows.Forms.ComboBox osc_gain;
        private System.Windows.Forms.PictureBox fft_horz_axis;
        private System.Windows.Forms.PictureBox fft_spek_vert_axis;
        private System.Windows.Forms.PictureBox fft_stream_vert_axis;
        private System.Windows.Forms.PictureBox osc_vert_axis;
        private System.Windows.Forms.PictureBox osc_horz_axis;
        private System.Windows.Forms.CheckBox log_onoff;
        private System.Windows.Forms.CheckBox config_onoff;
        private System.Windows.Forms.PictureBox pwr_l_display;
        private System.Windows.Forms.PictureBox pwr_r_display;
        private System.Windows.Forms.TextBox pwr_l_val;
        private System.Windows.Forms.ComboBox pwr_int_filter;
        private System.Windows.Forms.Label pwr_int_label;
        private System.Windows.Forms.TextBox pwr_r_val;
        private System.Windows.Forms.Label pwr_l_unit;
        private System.Windows.Forms.Label pwr_r_unit;
        private System.Windows.Forms.PictureBox pwr_horz_axis;
        private System.Windows.Forms.Label pwr_l_label;
        private System.Windows.Forms.Label pwr_r_label;
        private System.Windows.Forms.CheckBox pwr_onoff;
        private System.Windows.Forms.ComboBox fft_window_func;
        private System.Windows.Forms.Button quit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cal_unit;
        private System.Windows.Forms.Label cal_unit_label;
        private System.Windows.Forms.NumericUpDown cal_refset;
        private System.Windows.Forms.NumericUpDown cal_refmeas;
        private System.Windows.Forms.Button do_pickR;
        private System.Windows.Forms.Button do_pickL;
        private System.Windows.Forms.Button do_calibrate;
        private System.Windows.Forms.ComboBox fft_stream_color;
        private System.Windows.Forms.Label fft_stream_label2;
        private System.Windows.Forms.Label fft_spek_label2;
        private System.Windows.Forms.ComboBox fft_spek_color;
        private System.Windows.Forms.PictureBox bkgbx;
        private System.Windows.Forms.CheckBox en_testtone;
        private System.Windows.Forms.NumericUpDown testtone_amp;
        private System.Windows.Forms.NumericUpDown testtone_freq;
        private System.Windows.Forms.Label testtone_label1;
        private System.Windows.Forms.Label testtone_label2;
        private System.Windows.Forms.Label device_label;
        private System.Windows.Forms.Label osc_color_label;
        private System.Windows.Forms.ComboBox osc_color;
        private System.Windows.Forms.ComboBox test_tone_devs;
        private System.Windows.Forms.Button test_tone_connect;
        private System.Windows.Forms.Label test_tone_label1;
        private System.Windows.Forms.Label test_tone_label4;
        private System.Windows.Forms.Label test_tone_label3;
        private System.Windows.Forms.NumericUpDown test_tone_freq;
        private System.Windows.Forms.NumericUpDown test_tone_amp;
        private System.Windows.Forms.ComboBox test_tone_waveform;
        private System.Windows.Forms.Label test_tone_label2;
        private System.Windows.Forms.CheckBox test_tone_onoff;
        private System.Windows.Forms.Label test_tone_out_dev;
        private System.Windows.Forms.CheckBox test_tone_fsweep;
        private System.Windows.Forms.NumericUpDown test_tone_freqstop;
        private System.Windows.Forms.Label test_tone_label5;
        private System.Windows.Forms.NumericUpDown test_tone_sweep_time;
        private System.Windows.Forms.Label test_tone_label6;
        private System.Windows.Forms.CheckBox test_tone_logsweep;
        private System.Windows.Forms.CheckBox test_tone_updown;
        private System.Windows.Forms.Label test_tone_label7;
        private System.Windows.Forms.NumericUpDown test_tone_pw;
        private System.Windows.Forms.ComboBox test_tone_mod;
        private System.Windows.Forms.Label test_tone_label8;
        private System.Windows.Forms.Label test_tone_label9;
        private System.Windows.Forms.NumericUpDown test_tone_modfreq;
        private System.Windows.Forms.Label test_tone_label10;
        private System.Windows.Forms.NumericUpDown test_tone_modamp;
        private System.Windows.Forms.ComboBox test_tone_modform;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label osc_circ_ofs_label;
        private System.Windows.Forms.ComboBox osc_circ_ofs;
    }
}

