namespace SpleeterGui
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.stems2 = new System.Windows.Forms.RadioButton();
            this.stems4 = new System.Windows.Forms.RadioButton();
            this.stems5 = new System.Windows.Forms.RadioButton();

            this.btnSaveTo = new System.Windows.Forms.Button();
            this.txt_output_directory = new System.Windows.Forms.TextBox();
            this.chkFullBandwidth = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblDroptext = new System.Windows.Forms.Label();
            this.lblSlogan1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblSlogan2 = new System.Windows.Forms.Label();
            this.lblPartsTitle = new System.Windows.Forms.Label();
            this.parts_btn2 = new System.Windows.Forms.Button();
            this.parts_btn4 = new System.Windows.Forms.Button();
            this.parts_btn5 = new System.Windows.Forms.Button();
            this.parts_label = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.progress_txt = new System.Windows.Forms.Label();
            this.btnSelectFiles = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.duration = new System.Windows.Forms.NumericUpDown();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.lblMaxLength = new System.Windows.Forms.Label();
            this.chkRecombine = new System.Windows.Forms.CheckBox();
            this.pnlRecombine = new System.Windows.Forms.Panel();
            this.chkRPartOther = new System.Windows.Forms.CheckBox();
            this.chkRPartPiano = new System.Windows.Forms.CheckBox();
            this.chkRPartDrums = new System.Windows.Forms.CheckBox();
            this.chkRPartBass = new System.Windows.Forms.CheckBox();
            this.chkRPartVocal = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlSeparationOptions = new System.Windows.Forms.Panel();
            this.pnlFileInput = new System.Windows.Forms.Panel();
            this.pnlOutput = new System.Windows.Forms.Panel();

            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.duration)).BeginInit();
            this.pnlRecombine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlSeparationOptions.SuspendLayout();
            this.pnlFileInput.SuspendLayout();
            this.pnlOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // stems2
            // 
            this.stems2.Location = new System.Drawing.Point(0, 0);
            this.stems2.Name = "stems2";
            this.stems2.Size = new System.Drawing.Size(104, 24);
            this.stems2.TabIndex = 36;
            // 
            // stems4
            // 
            this.stems4.Location = new System.Drawing.Point(0, 0);
            this.stems4.Name = "stems4";
            this.stems4.Size = new System.Drawing.Size(104, 24);
            this.stems4.TabIndex = 35;
            // 
            // stems5
            // 
            this.stems5.Location = new System.Drawing.Point(0, 0);
            this.stems5.Name = "stems5";
            this.stems5.Size = new System.Drawing.Size(104, 24);
            this.stems5.TabIndex = 34;


            //
            // btnSaveTo
            //
            this.btnSaveTo.AccessibleDescription = "Choose folder to save separated files to";
            this.btnSaveTo.AccessibleName = "Save to";
            this.btnSaveTo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.btnSaveTo.FlatAppearance.BorderSize = 0;
            this.btnSaveTo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(153)))));
            this.btnSaveTo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSaveTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveTo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveTo.ForeColor = System.Drawing.Color.White;
            this.btnSaveTo.Location = new System.Drawing.Point(20, 60);
            this.btnSaveTo.Name = "btnSaveTo";
            this.btnSaveTo.Size = new System.Drawing.Size(120, 30);
            this.btnSaveTo.TabIndex = 8;
            this.btnSaveTo.Text = "📂 Output Folder";
            this.btnSaveTo.UseVisualStyleBackColor = false;
            this.btnSaveTo.Click += new System.EventHandler(this.Button2_Click);
            //
            // txt_output_directory
            //
            this.txt_output_directory.AccessibleDescription = "shows output directory location";
            this.txt_output_directory.AccessibleName = "output directory display";
            this.txt_output_directory.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.txt_output_directory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.txt_output_directory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_output_directory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_output_directory.ForeColor = System.Drawing.Color.White;
            this.txt_output_directory.Location = new System.Drawing.Point(150, 60);
            this.txt_output_directory.Name = "txt_output_directory";
            this.txt_output_directory.Size = new System.Drawing.Size(590, 25);
            this.txt_output_directory.TabIndex = 9;
            //
            // chkFullBandwidth
            //
            this.chkFullBandwidth.AccessibleDescription = "enable high quality mode (may increase noise)";
            this.chkFullBandwidth.AccessibleName = "full bandwidth";
            this.chkFullBandwidth.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.chkFullBandwidth.AutoSize = true;
            this.chkFullBandwidth.Checked = true;
            this.chkFullBandwidth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFullBandwidth.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFullBandwidth.ForeColor = System.Drawing.Color.White;
            this.chkFullBandwidth.Location = new System.Drawing.Point(20, 20);
            this.chkFullBandwidth.Name = "chkFullBandwidth";
            this.chkFullBandwidth.Size = new System.Drawing.Size(224, 23);
            this.chkFullBandwidth.TabIndex = 7;
            this.chkFullBandwidth.Text = "High Quality (16kHz Full Bandwidth)";
            this.chkFullBandwidth.UseVisualStyleBackColor = true;
            this.chkFullBandwidth.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            //
            // textBox1
            //
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AccessibleDescription = "spleeter debug output";
            this.textBox1.AccessibleName = "Console output";
            this.textBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.textBox1.Location = new System.Drawing.Point(20, 50);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(720, 210);
            this.textBox1.TabIndex = 16;
            //
            // lblDroptext
            //
            this.lblDroptext.AutoSize = true;
            this.lblDroptext.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDroptext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblDroptext.Location = new System.Drawing.Point(200, 30);
            this.lblDroptext.Name = "lblDroptext";
            this.lblDroptext.Size = new System.Drawing.Size(360, 30);
            this.lblDroptext.TabIndex = 13;
            this.lblDroptext.Text = "🎵 Drop your music files here to start";
            //
            // lblSlogan1
            //
            this.lblSlogan1.AutoSize = true;
            this.lblSlogan1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlogan1.ForeColor = System.Drawing.Color.White;
            this.lblSlogan1.Location = new System.Drawing.Point(220, 25);
            this.lblSlogan1.Name = "lblSlogan1";
            this.lblSlogan1.Size = new System.Drawing.Size(245, 30);
            this.lblSlogan1.TabIndex = 0;
            this.lblSlogan1.Text = "Music Source Separation";
            //
            // progressBar1
            //
            this.progressBar1.AccessibleDescription = "Shows overall process completion";
            this.progressBar1.AccessibleName = "Progress Bar";
            this.progressBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ProgressBar;
            this.progressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.progressBar1.Location = new System.Drawing.Point(20, 50);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(720, 12);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 11;
            //
            // lblSlogan2
            //
            this.lblSlogan2.AutoSize = true;
            this.lblSlogan2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlogan2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblSlogan2.Location = new System.Drawing.Point(220, 55);
            this.lblSlogan2.Name = "lblSlogan2";
            this.lblSlogan2.Size = new System.Drawing.Size(186, 21);
            this.lblSlogan2.TabIndex = 1;
            this.lblSlogan2.Text = "Professional Audio Tool";
            //
            // lblPartsTitle
            //
            this.lblPartsTitle.AutoSize = true;
            this.lblPartsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartsTitle.ForeColor = System.Drawing.Color.White;
            this.lblPartsTitle.Location = new System.Drawing.Point(20, 20);
            this.lblPartsTitle.Name = "lblPartsTitle";
            this.lblPartsTitle.Size = new System.Drawing.Size(158, 25);
            this.lblPartsTitle.TabIndex = 2;
            this.lblPartsTitle.Text = "Separation Mode";
            //
            // pnlSeparationOptions
            //
            this.pnlSeparationOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlSeparationOptions.Controls.Add(this.lblPartsTitle);
            this.pnlSeparationOptions.Controls.Add(this.parts_btn2);
            this.pnlSeparationOptions.Controls.Add(this.parts_btn4);
            this.pnlSeparationOptions.Controls.Add(this.parts_btn5);
            this.pnlSeparationOptions.Controls.Add(this.parts_label);
            this.pnlSeparationOptions.Controls.Add(this.pnlRecombine);
            this.pnlSeparationOptions.Location = new System.Drawing.Point(20, 142);
            this.pnlSeparationOptions.Name = "pnlSeparationOptions";
            this.pnlSeparationOptions.Size = new System.Drawing.Size(760, 140);
            this.pnlSeparationOptions.TabIndex = 101;
            //
            // parts_btn2
            //
            this.parts_btn2.AccessibleDescription = "Separate song in 2 parts";
            this.parts_btn2.AccessibleName = "Two parts";
            this.parts_btn2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.parts_btn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.parts_btn2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.parts_btn2.FlatAppearance.BorderSize = 0;
            this.parts_btn2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(153)))));
            this.parts_btn2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(151)))), ((int)(((byte)(234)))));
            this.parts_btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.parts_btn2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parts_btn2.ForeColor = System.Drawing.Color.White;
            this.parts_btn2.Location = new System.Drawing.Point(200, 20);
            this.parts_btn2.Name = "parts_btn2";
            this.parts_btn2.Size = new System.Drawing.Size(60, 40);
            this.parts_btn2.TabIndex = 3;
            this.parts_btn2.Text = "2";
            this.parts_btn2.UseVisualStyleBackColor = false;
            this.parts_btn2.Click += new System.EventHandler(this.parts_btn2_Click);
            //
            // parts_btn4
            //
            this.parts_btn4.AccessibleDescription = "Separate song in 4 parts";
            this.parts_btn4.AccessibleName = "four parts";
            this.parts_btn4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.parts_btn4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.parts_btn4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.parts_btn4.FlatAppearance.BorderSize = 0;
            this.parts_btn4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(153)))));
            this.parts_btn4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.parts_btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.parts_btn4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parts_btn4.ForeColor = System.Drawing.Color.White;
            this.parts_btn4.Location = new System.Drawing.Point(270, 20);
            this.parts_btn4.Name = "parts_btn4";
            this.parts_btn4.Size = new System.Drawing.Size(60, 40);
            this.parts_btn4.TabIndex = 4;
            this.parts_btn4.Text = "4";
            this.parts_btn4.UseVisualStyleBackColor = false;
            this.parts_btn4.Click += new System.EventHandler(this.parts_btn4_Click);
            //
            // parts_btn5
            //
            this.parts_btn5.AccessibleDescription = "Separate song in 5 parts";
            this.parts_btn5.AccessibleName = "five parts";
            this.parts_btn5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.parts_btn5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.parts_btn5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.parts_btn5.FlatAppearance.BorderSize = 0;
            this.parts_btn5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(153)))));
            this.parts_btn5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.parts_btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.parts_btn5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parts_btn5.ForeColor = System.Drawing.Color.White;
            this.parts_btn5.Location = new System.Drawing.Point(340, 20);
            this.parts_btn5.Name = "parts_btn5";
            this.parts_btn5.Size = new System.Drawing.Size(60, 40);
            this.parts_btn5.TabIndex = 5;
            this.parts_btn5.Text = "5";
            this.parts_btn5.UseVisualStyleBackColor = false;
            this.parts_btn5.Click += new System.EventHandler(this.parts_btn5_Click);
            //
            // parts_label
            //
            this.parts_label.AccessibleDescription = "displays separated parts names";
            this.parts_label.AccessibleName = "parts description";
            this.parts_label.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.parts_label.AutoSize = true;
            this.parts_label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parts_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.parts_label.Location = new System.Drawing.Point(420, 30);
            this.parts_label.Name = "parts_label";
            this.parts_label.Size = new System.Drawing.Size(147, 19);
            this.parts_label.TabIndex = 6;
            this.parts_label.Text = "Vocal + Accompaniment";
            //
            // pnlFileInput
            //
            this.pnlFileInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlFileInput.Controls.Add(this.lblDroptext);
            this.pnlFileInput.Controls.Add(this.btnSelectFiles);
            this.pnlFileInput.Location = new System.Drawing.Point(20, 422);
            this.pnlFileInput.Name = "pnlFileInput";
            this.pnlFileInput.Size = new System.Drawing.Size(760, 120);
            this.pnlFileInput.TabIndex = 102;
            //
            // lblProgress
            //
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.Color.White;
            this.lblProgress.Location = new System.Drawing.Point(20, 20);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(73, 21);
            this.lblProgress.TabIndex = 10;
            this.lblProgress.Text = "Progress";
            //
            // progress_txt
            //
            this.progress_txt.AutoSize = true;
            this.progress_txt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progress_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.progress_txt.Location = new System.Drawing.Point(100, 22);
            this.progress_txt.Name = "progress_txt";
            this.progress_txt.Size = new System.Drawing.Size(32, 20);
            this.progress_txt.TabIndex = 12;
            this.progress_txt.Text = "Idle";
            //
            // btnSelectFiles
            //
            this.btnSelectFiles.AccessibleDescription = "Choose music files to begin processing";
            this.btnSelectFiles.AccessibleName = "Choose music files";
            this.btnSelectFiles.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.btnSelectFiles.FlatAppearance.BorderSize = 0;
            this.btnSelectFiles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(153)))));
            this.btnSelectFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSelectFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFiles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectFiles.ForeColor = System.Drawing.Color.White;
            this.btnSelectFiles.Location = new System.Drawing.Point(280, 70);
            this.btnSelectFiles.Name = "btnSelectFiles";
            this.btnSelectFiles.Size = new System.Drawing.Size(200, 40);
            this.btnSelectFiles.TabIndex = 15;
            this.btnSelectFiles.Text = "📁 Browse for Files";
            this.btnSelectFiles.UseVisualStyleBackColor = false;
            this.btnSelectFiles.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "Music Files|*.mp3;*.wav;*.ogg;*.m4a;*.wma;*.flac|All files (*.*)|*.*";
            this.openFileDialog2.Multiselect = true;
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);
            //
            // pnlOutput
            //
            this.pnlOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlOutput.Controls.Add(this.btnSaveTo);
            this.pnlOutput.Controls.Add(this.txt_output_directory);
            this.pnlOutput.Controls.Add(this.chkFullBandwidth);
            this.pnlOutput.Controls.Add(this.duration);
            this.pnlOutput.Controls.Add(this.lblSeconds);
            this.pnlOutput.Controls.Add(this.lblMaxLength);
            this.pnlOutput.Location = new System.Drawing.Point(20, 292);
            this.pnlOutput.Name = "pnlOutput";
            this.pnlOutput.Size = new System.Drawing.Size(760, 100);
            this.pnlOutput.TabIndex = 103;
            //
            // pnlMain
            //
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlMain.Controls.Add(this.textBox1);
            this.pnlMain.Controls.Add(this.progress_txt);
            this.pnlMain.Controls.Add(this.lblProgress);
            this.pnlMain.Controls.Add(this.progressBar1);
            this.pnlMain.Location = new System.Drawing.Point(20, 532);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(760, 280);
            this.pnlMain.TabIndex = 37;
            //
            // duration
            //
            this.duration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.duration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.duration.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duration.ForeColor = System.Drawing.Color.White;
            this.duration.Location = new System.Drawing.Point(450, 20);
            this.duration.Maximum = new decimal(new int[] {
            7200,
            0,
            0,
            0});
            this.duration.Name = "duration";
            this.duration.Size = new System.Drawing.Size(80, 25);
            this.duration.TabIndex = 19;
            this.duration.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.duration.ValueChanged += new System.EventHandler(this.duration_ValueChanged);
            //
            // lblSeconds
            //
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeconds.ForeColor = System.Drawing.Color.White;
            this.lblSeconds.Location = new System.Drawing.Point(540, 22);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(56, 19);
            this.lblSeconds.TabIndex = 18;
            this.lblSeconds.Text = "seconds";
            //
            // lblMaxLength
            //
            this.lblMaxLength.AutoSize = true;
            this.lblMaxLength.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxLength.ForeColor = System.Drawing.Color.White;
            this.lblMaxLength.Location = new System.Drawing.Point(300, 22);
            this.lblMaxLength.Name = "lblMaxLength";
            this.lblMaxLength.Size = new System.Drawing.Size(144, 19);
            this.lblMaxLength.TabIndex = 17;
            this.lblMaxLength.Text = "Maximum song length:";
            //
            // chkRecombine
            //
            this.chkRecombine.AutoSize = true;
            this.chkRecombine.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRecombine.ForeColor = System.Drawing.Color.White;
            this.chkRecombine.Location = new System.Drawing.Point(20, 10);
            this.chkRecombine.Name = "chkRecombine";
            this.chkRecombine.Size = new System.Drawing.Size(290, 23);
            this.chkRecombine.TabIndex = 38;
            this.chkRecombine.Text = "Recombine (Merge output parts back together)";
            this.chkRecombine.UseVisualStyleBackColor = true;
            this.chkRecombine.CheckedChanged += new System.EventHandler(this.chkRecombine_CheckedChanged);
            //
            // pnlRecombine
            //
            this.pnlRecombine.Controls.Add(this.chkRPartOther);
            this.pnlRecombine.Controls.Add(this.chkRecombine);
            this.pnlRecombine.Controls.Add(this.chkRPartPiano);
            this.pnlRecombine.Controls.Add(this.chkRPartDrums);
            this.pnlRecombine.Controls.Add(this.chkRPartBass);
            this.pnlRecombine.Controls.Add(this.chkRPartVocal);
            this.pnlRecombine.Location = new System.Drawing.Point(0, 70);
            this.pnlRecombine.Name = "pnlRecombine";
            this.pnlRecombine.Size = new System.Drawing.Size(760, 70);
            this.pnlRecombine.TabIndex = 39;
            //
            // chkRPartOther
            //
            this.chkRPartOther.AutoSize = true;
            this.chkRPartOther.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRPartOther.ForeColor = System.Drawing.Color.White;
            this.chkRPartOther.Location = new System.Drawing.Point(550, 40);
            this.chkRPartOther.Name = "chkRPartOther";
            this.chkRPartOther.Size = new System.Drawing.Size(57, 19);
            this.chkRPartOther.TabIndex = 5;
            this.chkRPartOther.Text = "Other";
            this.chkRPartOther.UseVisualStyleBackColor = true;
            //
            // chkRPartPiano
            //
            this.chkRPartPiano.AutoSize = true;
            this.chkRPartPiano.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRPartPiano.ForeColor = System.Drawing.Color.White;
            this.chkRPartPiano.Location = new System.Drawing.Point(480, 40);
            this.chkRPartPiano.Name = "chkRPartPiano";
            this.chkRPartPiano.Size = new System.Drawing.Size(58, 19);
            this.chkRPartPiano.TabIndex = 4;
            this.chkRPartPiano.Text = "Piano";
            this.chkRPartPiano.UseVisualStyleBackColor = true;
            //
            // chkRPartDrums
            //
            this.chkRPartDrums.AutoSize = true;
            this.chkRPartDrums.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRPartDrums.ForeColor = System.Drawing.Color.White;
            this.chkRPartDrums.Location = new System.Drawing.Point(410, 40);
            this.chkRPartDrums.Name = "chkRPartDrums";
            this.chkRPartDrums.Size = new System.Drawing.Size(62, 19);
            this.chkRPartDrums.TabIndex = 3;
            this.chkRPartDrums.Text = "Drums";
            this.chkRPartDrums.UseVisualStyleBackColor = true;
            //
            // chkRPartBass
            //
            this.chkRPartBass.AutoSize = true;
            this.chkRPartBass.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRPartBass.ForeColor = System.Drawing.Color.White;
            this.chkRPartBass.Location = new System.Drawing.Point(350, 40);
            this.chkRPartBass.Name = "chkRPartBass";
            this.chkRPartBass.Size = new System.Drawing.Size(52, 19);
            this.chkRPartBass.TabIndex = 2;
            this.chkRPartBass.Text = "Bass";
            this.chkRPartBass.UseVisualStyleBackColor = true;
            //
            // chkRPartVocal
            //
            this.chkRPartVocal.AutoSize = true;
            this.chkRPartVocal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRPartVocal.ForeColor = System.Drawing.Color.White;
            this.chkRPartVocal.Location = new System.Drawing.Point(290, 40);
            this.chkRPartVocal.Name = "chkRPartVocal";
            this.chkRPartVocal.Size = new System.Drawing.Size(56, 19);
            this.chkRPartVocal.TabIndex = 1;
            this.chkRPartVocal.Text = "Vocal";
            this.chkRPartVocal.UseVisualStyleBackColor = true;
            //
            // pictureBox1
            //
            this.pictureBox1.AccessibleDescription = "Spleeter logo";
            this.pictureBox1.AccessibleName = "Spleeter logo";
            this.pictureBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.pnlHeader.Controls.Add(this.pictureBox1);
            this.pnlHeader.Controls.Add(this.lblSlogan1);
            this.pnlHeader.Controls.Add(this.lblSlogan2);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 100);
            this.pnlHeader.TabIndex = 100;
            //
            // Form1
            //
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 850);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlOutput);
            this.Controls.Add(this.pnlFileInput);
            this.Controls.Add(this.pnlSeparationOptions);
            this.Controls.Add(this.pnlHeader);

            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpleeterGUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);

            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.duration)).EndInit();
            this.pnlRecombine.ResumeLayout(false);
            this.pnlRecombine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSeparationOptions.ResumeLayout(false);
            this.pnlSeparationOptions.PerformLayout();
            this.pnlFileInput.ResumeLayout(false);
            this.pnlFileInput.PerformLayout();
            this.pnlOutput.ResumeLayout(false);
            this.pnlOutput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton stems2;
        private System.Windows.Forms.RadioButton stems4;
        private System.Windows.Forms.RadioButton stems5;

        private System.Windows.Forms.Button btnSaveTo;
        private System.Windows.Forms.TextBox txt_output_directory;
        private System.Windows.Forms.CheckBox chkFullBandwidth;

        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.Label lblDroptext;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSlogan1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblSlogan2;
        private System.Windows.Forms.Label lblPartsTitle;
        private System.Windows.Forms.Button parts_btn2;
        private System.Windows.Forms.Button parts_btn4;
        private System.Windows.Forms.Button parts_btn5;
        private System.Windows.Forms.Label parts_label;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label progress_txt;
        private System.Windows.Forms.Button btnSelectFiles;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.CheckBox chkRecombine;
        private System.Windows.Forms.Panel pnlRecombine;
        private System.Windows.Forms.CheckBox chkRPartOther;
        private System.Windows.Forms.CheckBox chkRPartPiano;
        private System.Windows.Forms.CheckBox chkRPartDrums;
        private System.Windows.Forms.CheckBox chkRPartBass;
        private System.Windows.Forms.CheckBox chkRPartVocal;

        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.Label lblMaxLength;
        private System.Windows.Forms.NumericUpDown duration;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlSeparationOptions;
        private System.Windows.Forms.Panel pnlFileInput;
        private System.Windows.Forms.Panel pnlOutput;
    }
}

