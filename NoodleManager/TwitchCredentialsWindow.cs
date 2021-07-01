using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoodleManager
{
    public partial class TwitchCredentialsWindow : Form
    {
        private const int cGrip = 10;      // Grip size
        private const int cCaption = 70;   // Caption bar height;

        const string SETTINGS_NAME1 = "twith.auth.bin";
        const string SETTINGS_NAME2 = "twitchcredentials.bin";


        public TwitchCredentialsWindow()
        {
            InitializeComponent();

            this.labelNM1.Text = GlobalVariables.TagName;

            this.FormClosing += FormclosingCallback;

            this.pictureBoxNM1.SendToBack();

            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            TwitchCredentials cred=new TwitchCredentials();

            string path = Path.Combine(Properties.Settings.Default.path, SETTINGS_NAME2);
            if (File.Exists(path))
            {
                cred = JsonConvert.DeserializeObject<TwitchCredentials>(File.ReadAllText(path));
            }
            else
            {
                path = Path.Combine(Properties.Settings.Default.path, SETTINGS_NAME1);
                if (File.Exists(path))
                {
                    cred = JsonConvert.DeserializeObject<TwitchCredentials>(File.ReadAllText(path));
                }
            }

            if (cred != null)
            {
                this.textBox1.Text = cred.Channel;
                this.textBox2.Text = cred.Username;
                this.textBox3.Text = cred.OauthKey;
            }

        }

        private void Save()
        {
            TwitchCredentials cred = new TwitchCredentials();
            cred.Channel = this.textBox1.Text;
            cred.Username = this.textBox2.Text;
            cred.OauthKey = this.textBox3.Text;

            string path = Path.Combine(Properties.Settings.Default.path, SETTINGS_NAME2);
            if (File.Exists(path))
            {
                File.WriteAllText(path, cred.SerializeToJSON());
            }
            else
            {
                path = Path.Combine(Properties.Settings.Default.path, SETTINGS_NAME1);
                if (File.Exists(path))
                {
                    File.WriteAllText(path, cred.SerializeToJSON());
                }
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                this.Close();
            }
        }

        private void FullscreenButton_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;
                }
            }
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }


        private void pictureBox_Click(object sender, EventArgs e)
        {
            Process.Start("https://synthriderz.com");
        }

        private void FormclosingCallback(object sender, FormClosingEventArgs e)
        {
            Save();
        }

        protected override void WndProc(ref Message m)//using the windows defaut resize with a borderless window
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                bool right = false;
                bool left = false;
                bool top = false;
                bool bottom = false;

                if (pos.X >= this.ClientSize.Width - cGrip)
                {
                    right = true;
                }
                else if (pos.X < cGrip)
                {
                    left = true;
                }

                if (pos.Y >= this.ClientSize.Height - cGrip)
                {
                    bottom = true;
                }
                else if (pos.Y < cGrip)
                {
                    top = true;
                }

                if (right)
                {
                    if (bottom)
                    {
                        m.Result = (IntPtr)17;  // HTBOTTOMRIGHT
                        return;
                    }
                    else if (top)
                    {
                        m.Result = (IntPtr)14;  // HTTOPRIGHT
                        return;
                    }
                    else
                    {
                        m.Result = (IntPtr)11;  // HTRIGHT
                        return;
                    }
                }
                else if (left)
                {
                    if (bottom)
                    {
                        m.Result = (IntPtr)16;  // HTBOTTOMLEFT
                        return;
                    }
                    else if (top)
                    {
                        m.Result = (IntPtr)13;  // HTTOPLEFT
                        return;
                    }
                    else
                    {
                        m.Result = (IntPtr)10;  // HTLEFT
                        return;
                    }
                }
                else if (bottom)
                {
                    m.Result = (IntPtr)15;  // HTBOTTOM
                    return;
                }
                else if (top)
                {
                    m.Result = (IntPtr)12;  // HTTOP
                    return;
                }
                else if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Save();
        }
    }

    public class TwitchCredentials
    {
        public string Channel = "";
        public string Username = "";
        public string OauthKey = "";

        public string SerializeToJSON()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
