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

namespace NoodleManager
{
    public partial class SettingsMenu : UserControl
    {
        public SettingsMenu()
        {
            InitializeComponent();

            this.textBox1.Text = Properties.Settings.Default.path;
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
                        pushProcess.StartInfo.Arguments = "\"" + this.textBox1.Text + @"\CustomSongs\" + f + "\"";
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
    }
}
