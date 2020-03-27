using System;
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
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(31)))));

            if (Directory.Exists(Path.Combine(Properties.Settings.Default.path, @"CustomSongs\")))
            {
                this.textBox1.Text = Properties.Settings.Default.path;
            }
            else
            {
                string reg = Encoding.Default.GetString((byte[])Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Kluge Interactive\SynthRiders", "com.synthriders.installpath_h4259148619", ""));
                reg = string.Concat(reg.Split(Path.GetInvalidPathChars()));
                if (Directory.Exists(Path.Combine(reg, @"CustomSongs\")))
                {
                    this.textBox1.Text = reg;
                }
                else
                {
                    this.textBox1.Text = @"C:\Program Files (x86)\Steam\steamapps\common\SynthRiders";

                    if (!Directory.Exists(Path.Combine(this.textBox1.Text, @"CustomSongs\")))
                    {
                        this.textBox1.BackColor = System.Drawing.Color.Red;
                        return false;
                    }
                }
            }
            return true;
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
            if (Directory.Exists(this.textBox1.Text + @"\CustomSongs\"))
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
            if (this.textBox1.Text == "" || !Directory.Exists(this.textBox1.Text + @"\CustomSongs\"))
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
            if (File.Exists(this.textBox1.Text + @"\favorites.bin"))
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
                Properties.Settings.Default.path = string.Concat(this.textBox1.Text.Split(Path.GetInvalidPathChars()));
                Properties.Settings.Default.Save();

                TwitchCredentialsWindow window = new TwitchCredentialsWindow();
                window.Show();
            }
        }
    }
}
