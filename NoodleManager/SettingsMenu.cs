﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace NoodleManager
{
    public partial class SettingsMenu : UserControl
    {
        public SettingsMenu()
        {
            InitializeComponent();

            this.textBox1.Text = Properties.Settings.Default.path;
        }

        public bool Check()
        {
            try
            {
                this.textBox1.BackColor = System.Drawing.Color.Red;

                if (!String.IsNullOrEmpty(this.textBox1.Text) && Path.GetDirectoryName(this.textBox1.Text) == "CustomSongs")
                {
                    this.textBox1.Text = Directory.GetParent(this.textBox1.Text).FullName;
                }

                if (String.IsNullOrEmpty(this.textBox1.Text) || !Directory.Exists(Path.Combine(this.textBox1.Text, @"CustomSongs\")))
                {
                    if (!String.IsNullOrEmpty(Properties.Settings.Default.path) && Directory.Exists(Path.Combine(Properties.Settings.Default.path, @"CustomSongs\")))
                    {
                        this.textBox1.Text = Properties.Settings.Default.path;
                    }
                    else
                    {
                        bool check = false;
                        byte[] tmp = (byte[])Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Kluge Interactive\SynthRiders", "com.synthriders.installpath_h4259148619", "");
                        if (tmp != null)
                        {
                            string reg = Encoding.Default.GetString(tmp);
                            reg = string.Concat(reg.Split(Path.GetInvalidPathChars()));
                            if (!String.IsNullOrEmpty(reg) && Directory.Exists(Path.Combine(reg, @"CustomSongs\")))
                            {
                                this.textBox1.Text = reg;
                                check = true;
                            }
                        }
                        if (!check)
                        {
                            if (Directory.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\SynthRiders\CustomSongs\"))
                            {
                                this.textBox1.Text = @"C:\Program Files (x86)\Steam\steamapps\common\SynthRiders\";
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }

                this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(31)))));
                Properties.Settings.Default.path = string.Concat(this.textBox1.Text.Split(Path.GetInvalidPathChars()));
                Properties.Settings.Default.Save();
                return true;
            }
            catch (Exception e)
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "Log.txt"), true))
                {
                    sw.WriteLine(e.ToString());
                }
                return false;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.SelectedPath = this.textBox1.Text;
            DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.textBox1.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://synthriderz.com/donate");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                Process getProcess = new Process();
                getProcess.StartInfo.UseShellExecute = false;
                getProcess.StartInfo.RedirectStandardOutput = true;
                getProcess.StartInfo.FileName = "get.bat";
                getProcess.Start();
                string output = getProcess.StandardOutput.ReadToEnd();
                getProcess.WaitForExit();

                foreach (string file in Directory.GetFiles(this.textBox1.Text + @"\CustomSongs\"))
                {
                    string f = file.Substring(file.LastIndexOf(@"\") + 1);
                    if (!output.Contains(f))
                    {
                        Process pushProcess = new Process();
                        pushProcess.StartInfo.UseShellExecute = false;
                        pushProcess.StartInfo.RedirectStandardOutput = false;
                        pushProcess.StartInfo.FileName = "push.bat";
                        pushProcess.StartInfo.Arguments = "\"" + this.textBox1.Text + @"\CustomSongs\" + f + "\"" + " " + @"/CustomSongs";
                        pushProcess.Start();
                        pushProcess.WaitForExit();
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (this.textBox1.Text == "" || !Check())
            {
                Directory.CreateDirectory("CustomSongs");
                this.textBox1.Text = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/EvsGyh9");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start("https://synthriderz.com/");
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (Check() && File.Exists(this.textBox1.Text + @"\favorites.bin"))
            {
                Process pushProcess = new Process();
                pushProcess.StartInfo.UseShellExecute = false;
                pushProcess.StartInfo.RedirectStandardOutput = false;
                pushProcess.StartInfo.FileName = "push.bat";
                pushProcess.StartInfo.Arguments = "\"" + this.textBox1.Text + @"\favorites.bin" + "\"";
                pushProcess.Start();
                pushProcess.WaitForExit();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Process.Start("https://teespring.com/stores/synthriderz");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                TwitchCredentialsWindow window = new TwitchCredentialsWindow();
                window.Show();
            }
        }
    }
}
