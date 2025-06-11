using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;

namespace SpleeterGui
{
    public partial class Form1 : Form
    {
        private string stem_count = "2";
        private string mask_extension = "average";
        private string storage = "";

        private string path_python = "";    //needs to be the SpleeterGUI folder, not python
        
        private string current_songname = "";
        private int files_remain = 0;
        private List<string> files_to_process = new List<string>();
        private Boolean run_silent = true;
        private String gui_version = "";
        IDictionary<string, string> langStr = new Dictionary<string, string>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);

            // Apply modern styling with pixel-perfect rendering
            ApplyModernStyling();

            // Apply pixel-perfect styling to numeric control
            StyleNumericUpDown(duration);

            // Create custom language dropdown
            CreateCustomLanguageDropdown();

            // Set up drag and drop for file input panel
            pnlFileInput.AllowDrop = true;
            pnlFileInput.DragEnter += new DragEventHandler(FileInput_DragEnter);
            pnlFileInput.DragDrop += new DragEventHandler(Form1_DragDrop);
            pnlFileInput.DragLeave += new EventHandler(FileInput_DragLeave);

            // Set up modern drag and drop visual feedback
            SetupModernDragDrop();

            // Add custom window controls
            SetupCustomTitleBar();

            // Apply rounded corners to the entire form
            ApplyFormRoundedCorners();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            LoadStuff();
        }

        public void LoadStuff()
        {
            //program startup - initialise things
            txt_output_directory.Text = Properties.Settings.Default.output_location;

            string path = Application.StartupPath;
            path_python = path.ToString() + @"\python";
            storage = path.ToString();
            /*
            if (Properties.Settings.Default.path_python == "")
            {
                
                //path_python = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SpleeterGUI\python";
                //storage = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SpleeterGUI";
                
            }
            else
            {
                path_python = Properties.Settings.Default.path_python + @"\python";
                storage = Properties.Settings.Default.path_python;
            }
            */
            
            gui_version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            //String version = Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.MinorRevision.ToString();
            this.Text = "SpleeterGUI " + gui_version;

            
           

            duration.Value = Properties.Settings.Default.duration;

            update_checks();
            get_languages();
            update_language(Properties.Settings.Default.language);

            string txt = langStr["LoadStuff_textBox1"];
            txt = txt.Replace("[NL]", "\r\n");

            // textBox1.Text = txt + "...\r\n";
            //run_cmd("pip show spleeter"); // 7/10/2023 no pip now
            string spleet = "";
            if (Directory.Exists(path_python))
            {
                string[] dirs = Directory.GetDirectories(path_python, "spleeter-*", SearchOption.TopDirectoryOnly);
                foreach (string dir in dirs)
                {
                    spleet = dir;
                    spleet = spleet.Replace(path_python + "\\", "");
                    spleet = spleet.Replace(".dist-info", "");
                    textBox1.Text = txt + " [" + spleet + "]\r\n";
                }
            }
            else
            {
                //python directory not found - show message without crashing
                textBox1.Text = txt + " [Python/Spleeter not found - please set Python path in Help menu]\r\n";
            }
        }

        void get_languages()
        {
            //find and load language files into the custom dropdown
            var enviroment = Application.StartupPath;
            string[] fileEntries = Directory.GetFiles(enviroment + "\\languages");

            if (customLanguageDropdown != null)
            {
                customLanguageDropdown.Items.Clear();

                foreach (string fileName in fileEntries) {
                    string name = Path.GetFileName(fileName);
                    XmlDataDocument xmldoc = new XmlDataDocument();
                    XmlNodeList xmlnode;
                    FileStream fs = new FileStream(enviroment + "\\languages\\" + name, FileMode.Open, FileAccess.Read);
                    xmldoc.Load(fs);
                    xmlnode = xmldoc.GetElementsByTagName("language");
                    string lang_text = xmlnode[0].ChildNodes.Item(0).InnerText.Trim();

                    string displayText = lang_text + " (" + name.Replace(".xml","") + ")";
                    customLanguageDropdown.Items.Add(displayText);

                    // Set default selection if this matches the current language
                    if (name.Replace(".xml", "") == Properties.Settings.Default.language)
                    {
                        customLanguageDropdown.SelectedIndex = customLanguageDropdown.Items.Count - 1;
                    }

                    fs.Close();
                }

                // If no language was selected, select the first one
                if (customLanguageDropdown.SelectedIndex == -1 && customLanguageDropdown.Items.Count > 0)
                {
                    customLanguageDropdown.SelectedIndex = 0;
                }
            }
        }



        void update_language(string lang_name)
        {
            // Read the XML language files, iterate through menu's & controls and update labels.
            Properties.Settings.Default.language = lang_name;
            Properties.Settings.Default.Save();
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            string control_name = null;
            string control_label = null;
            var enviroment = Application.StartupPath;
            FileStream fs = new FileStream(enviroment + "\\languages\\" + lang_name + ".xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("item");  //load control texts
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                control_label = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                control_name = xmlnode[i].Attributes["control"].InnerText;

                Control ctn = Controls.Find(control_name, true)[0];
                ctn.Text = control_label;
            }
            // Menu handling removed - using custom dropdown instead
            xmlnode = xmldoc.GetElementsByTagName("lang");  //load all the program texts
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                control_label = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                control_name = xmlnode[i].Attributes["control"].InnerText;
                langStr[control_name] = control_label;
            }
            progress_txt.Text = langStr["idle"];
        }

        private void SetupModernDragDrop()
        {
            // Add modern drag and drop styling to file input panel
            pnlFileInput.Paint += (s, e) => DrawModernDragDropArea(e, pnlFileInput);
        }

        private void DrawModernDragDropArea(PaintEventArgs e, Panel panel)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw dashed border for drag and drop area
            using (Pen dashedPen = new Pen(Color.FromArgb(100, 150, 150, 150), 2))
            {
                dashedPen.DashStyle = DashStyle.Dash;
                Rectangle borderRect = new Rectangle(10, 10, panel.Width - 20, panel.Height - 20);

                // Create rounded rectangle path
                GraphicsPath borderPath = new GraphicsPath();
                int radius = 8;
                borderPath.AddArc(borderRect.X, borderRect.Y, radius, radius, 180, 90);
                borderPath.AddArc(borderRect.X + borderRect.Width - radius, borderRect.Y, radius, radius, 270, 90);
                borderPath.AddArc(borderRect.X + borderRect.Width - radius, borderRect.Y + borderRect.Height - radius, radius, radius, 0, 90);
                borderPath.AddArc(borderRect.X, borderRect.Y + borderRect.Height - radius, radius, radius, 90, 90);
                borderPath.CloseAllFigures();

                g.DrawPath(dashedPen, borderPath);
            }
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void FileInput_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                // Change panel appearance for drag feedback
                pnlFileInput.BackColor = Color.FromArgb(60, 60, 65);
                pnlFileInput.Invalidate();
            }
        }

        void FileInput_DragLeave(object sender, EventArgs e)
        {
            // Restore original panel appearance
            pnlFileInput.BackColor = Color.FromArgb(45, 45, 48);
            pnlFileInput.Invalidate();
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            //music files have been dropped on the app, start processing them
            if (files_remain == 0)
            {
                textBox1.Text = "";
                if (txt_output_directory.Text == "")
                {
                    MessageBox.Show(langStr["output_message"]);
                    return;
                }

                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                files_remain = 0;
                foreach (string file in files)
                {
                    files_to_process.Add(file);
                    files_remain++;
                }
                textBox1.AppendText(langStr["starting_all"] + "\r\n");
                progressBar1.Maximum = files_remain + 1;
                progressBar1.Value = 0; 
                progress_txt.Text = langStr["starting"] + "..." + files_remain + " " + langStr["songs_remaining"];
                next_song();
            }
            else
            {
                System.Media.SystemSounds.Asterisk.Play();
            }
        }
   
        private void next_song()
        {
            //begins the spleeting function on the next song in the queue
            if (files_remain > 0)
            {
                run_silent = false;
                //string pyPath = storage + @"\python\python.exe";
                string pyPath = path_python + @"\python.exe";
                
                string filename = files_to_process[0];
                
                progressBar1.Value = progressBar1.Value + 1;
                System.IO.File.WriteAllText(storage + @"\config.json", get_config_string());
                textBox1.AppendText(langStr["processing"] + " " + filename + "\r\n");
                progress_txt.Text = langStr["working"] + "..." + files_remain + " "+ langStr["songs_remaining"];

                ProcessStartInfo processStartInfo = new ProcessStartInfo(pyPath, @" -W ignore -m spleeter separate  -o " + (char)34 + txt_output_directory.Text + (char)34 + " -d " + (duration.Value).ToString() + " -p " + (char)34 + storage + @"\config.json" + (char)34 + " " + (char)34 + filename + (char)34);

                processStartInfo.WorkingDirectory = storage;

                processStartInfo.UseShellExecute = false;
                processStartInfo.ErrorDialog = false;
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.RedirectStandardError = true;
                processStartInfo.CreateNoWindow = true;

                files_to_process.Remove(filename);

                Process process = new Process();
                process.StartInfo = processStartInfo;
                process.EnableRaisingEvents = true;
                process.Exited += new EventHandler(ProcessExited);
                process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
                process.ErrorDataReceived += new DataReceivedEventHandler(ErrorHandler);
                try
                {
                    bool processStarted = process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    current_songname = Path.GetFileNameWithoutExtension(filename);
                }
                catch
                {
                    MessageBox.Show("Error: unable to find python.exe");
                }
            }
            else
            {
                current_songname = "";
                progress_txt.Text = langStr["idle"];
                textBox1.AppendText(langStr["finished"] + "\r\n");
                progressBar1.Value = progressBar1.Maximum;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void run_cmd(String cmd)
        {
            //general function for executing python commands.
            try
            {
                ProcessStartInfo processStartInfo;
                string pyPath = path_python + @"\python.exe";

                processStartInfo = new ProcessStartInfo(pyPath, @" -W ignore -m " + cmd);
                processStartInfo.WorkingDirectory = storage;

                processStartInfo.UseShellExecute = false;
                processStartInfo.ErrorDialog = false;
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.RedirectStandardError = true;
                processStartInfo.CreateNoWindow = true;
                Process process = new Process();
                process.StartInfo = processStartInfo;
                process.EnableRaisingEvents = true;
                process.Exited += new EventHandler(ProcessExited);
                process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
                process.ErrorDataReceived += new DataReceivedEventHandler(ErrorHandler);

                bool processStarted = process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
            }
            catch
            {
                MessageBox.Show("Unable to find python.exe");
            }
        }
        private void run_recombine(String args)
        {
            //executes the ffmpeg comand to recombine the output stems
            ProcessStartInfo processStartInfo = new ProcessStartInfo(storage + @"\ffmpeg.exe", args);
            processStartInfo.WorkingDirectory = storage;

            processStartInfo.UseShellExecute = false;
            processStartInfo.ErrorDialog = false;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.CreateNoWindow = true;
            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.EnableRaisingEvents = true;
            process.Exited += new EventHandler(run_recombineExited);
            process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            process.ErrorDataReceived += new DataReceivedEventHandler(ErrorHandler);
            bool processStarted = process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
        }
        void OutputHandler(object sender, DataReceivedEventArgs e)
        {
            //output handler called by run_cmd
            this.BeginInvoke(new MethodInvoker(() =>
            {
                if (!String.IsNullOrEmpty(e.Data))
                {
                    if (txt_check(e.Data))   //Please don't email Deezer about problems with this GUI app.
                    {
                        textBox1.AppendText(e.Data.TrimEnd('\r', '\n') + "\r\n");
                    }
                }
            }));
        }
        bool txt_check(string txt)  //prevent output
        {
            bool allow = true;
            if (txt.IndexOf("Author-email") !=-1){ allow = false; }
            if (txt.IndexOf("Summary:") != -1) { allow = false; }
            if (txt.IndexOf("source separation library") != -1) { allow = false; }
            if (txt.IndexOf("models based on") != -1) { allow = false; }
            if (txt.IndexOf("Home-page:") != -1) { allow = false; }
            if (txt.IndexOf("Author:") != -1) { allow = false; }
            if (txt.IndexOf("License:") != -1) { allow = false; }
            if (txt.IndexOf("Location:") != -1) { allow = false; }
            if (txt.IndexOf("Requires:") != -1) { allow = false; }
            if (txt.IndexOf("Required-by:") != -1) { allow = false; }
            return allow;
        }
        void ErrorHandler(object sender, DataReceivedEventArgs e)
        {
            //handles errors from the run_cmd functions
            this.BeginInvoke(new MethodInvoker(() =>
            {
                if (!String.IsNullOrEmpty(e.Data))
                {
                    textBox1.AppendText(e.Data.TrimEnd('\r', '\n') + "\r\n");
                }
            }));
        }
        private void run_recombineExited(object sender, EventArgs e)
        {
            //cleanup function called by run_recombine
            Invoke((Action)(() =>
            {
                //do nothing
            }));
        }

        private void ProcessExited(object sender, EventArgs e)
        {
            //called by run_cmd when thread exits after spleeting a song. runs the recombine (if enabled) and starts processing next song in queue.
            Invoke((Action)(() =>
            {
                //recombine audio (if enabled)
                if (
                    current_songname!="" &&
                    chkRecombine.Checked == true && (
                    chkRPartVocal.Checked ||
                    chkRPartBass.Checked ||
                    chkRPartDrums.Checked ||
                    chkRPartPiano.Checked ||
                    chkRPartOther.Checked)
                    )
                {
                    String recomnbine_command = "";
                    int input_count = 0;
                    if (chkRPartVocal.Checked) { input_count++; recomnbine_command += " -i " + (char)34 + txt_output_directory.Text + @"\" + current_songname + @"\vocals.wav" + (char)34; }
                    if (chkRPartBass.Checked) { input_count++; recomnbine_command += " -i " + (char)34 + txt_output_directory.Text + @"\" + current_songname + @"\bass.wav" + (char)34; }
                    if (chkRPartDrums.Checked) { input_count++; recomnbine_command += " -i " + (char)34 + txt_output_directory.Text + @"\" + current_songname + @"\drums.wav" + (char)34; }
                    if (chkRPartPiano.Checked) { input_count++; recomnbine_command += " -i " + (char)34 + txt_output_directory.Text + @"\" + current_songname + @"\piano.wav" + (char)34; }
                    if (chkRPartOther.Checked) { input_count++; recomnbine_command += " -i " + (char)34 + txt_output_directory.Text + @"\" + current_songname + @"\other.wav" + (char)34; }
                    if (recomnbine_command != "")
                    {
                        String filter_a = "";
                        String filter_b = "";
                        for (int i = 0; i < input_count; i++)
                        {
                            filter_a += "["+i+"]volume=" + input_count + "["+((char)97+i) +"];";
                            filter_b += "[" + ((char)97 + i) + "]";
                        }
                        recomnbine_command = recomnbine_command + " -filter_complex " + (char)34 + filter_a + filter_b + "amix=inputs=" + input_count.ToString() + ":duration =longest" + (char)34 + " " + (char)34 + txt_output_directory.Text + @"\" + current_songname + "_recombined.wav" + (char)34;
                        run_recombine(recomnbine_command);
                    }
                }

                files_remain--;
                if (files_remain > -1) { 
                    //start processing the next song
                    next_song();
                }
                if (files_remain < 0) files_remain = 0;
                
                if (!run_silent)
                {
                    textBox1.AppendText("\r\n" + langStr["run_complete"] + "\r\n");
                    System.Media.SystemSounds.Beep.Play();
                }
            }));
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //prompt user for output folder
            var folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.Description = langStr["set_output"];
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txt_output_directory.Text = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.output_location = txt_output_directory.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                txt_output_directory.Text = "";
            }
        }
        private void setPythonPathToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //prompt user for python path
            var folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = storage;
            folderBrowserDialog1.Description = langStr["set_python_path"];
            folderBrowserDialog1.ShowNewFolderButton = false;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                path_python = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.path_python = path_python;
                Properties.Settings.Default.Save();
                LoadStuff();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private string get_config_string()
        {
            //reads the JSON config file for the current stem mode
            var enviroment = Application.StartupPath;
            string readText = File.ReadAllText(enviroment + @"\configs\" + stem_count + "stems.json");
            if (mask_extension == "average")
            {
                readText = readText.Replace("zeros", "average");
            }
            return readText;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //sets the full bandwidth mode (16Khz)
            mask_extension = chkFullBandwidth.Checked ? "average" : "zeros";
        }

        private void spleeterGithubPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This method is no longer used - menu removed
        }

        private void makenItSoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //help - open's the Maken it so youtube channel in a browser window
            System.Diagnostics.Process.Start("https://www.youtube.com/user/mitchellcj/videos");
        }

        private void helpFAQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This method is no longer used - menu removed
        }

        private void parts_btn2_Click(object sender, EventArgs e)
        {
            //set the stem mode to 2
            parts_label.Text = langStr["vocal_accompaniment"];
            stem_count = "2";
            update_checks();
            UpdateButtonSelection();
        }

        private void parts_btn4_Click(object sender, EventArgs e)
        {
            //set the stem mode to 4
            parts_label.Text = langStr["vocal_bass_drums_other"];
            stem_count = "4";
            update_checks();
            UpdateButtonSelection();
        }

        private void parts_btn5_Click(object sender, EventArgs e)
        {
            //set the stem mode to 5
            parts_label.Text = langStr["vocal_bass_drums_piano_other"];
            stem_count = "5";
            update_checks();
            UpdateButtonSelection();
        }

        private void ApplyModernStyling()
        {
            // Apply modern styling to all panels and controls
            ApplyRoundedCorners();
            ApplyModernColors();
            ApplyButtonStyling();

            // Set initial button selection
            UpdateButtonSelection();
        }

        private void ApplyRoundedCorners()
        {
            // Apply rounded corners to panels
            SetRoundedCorners(pnlHeader, 12);
            SetRoundedCorners(pnlSeparationOptions, 12);
            SetRoundedCorners(pnlFileInput, 12);
            SetRoundedCorners(pnlOutput, 12);
            SetRoundedCorners(pnlMain, 12);

            // Apply rounded corners to buttons
            SetRoundedButton(parts_btn2, 8);
            SetRoundedButton(parts_btn4, 8);
            SetRoundedButton(parts_btn5, 8);
            SetRoundedButton(btnSelectFiles, 8);
            SetRoundedButton(btnSaveTo, 8);
        }

        private void SetRoundedCorners(Control control, int radius)
        {
            // Apply pixel-perfect rounded corners with advanced anti-aliasing
            control.Paint += (s, e) => {
                DrawPixelPerfectRoundedBackground(e.Graphics, control.ClientRectangle, radius, control.BackColor);
            };
        }

        private void DrawPixelPerfectRoundedBackground(Graphics g, Rectangle rect, int radius, Color backgroundColor)
        {
            // Enable maximum quality rendering for pixel-perfect results
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Create pixel-perfect rounded rectangle path
            using (GraphicsPath path = CreatePixelPerfectRoundedRectangle(rect, radius))
            {
                // Gradient background for depth
                using (LinearGradientBrush brush = new LinearGradientBrush(rect, backgroundColor,
                    Color.FromArgb(Math.Max(0, backgroundColor.R - 8), Math.Max(0, backgroundColor.G - 8), Math.Max(0, backgroundColor.B - 8)),
                    LinearGradientMode.Vertical))
                {
                    g.FillPath(brush, path);
                }

                // Subtle inner highlight for modern look
                using (Pen highlightPen = new Pen(Color.FromArgb(30, 255, 255, 255), 1))
                {
                    Rectangle innerRect = new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3);
                    using (GraphicsPath innerPath = CreatePixelPerfectRoundedRectangle(innerRect, radius - 1))
                    {
                        g.DrawPath(highlightPen, innerPath);
                    }
                }
            }
        }

        private GraphicsPath CreatePixelPerfectRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            // Use floating point for pixel-perfect curves
            float r = Math.Min(radius, Math.Min(rect.Width / 2f, rect.Height / 2f));

            if (r <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            // Precise floating point coordinates for smooth anti-aliasing
            RectangleF rectF = new RectangleF(rect.X + 0.5f, rect.Y + 0.5f, rect.Width - 1, rect.Height - 1);

            path.AddArc(rectF.X, rectF.Y, r * 2, r * 2, 180, 90);
            path.AddArc(rectF.Right - r * 2, rectF.Y, r * 2, r * 2, 270, 90);
            path.AddArc(rectF.Right - r * 2, rectF.Bottom - r * 2, r * 2, r * 2, 0, 90);
            path.AddArc(rectF.X, rectF.Bottom - r * 2, r * 2, r * 2, 90, 90);
            path.CloseAllFigures();

            return path;
        }

        private void SetRoundedButton(Button button, int radius)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;

            // Apply pixel-perfect button rendering
            button.Paint += (s, e) => {
                DrawPixelPerfectRoundedButton(e.Graphics, button.ClientRectangle, radius, button.BackColor, button.Text, button.Font, button.ForeColor);
            };
        }

        private void DrawPixelPerfectRoundedButton(Graphics g, Rectangle rect, int radius, Color backgroundColor, string text, Font font, Color textColor)
        {
            // Enable maximum quality rendering
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Create pixel-perfect rounded rectangle
            using (GraphicsPath path = CreatePixelPerfectRoundedRectangle(rect, radius))
            {
                // Gradient background for depth
                using (LinearGradientBrush brush = new LinearGradientBrush(rect, backgroundColor,
                    Color.FromArgb(Math.Max(0, backgroundColor.R - 15), Math.Max(0, backgroundColor.G - 15), Math.Max(0, backgroundColor.B - 15)),
                    LinearGradientMode.Vertical))
                {
                    g.FillPath(brush, path);
                }

                // Subtle border
                using (Pen borderPen = new Pen(Color.FromArgb(50, 255, 255, 255), 1))
                {
                    g.DrawPath(borderPen, path);
                }
            }

            // High-quality text rendering with shadow
            if (!string.IsNullOrEmpty(text))
            {
                // Text shadow for depth
                using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 0)))
                {
                    Rectangle shadowRect = new Rectangle(rect.X + 1, rect.Y + 1, rect.Width, rect.Height);
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center,
                        FormatFlags = StringFormatFlags.NoWrap
                    };
                    g.DrawString(text, font, shadowBrush, shadowRect, sf);
                }

                // Main text
                using (SolidBrush textBrush = new SolidBrush(textColor))
                {
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center,
                        FormatFlags = StringFormatFlags.NoWrap
                    };
                    g.DrawString(text, font, textBrush, rect, sf);
                }
            }
        }

        private void ApplyModernColors()
        {
            // Apply gradient backgrounds and modern colors
            this.BackColor = Color.FromArgb(24, 24, 24);

            // Header with gradient and shadow
            pnlHeader.Paint += (s, e) => {
                DrawShadow(e, pnlHeader);
                DrawGradientPanel(e, pnlHeader, Color.FromArgb(45, 45, 48), Color.FromArgb(37, 37, 38));
            };

            // Panels with subtle gradients and shadows
            pnlSeparationOptions.Paint += (s, e) => {
                DrawShadow(e, pnlSeparationOptions);
                DrawGradientPanel(e, pnlSeparationOptions, Color.FromArgb(45, 45, 48), Color.FromArgb(40, 40, 43));
            };

            pnlFileInput.Paint += (s, e) => {
                DrawShadow(e, pnlFileInput);
                DrawGradientPanel(e, pnlFileInput, Color.FromArgb(45, 45, 48), Color.FromArgb(40, 40, 43));
            };

            pnlOutput.Paint += (s, e) => {
                DrawShadow(e, pnlOutput);
                DrawGradientPanel(e, pnlOutput, Color.FromArgb(45, 45, 48), Color.FromArgb(40, 40, 43));
            };

            pnlMain.Paint += (s, e) => {
                DrawShadow(e, pnlMain);
                DrawGradientPanel(e, pnlMain, Color.FromArgb(30, 30, 30), Color.FromArgb(25, 25, 25));
            };
        }

        private void DrawShadow(PaintEventArgs e, Panel panel)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Create shadow effect
            Rectangle shadowRect = new Rectangle(3, 3, panel.Width - 3, panel.Height - 3);
            using (GraphicsPath shadowPath = CreateRoundedRectanglePath(shadowRect, 12))
            {
                using (PathGradientBrush shadowBrush = new PathGradientBrush(shadowPath))
                {
                    shadowBrush.CenterColor = Color.FromArgb(50, 0, 0, 0);
                    shadowBrush.SurroundColors = new Color[] { Color.FromArgb(0, 0, 0, 0) };
                    g.FillPath(shadowBrush, shadowPath);
                }
            }
        }

        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            return path;
        }

        private void SetupCustomTitleBar()
        {
            // Add window dragging capability to header panel
            bool isDragging = false;
            Point lastCursor = Point.Empty;
            Point lastForm = Point.Empty;

            pnlHeader.MouseDown += (s, e) => {
                if (e.Button == MouseButtons.Left)
                {
                    isDragging = true;
                    lastCursor = Cursor.Position;
                    lastForm = this.Location;
                }
            };

            pnlHeader.MouseMove += (s, e) => {
                if (isDragging)
                {
                    Point currentCursor = Cursor.Position;
                    Point offset = new Point(currentCursor.X - lastCursor.X, currentCursor.Y - lastCursor.Y);
                    this.Location = new Point(lastForm.X + offset.X, lastForm.Y + offset.Y);
                }
            };

            pnlHeader.MouseUp += (s, e) => {
                isDragging = false;
            };

            // Add close button to header
            Button closeButton = new Button();
            closeButton.Text = "✕";
            closeButton.Size = new Size(30, 30);
            closeButton.Location = new Point(pnlHeader.Width - 35, 5);
            closeButton.BackColor = Color.Transparent;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.ForeColor = Color.White;
            closeButton.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            closeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            closeButton.MouseEnter += (s, e) => closeButton.BackColor = Color.FromArgb(232, 17, 35);
            closeButton.MouseLeave += (s, e) => closeButton.BackColor = Color.Transparent;
            closeButton.Click += (s, e) => this.Close();

            pnlHeader.Controls.Add(closeButton);

            // Add minimize button
            Button minimizeButton = new Button();
            minimizeButton.Text = "−";
            minimizeButton.Size = new Size(30, 30);
            minimizeButton.Location = new Point(pnlHeader.Width - 70, 5);
            minimizeButton.BackColor = Color.Transparent;
            minimizeButton.FlatStyle = FlatStyle.Flat;
            minimizeButton.FlatAppearance.BorderSize = 0;
            minimizeButton.ForeColor = Color.White;
            minimizeButton.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            minimizeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            minimizeButton.MouseEnter += (s, e) => minimizeButton.BackColor = Color.FromArgb(60, 60, 60);
            minimizeButton.MouseLeave += (s, e) => minimizeButton.BackColor = Color.Transparent;
            minimizeButton.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            pnlHeader.Controls.Add(minimizeButton);
        }

        private void ApplyFormRoundedCorners()
        {
            // Apply rounded corners to the entire form
            GraphicsPath path = new GraphicsPath();
            int radius = 15;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            this.Region = new Region(path);
        }

        private void DrawGradientPanel(PaintEventArgs e, Panel panel, Color startColor, Color endColor)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                panel.ClientRectangle, startColor, endColor, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, panel.ClientRectangle);
            }
        }

        private void ApplyButtonStyling()
        {
            // Apply modern button effects
            ApplyButtonHoverEffects(parts_btn2);
            ApplyButtonHoverEffects(parts_btn4);
            ApplyButtonHoverEffects(parts_btn5);
            ApplyButtonHoverEffects(btnSelectFiles);
            ApplyButtonHoverEffects(btnSaveTo);
        }

        private void ApplyButtonHoverEffects(Button button)
        {
            Color originalColor = button.BackColor;

            button.MouseEnter += (s, e) => {
                button.BackColor = Color.FromArgb(
                    Math.Min(255, originalColor.R + 30),
                    Math.Min(255, originalColor.G + 30),
                    Math.Min(255, originalColor.B + 30));
            };

            button.MouseLeave += (s, e) => {
                button.BackColor = originalColor;
            };

            button.MouseDown += (s, e) => {
                button.BackColor = Color.FromArgb(
                    Math.Max(0, originalColor.R - 20),
                    Math.Max(0, originalColor.G - 20),
                    Math.Max(0, originalColor.B - 20));
            };

            button.MouseUp += (s, e) => {
                button.BackColor = originalColor;
            };
        }

        private void UpdateButtonSelection()
        {
            // Reset all buttons to default style
            parts_btn2.BackColor = Color.FromArgb(62, 62, 66);
            parts_btn4.BackColor = Color.FromArgb(62, 62, 66);
            parts_btn5.BackColor = Color.FromArgb(62, 62, 66);

            // Highlight selected button
            switch (stem_count)
            {
                case "2":
                    parts_btn2.BackColor = Color.FromArgb(0, 122, 204);
                    break;
                case "4":
                    parts_btn4.BackColor = Color.FromArgb(0, 122, 204);
                    break;
                case "5":
                    parts_btn5.BackColor = Color.FromArgb(0, 122, 204);
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //choose a song(s) to spleet
            if (files_remain == 0)
            {
                openFileDialog2.ShowDialog();
            }
            else
            {
                System.Media.SystemSounds.Asterisk.Play();
            }
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            //files chosen, start spleeting
            if (files_remain == 0)
            {
                if (txt_output_directory.Text == "")
                {
                    MessageBox.Show(langStr["output_message"]);
                    return;
                }
                textBox1.Text = "";
                files_remain = 0;
                foreach (String file in openFileDialog2.FileNames)
                {
                    files_to_process.Add(file);
                    files_remain++;
                }
                textBox1.AppendText(langStr["starting_all"] + "\r\n");
                progressBar1.Maximum = files_remain + 1;
                progressBar1.Value = 0;
                progress_txt.Text = langStr["starting"] + "..." + files_remain + " " + langStr["songs_remaining"];
                next_song();
            }
        }

        private void spleeterupgradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //help - spleeter core upgrade
            run_silent = false;
            current_songname = "";
            textBox1.Text = langStr["run_update"] + "\r\n" + langStr["run_update_b"] + "\r\n\r\n";
            run_cmd("pip install --upgrade spleeter");
        }

        private void checkSpleeterGUIUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This method is no longer used - menu removed and version checking disabled
        }

        private void chkRecombine_CheckedChanged(object sender, EventArgs e)
        {
            update_checks();
        }

        private void update_checks()
        {
            //update the user interface based on the chosen stem count
            chkRPartVocal.Checked = false;
            chkRPartBass.Checked = false;
            chkRPartDrums.Checked = false;
            chkRPartPiano.Checked = false;
            chkRPartOther.Checked = false;

            if (stem_count == "2")
            {
                chkRecombine.Checked = false;
                chkRecombine.Enabled = false;
                pnlRecombine.Visible = false;
                pnlSeparationOptions.Height = 70;
            }
            else
            {
                chkRecombine.Enabled = true;
                pnlRecombine.Visible = true;

                if (chkRecombine.Checked)
                {
                    pnlRecombine.Height = 70;
                    pnlSeparationOptions.Height = 140;
                }
                else
                {
                    pnlRecombine.Height = 70;
                    pnlSeparationOptions.Height = 140;

                    chkRPartVocal.Checked = false;
                    chkRPartBass.Checked = false;
                    chkRPartDrums.Checked = false;
                    chkRPartPiano.Checked = false;
                    chkRPartOther.Checked = false;
                }
                switch (stem_count)
                {
                    case "4":
                        chkRPartVocal.Enabled = true;
                        chkRPartBass.Enabled = true;
                        chkRPartDrums.Enabled = true;
                        chkRPartPiano.Enabled = false;
                        chkRPartOther.Enabled = true;
                        break;
                    case "5":
                        chkRPartVocal.Enabled = true;
                        chkRPartBass.Enabled = true;
                        chkRPartDrums.Enabled = true;
                        chkRPartPiano.Enabled = true;
                        chkRPartOther.Enabled = true;
                        break;
                }
            }
        }

        private void duration_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.duration = Convert.ToInt32(duration.Value);
            Properties.Settings.Default.Save();
        }

        // Add pixel-perfect styling to NumericUpDown control
        private void StyleNumericUpDown(NumericUpDown control)
        {
            control.Paint += (s, e) => {
                DrawPixelPerfectNumericUpDown(e.Graphics, control.ClientRectangle, control.BackColor);
            };
        }

        private void DrawPixelPerfectNumericUpDown(Graphics g, Rectangle rect, Color backgroundColor)
        {
            // Enable maximum quality rendering
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Create pixel-perfect rounded rectangle
            using (GraphicsPath path = CreatePixelPerfectRoundedRectangle(rect, 6))
            {
                // Gradient background
                using (LinearGradientBrush brush = new LinearGradientBrush(rect,
                    Color.FromArgb(72, 72, 76), Color.FromArgb(52, 52, 56), LinearGradientMode.Vertical))
                {
                    g.FillPath(brush, path);
                }

                // Border with focus indication
                Color borderColor = Color.FromArgb(120, 120, 120);
                using (Pen borderPen = new Pen(borderColor, 1))
                {
                    g.DrawPath(borderPen, path);
                }

                // Inner highlight
                Rectangle innerRect = new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3);
                using (Pen highlightPen = new Pen(Color.FromArgb(40, 255, 255, 255), 1))
                {
                    using (GraphicsPath innerPath = CreatePixelPerfectRoundedRectangle(innerRect, 5))
                    {
                        g.DrawPath(highlightPen, innerPath);
                    }
                }
            }
        }

        // Custom Language Dropdown
        private CustomLanguageDropdown customLanguageDropdown;

        private void CreateCustomLanguageDropdown()
        {
            customLanguageDropdown = new CustomLanguageDropdown();
            customLanguageDropdown.Location = new Point(600, 25); // Top-right of header
            customLanguageDropdown.Size = new Size(180, 35);
            customLanguageDropdown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            customLanguageDropdown.SelectedIndexChanged += CustomLanguageDropdown_SelectedIndexChanged;

            pnlHeader.Controls.Add(customLanguageDropdown);
            customLanguageDropdown.BringToFront();
        }

        private void CustomLanguageDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customLanguageDropdown.SelectedItem != null)
            {
                string selectedText = customLanguageDropdown.SelectedItem.ToString();
                string langCode = selectedText.Substring(selectedText.LastIndexOf('(') + 1).Replace(")", "");
                update_language(langCode);
            }
        }
    }

    // Custom Language Dropdown Control with beautiful design
    public class CustomLanguageDropdown : Control
    {
        private List<string> items = new List<string>();
        private int selectedIndex = -1;
        private bool isDroppedDown = false;
        private int dropdownHeight = 250;
        private int itemHeight = 32;
        private Form dropdownForm;
        private bool isHovered = false;

        public event EventHandler SelectedIndexChanged;

        public List<string> Items => items;
        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                if (value >= -1 && value < items.Count)
                {
                    selectedIndex = value;
                    Invalidate();
                    SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public string SelectedItem => selectedIndex >= 0 && selectedIndex < items.Count ? items[selectedIndex] : null;

        public CustomLanguageDropdown()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                    ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw |
                    ControlStyles.SupportsTransparentBackColor, true);
            Size = new Size(180, 35);
            Cursor = Cursors.Hand;
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawCustomLanguageDropdown(e.Graphics);
        }

        private void DrawCustomLanguageDropdown(Graphics g)
        {
            // Enable maximum quality rendering
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            // Background gradient with hover effect
            Color startColor = isHovered ? Color.FromArgb(85, 85, 90) : Color.FromArgb(75, 75, 80);
            Color endColor = isHovered ? Color.FromArgb(65, 65, 70) : Color.FromArgb(55, 55, 60);

            using (LinearGradientBrush bgBrush = new LinearGradientBrush(rect, startColor, endColor, LinearGradientMode.Vertical))
            {
                using (GraphicsPath path = CreatePixelPerfectRoundedRectangle(rect, 10))
                {
                    g.FillPath(bgBrush, path);
                }
            }

            // Outer glow effect
            using (Pen glowPen = new Pen(Color.FromArgb(40, 0, 122, 204), 2))
            {
                Rectangle glowRect = new Rectangle(-1, -1, Width + 1, Height + 1);
                using (GraphicsPath glowPath = CreatePixelPerfectRoundedRectangle(glowRect, 11))
                {
                    g.DrawPath(glowPen, glowPath);
                }
            }

            // Main border
            using (Pen borderPen = new Pen(Color.FromArgb(140, 140, 140), 1))
            {
                using (GraphicsPath path = CreatePixelPerfectRoundedRectangle(rect, 10))
                {
                    g.DrawPath(borderPen, path);
                }
            }

            // Inner highlight
            Rectangle innerRect = new Rectangle(1, 1, Width - 3, Height - 3);
            using (Pen highlightPen = new Pen(Color.FromArgb(60, 255, 255, 255), 1))
            {
                using (GraphicsPath innerPath = CreatePixelPerfectRoundedRectangle(innerRect, 9))
                {
                    g.DrawPath(highlightPen, innerPath);
                }
            }

            // Globe icon
            DrawGlobeIcon(g, new Rectangle(12, 8, 20, 20));

            // Text with shadow
            string displayText = SelectedItem ?? "🌐 Language";

            // Text shadow
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(120, 0, 0, 0)))
            {
                Rectangle shadowRect = new Rectangle(39, 1, Width - 55, Height);
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.NoWrap
                };
                g.DrawString(displayText, new Font("Segoe UI", 10F, FontStyle.Regular), shadowBrush, shadowRect, sf);
            }

            // Main text
            using (SolidBrush textBrush = new SolidBrush(Color.White))
            {
                Rectangle textRect = new Rectangle(38, 0, Width - 55, Height);
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.NoWrap
                };
                g.DrawString(displayText, new Font("Segoe UI", 10F, FontStyle.Regular), textBrush, textRect, sf);
            }

            // Dropdown arrow with animation
            DrawAnimatedDropdownArrow(g);
        }

        private void DrawGlobeIcon(Graphics g, Rectangle iconRect)
        {
            // Draw a stylized globe icon
            using (Pen globePen = new Pen(Color.FromArgb(0, 122, 204), 2))
            {
                // Outer circle
                g.DrawEllipse(globePen, iconRect);

                // Vertical line
                int centerX = iconRect.X + iconRect.Width / 2;
                g.DrawLine(globePen, centerX, iconRect.Y + 2, centerX, iconRect.Bottom - 2);

                // Horizontal lines
                int centerY = iconRect.Y + iconRect.Height / 2;
                g.DrawLine(globePen, iconRect.X + 3, centerY, iconRect.Right - 3, centerY);
                g.DrawLine(globePen, iconRect.X + 5, iconRect.Y + 6, iconRect.Right - 5, iconRect.Y + 6);
                g.DrawLine(globePen, iconRect.X + 5, iconRect.Bottom - 6, iconRect.Right - 5, iconRect.Bottom - 6);
            }
        }

        private void DrawAnimatedDropdownArrow(Graphics g)
        {
            int arrowSize = 10;
            int arrowX = Width - 25;
            int arrowY = Height / 2;

            Point[] arrowPoints = {
                new Point(arrowX - arrowSize/2, arrowY - arrowSize/4),
                new Point(arrowX + arrowSize/2, arrowY - arrowSize/4),
                new Point(arrowX, arrowY + arrowSize/2)
            };

            // Arrow shadow
            Point[] shadowPoints = arrowPoints.Select(p => new Point(p.X + 1, p.Y + 1)).ToArray();
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(120, 0, 0, 0)))
            {
                g.FillPolygon(shadowBrush, shadowPoints);
            }

            // Main arrow with gradient
            using (LinearGradientBrush arrowBrush = new LinearGradientBrush(
                new Rectangle(arrowX - arrowSize/2, arrowY - arrowSize/2, arrowSize, arrowSize),
                Color.FromArgb(240, 240, 240), Color.FromArgb(200, 200, 200), LinearGradientMode.Vertical))
            {
                g.FillPolygon(arrowBrush, arrowPoints);
            }
        }

        private GraphicsPath CreatePixelPerfectRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float r = Math.Min(radius, Math.Min(rect.Width / 2f, rect.Height / 2f));

            if (r <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            RectangleF rectF = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);

            path.AddArc(rectF.X, rectF.Y, r * 2, r * 2, 180, 90);
            path.AddArc(rectF.Right - r * 2, rectF.Y, r * 2, r * 2, 270, 90);
            path.AddArc(rectF.Right - r * 2, rectF.Bottom - r * 2, r * 2, r * 2, 0, 90);
            path.AddArc(rectF.X, rectF.Bottom - r * 2, r * 2, r * 2, 90, 90);
            path.CloseAllFigures();

            return path;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            isHovered = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            isHovered = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnClick(EventArgs e)
        {
            ToggleDropdown();
            base.OnClick(e);
        }

        private void ToggleDropdown()
        {
            if (isDroppedDown)
            {
                CloseDropdown();
            }
            else
            {
                OpenDropdown();
            }
        }

        private void OpenDropdown()
        {
            if (items.Count == 0) return;

            isDroppedDown = true;

            // Create dropdown form
            dropdownForm = new Form();
            dropdownForm.FormBorderStyle = FormBorderStyle.None;
            dropdownForm.ShowInTaskbar = false;
            dropdownForm.StartPosition = FormStartPosition.Manual;
            dropdownForm.TopMost = true;

            Point screenLocation = PointToScreen(new Point(0, Height + 3));
            dropdownForm.Location = screenLocation;
            dropdownForm.Size = new Size(Width, Math.Min(dropdownHeight, items.Count * itemHeight + 6));
            dropdownForm.BackColor = Color.FromArgb(45, 45, 48);

            // Create custom list control
            CustomLanguageDropdownList listControl = new CustomLanguageDropdownList(items, selectedIndex, itemHeight);
            listControl.Dock = DockStyle.Fill;
            listControl.ItemSelected += (index) => {
                SelectedIndex = index;
                CloseDropdown();
            };

            dropdownForm.Controls.Add(listControl);
            dropdownForm.Deactivate += (s, e) => CloseDropdown();
            dropdownForm.Show();
        }

        private void CloseDropdown()
        {
            if (dropdownForm != null)
            {
                dropdownForm.Close();
                dropdownForm = null;
            }
            isDroppedDown = false;
        }
    }

    // Custom Language Dropdown List Control
    public class CustomLanguageDropdownList : Control
    {
        private List<string> items;
        private int selectedIndex;
        private int hoverIndex = -1;
        private int itemHeight;

        public event Action<int> ItemSelected;

        public CustomLanguageDropdownList(List<string> items, int selectedIndex, int itemHeight)
        {
            this.items = items;
            this.selectedIndex = selectedIndex;
            this.itemHeight = itemHeight;

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                    ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Background with gradient
            using (LinearGradientBrush bgBrush = new LinearGradientBrush(
                ClientRectangle, Color.FromArgb(55, 55, 58), Color.FromArgb(45, 45, 48), LinearGradientMode.Vertical))
            {
                g.FillRectangle(bgBrush, ClientRectangle);
            }

            // Border with glow
            using (Pen borderPen = new Pen(Color.FromArgb(140, 140, 140), 1))
            {
                g.DrawRectangle(borderPen, new Rectangle(0, 0, Width - 1, Height - 1));
            }

            // Inner shadow
            using (Pen shadowPen = new Pen(Color.FromArgb(60, 0, 0, 0), 1))
            {
                g.DrawRectangle(shadowPen, new Rectangle(1, 1, Width - 3, Height - 3));
            }

            // Draw items
            for (int i = 0; i < items.Count; i++)
            {
                Rectangle itemRect = new Rectangle(3, i * itemHeight + 3, Width - 6, itemHeight);

                // Draw item background
                if (i == hoverIndex)
                {
                    using (LinearGradientBrush hoverBrush = new LinearGradientBrush(
                        itemRect, Color.FromArgb(90, 90, 94), Color.FromArgb(80, 80, 84), LinearGradientMode.Vertical))
                    {
                        using (GraphicsPath path = CreateRoundedRectangle(itemRect, 6))
                        {
                            g.FillPath(hoverBrush, path);
                        }
                    }

                    // Hover glow
                    using (Pen hoverPen = new Pen(Color.FromArgb(80, 0, 122, 204), 1))
                    {
                        using (GraphicsPath path = CreateRoundedRectangle(itemRect, 6))
                        {
                            g.DrawPath(hoverPen, path);
                        }
                    }
                }
                else if (i == selectedIndex)
                {
                    using (LinearGradientBrush selectedBrush = new LinearGradientBrush(
                        itemRect, Color.FromArgb(0, 142, 224), Color.FromArgb(0, 102, 184), LinearGradientMode.Vertical))
                    {
                        using (GraphicsPath path = CreateRoundedRectangle(itemRect, 6))
                        {
                            g.FillPath(selectedBrush, path);
                        }
                    }
                }

                // Flag icon area
                Rectangle flagRect = new Rectangle(itemRect.X + 8, itemRect.Y + 6, 20, 20);
                DrawFlagPlaceholder(g, flagRect);

                // Draw item text with shadow
                Color textColor = (i == selectedIndex) ? Color.White : Color.FromArgb(230, 230, 230);

                // Text shadow
                using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(120, 0, 0, 0)))
                {
                    Rectangle shadowRect = new Rectangle(itemRect.X + 35, itemRect.Y + 1, itemRect.Width - 40, itemRect.Height);
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Center,
                        FormatFlags = StringFormatFlags.NoWrap
                    };
                    g.DrawString(items[i], new Font("Segoe UI", 9.5F), shadowBrush, shadowRect, sf);
                }

                // Main text
                using (SolidBrush textBrush = new SolidBrush(textColor))
                {
                    Rectangle textRect = new Rectangle(itemRect.X + 34, itemRect.Y, itemRect.Width - 40, itemRect.Height);
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Center,
                        FormatFlags = StringFormatFlags.NoWrap
                    };
                    g.DrawString(items[i], new Font("Segoe UI", 9.5F), textBrush, textRect, sf);
                }
            }
        }

        private void DrawFlagPlaceholder(Graphics g, Rectangle flagRect)
        {
            // Draw a simple flag placeholder
            using (LinearGradientBrush flagBrush = new LinearGradientBrush(
                flagRect, Color.FromArgb(0, 122, 204), Color.FromArgb(0, 84, 153), LinearGradientMode.Vertical))
            {
                using (GraphicsPath path = CreateRoundedRectangle(flagRect, 3))
                {
                    g.FillPath(flagBrush, path);
                }
            }

            // Flag border
            using (Pen flagPen = new Pen(Color.FromArgb(200, 200, 200), 1))
            {
                using (GraphicsPath path = CreateRoundedRectangle(flagRect, 3))
                {
                    g.DrawPath(flagPen, path);
                }
            }
        }

        private GraphicsPath CreateRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float r = Math.Min(radius, Math.Min(rect.Width / 2f, rect.Height / 2f));

            if (r <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            RectangleF rectF = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);

            path.AddArc(rectF.X, rectF.Y, r * 2, r * 2, 180, 90);
            path.AddArc(rectF.Right - r * 2, rectF.Y, r * 2, r * 2, 270, 90);
            path.AddArc(rectF.Right - r * 2, rectF.Bottom - r * 2, r * 2, r * 2, 0, 90);
            path.AddArc(rectF.X, rectF.Bottom - r * 2, r * 2, r * 2, 90, 90);
            path.CloseAllFigures();

            return path;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            int newHoverIndex = (e.Y - 3) / itemHeight;
            if (newHoverIndex != hoverIndex && newHoverIndex >= 0 && newHoverIndex < items.Count)
            {
                hoverIndex = newHoverIndex;
                Invalidate();
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            hoverIndex = -1;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnClick(EventArgs e)
        {
            if (hoverIndex >= 0 && hoverIndex < items.Count)
            {
                ItemSelected?.Invoke(hoverIndex);
            }
            base.OnClick(e);
        }
    }
}
