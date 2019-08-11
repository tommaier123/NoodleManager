using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoodleManager
{
    public partial class Form1 : Form
    {
        private const int cGrip = 10;      // Grip size
        private const int cCaption = 70;   // Caption bar height;

        public const string baseurl = "https://synthriderz.com";
        public const string beatmapsurl = "/api/beatmaps";

        public Form1()
        {
            InitializeComponent();
            if (!Directory.Exists(Properties.Settings.Default.path + @"\CustomSongs\"))
            {
                ShowSettings();
            }

            this.pictureBoxNM1.SendToBack();

            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.searchMode.DataSource = new string[] { "All", "Title", "Mapper", "Artist" };

            this.FormClosing += FormclosingCallback;

            this.searchText.KeyDown += new KeyEventHandler(this.SearchKeyDownCallback);

            this.songMenu.Focus();

            DownloadString(baseurl + beatmapsurl);
        }

        private void DownloadString(string path)
        {
            this.songMenu.tableLayoutPanel.Controls.Clear();
            this.songMenu.tableLayoutPanel.Visible = false;
            this.songMenu.tableLayoutPanel.Location = new Point(0, 0);
            this.songMenu.scrollBar.grabber.Location = new Point(0, 0);
            this.Cursor = Cursors.WaitCursor;
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadStringCompleted += DownloadCompleteCallback;
                    client.DownloadStringAsync(new Uri(path));
                }
            }
            catch
            {

            }
        }

        private void DownloadCompleteCallback(object sender, DownloadStringCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null && e.Result != null && e.Result != "")
            {
                string content = e.Result;
                SongInfo[] items = JsonConvert.DeserializeObject<SongInfo[]>(content);

                foreach (SongInfo item in items)
                {
                    SongControl song = new SongControl();
                    song.downloadPath = baseurl + item.download_url;
                    song.previewPath = baseurl + item.preview_url;
                    song.originalFilename = item.filename_original;
                    song.coverImage.ImageLocation = baseurl + item.cover_url + "?size=150";
                    song.songName.Text = item.title + " - " + item.artist;
                    song.mapperName.Text = item.mapper;
                    song.difficulties = item.difficulties;
                    song.artist.Text = item.artist;
                    song.duration.Text = item.duration;

                    foreach (string difficulty in item.difficulties)
                    {
                        if (difficulty.Equals("Easy"))
                        {
                            song.Easy.ForeColor = System.Drawing.Color.White;
                        }
                        else if (difficulty.Equals("Normal"))
                        {
                            song.Normal.ForeColor = System.Drawing.Color.White;
                        }
                        else if (difficulty.Equals("Hard"))
                        {
                            song.Hard.ForeColor = System.Drawing.Color.White;
                        }
                        else if (difficulty.Equals("Expert"))
                        {
                            song.Expert.ForeColor = System.Drawing.Color.White;
                        }
                        else if (difficulty.Equals("Master"))
                        {
                            song.Master.ForeColor = System.Drawing.Color.White;
                        }
                    }

                    if (File.Exists(Properties.Settings.Default.path + @"\CustomSongs\" + item.filename_original))
                    {
                        song.Deactivate();
                    }
                    this.songMenu.tableLayoutPanel.Controls.Add(song);
                    this.songMenu.tableLayoutPanel.Visible = true;
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void FormclosingCallback(object sender, FormClosingEventArgs e)
        {
            if (GlobalVariables.clients.Count > 0)
            {
                ErrorDialog errorDialog = new ErrorDialog(GlobalVariables.clients.Count.ToString() + " Songs are still downloading");
                Point tmp = this.Location;
                tmp.X += (this.Size.Width / 2) - (errorDialog.Size.Width / 2);
                tmp.Y += (this.Size.Height / 2) - (errorDialog.Size.Height / 2);
                errorDialog.Location = tmp;
                DialogResult result = errorDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    foreach (KeyValuePair<WebClient, string> c in GlobalVariables.clients)
                    {
                        if (c.Key != null)
                        {
                            c.Key.CancelAsync();
                            c.Key.Dispose();
                        }
                    }
                }
                else
                {
                    e.Cancel = true;
                    if (GlobalVariables.AudioReader != null) { GlobalVariables.AudioReader.Dispose(); }
                    if (GlobalVariables.MusicPlayer != null) { GlobalVariables.MusicPlayer.Dispose(); }
                }
            }
        }

        private void Songs_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                this.searchText.Text = "";
                if (!Directory.Exists(settingsMenu.textBox1.Text + @"\CustomSongs\"))
                {
                    ShowSettings();
                }
                else
                {
                    Properties.Settings.Default.path = settingsMenu.textBox1.Text;
                    Properties.Settings.Default.Save();

                    songMenu.Enabled = true;
                    songMenu.Visible = true;

                    modMenu.Enabled = false;
                    modMenu.Visible = false;

                    settingsMenu.Enabled = false;
                    settingsMenu.Visible = false;

                    this.songsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(249)))), ((int)(((byte)(28)))), ((int)(((byte)(133)))));
                    this.modsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(170)))), ((int)(((byte)(73)))), ((int)(((byte)(224)))));
                    this.SettingsButton.Image = global::NoodleManager.Properties.Resources.settings_u;

                    this.songMenu.Focus();
                }
            }
        }

        private void Mods_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                this.searchText.Text = "";
                if (!Directory.Exists(settingsMenu.textBox1.Text + @"\CustomSongs\"))
                {
                    ShowSettings();
                }
                else
                {
                    Properties.Settings.Default.path = settingsMenu.textBox1.Text;
                    Properties.Settings.Default.Save();

                    songMenu.Enabled = false;
                    songMenu.Visible = false;

                    modMenu.Enabled = true;
                    modMenu.Visible = true;

                    settingsMenu.Enabled = false;
                    settingsMenu.Visible = false;

                    this.songsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(170)))), ((int)(((byte)(73)))), ((int)(((byte)(224)))));
                    this.modsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(249)))), ((int)(((byte)(28)))), ((int)(((byte)(133)))));
                    this.SettingsButton.Image = global::NoodleManager.Properties.Resources.settings_u;

                    this.modMenu.Focus();
                }
            }
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                ShowSettings();
            }
        }

        private void ShowSettings()
        {
            this.searchText.Text = "";
            songMenu.Enabled = false;
            songMenu.Visible = false;

            modMenu.Enabled = false;
            modMenu.Visible = false;

            settingsMenu.Enabled = true;
            settingsMenu.Visible = true;

            settingsMenu.textBox1.Text = Properties.Settings.Default.path;

            this.songsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(170)))), ((int)(((byte)(73)))), ((int)(((byte)(224)))));
            this.modsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(170)))), ((int)(((byte)(73)))), ((int)(((byte)(224)))));
            this.SettingsButton.Image = global::NoodleManager.Properties.Resources.settings_s;

            this.settingsMenu.Focus();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                Search();
            }
        }

        private void SearchKeyDownCallback(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void Search()
        {
            string mode = "q";
            if (this.searchMode.SelectedIndex == 1)
            {
                mode = "title";
            }
            else if (this.searchMode.SelectedIndex == 2)
            {
                mode = "mapper";
            }
            else if (this.searchMode.SelectedIndex == 3)
            {
                mode = "artist";
            }

            DownloadString(baseurl + beatmapsurl + "?" + mode + "=" + this.searchText.Text);
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

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Return)
            {
                this.Search();
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
    }
}
