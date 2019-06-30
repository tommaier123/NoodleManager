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
        //position, size of error
        //search
        //custom disabled with redownload, delete option
        //dynamic design


        private const int cGrip = 10;      // Grip size
        private const int cCaption = 70;   // Caption bar height;


        public const string baseurl = "https://synthriderz.com";
        public const string beatmapsurl = "/api/beatmaps";
        public const string path = @"C:\Users\BFM2FE\AppData\Roaming\download";

        public Form1()
        {
            InitializeComponent();
            this.pictureBoxNM1.SendToBack();

            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.searchMode.DataSource = new string[] { "All", "Title", "Mapper", "Artist" };

            GlobalVariables.ReadSettings();

            this.FormClosing += FormclosingCallback;

            this.ResizeEnd += ResizeEndCallback;

            LoadSongs(baseurl + beatmapsurl);

            this.songMenu.Focus();
        }

        private void ResizeEndCallback(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, (int)Math.Round(((this.Size.Height - 90f) / 83)) * 83 + 90);
        }

        protected override void WndProc(ref Message m)
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



        private void LoadSongs(string path)
        {
            this.songMenu.tableLayoutPanel.Controls.Clear();

            string content = new WebClient().DownloadString(path);
            SongInfo[] items = JsonConvert.DeserializeObject<SongInfo[]>(content);

            foreach (SongInfo item in items)
            {
                WebClient client = new WebClient();

                SongControl song = new SongControl();
                song.downloadPath = baseurl + item.download_url;
                song.originalFilename = item.filename_original;
                song.coverImage.ImageLocation = baseurl + item.cover_url;
                song.songName.Text = item.title + " - " + item.artist;
                song.mapperName.Text = item.mapper;

                foreach (string difficulty in item.difficulties)
                {
                    if (difficulty.Equals("Easy"))
                    {

                    }
                    else if (difficulty.Equals("Normal"))
                    {

                    }
                    else if (difficulty.Equals("Hard"))
                    {

                    }
                    else if (difficulty.Equals("Expert"))
                    {

                    }
                    else if (difficulty.Equals("Master"))
                    {

                    }
                }

                if (File.Exists(GlobalVariables.settings.directory + @"\Songs\" + item.filename_original))
                {
                    song.Enabled = false;
                }

                this.songMenu.tableLayoutPanel.Controls.Add(song);
            }
        }

        private void FormclosingCallback(object sender, FormClosingEventArgs e)
        {
            if (GlobalVariables.clients.Count > 0)
            {
                ErrorDialog errorDialog = new ErrorDialog(GlobalVariables.clients.Count.ToString() + " Songs are still downloading");
                DialogResult result = errorDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    foreach (KeyValuePair<WebClient, string> c in GlobalVariables.clients)
                    {
                        if (c.Key != null)
                        {
                            c.Key.CancelAsync();
                        }

                        if (File.Exists(c.Value))
                        {
                            File.Delete(c.Value);
                        }
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }


        private void Songs_Click(object sender, EventArgs e)
        {
            songMenu.Enabled = true;
            songMenu.Visible = true;

            modMenu.Enabled = false;
            modMenu.Visible = false;

            settingsMenu.Enabled = false;
            settingsMenu.Visible = false;

            this.songMenu.Focus();
        }

        private void Mods_Click(object sender, EventArgs e)
        {
            songMenu.Enabled = false;
            songMenu.Visible = false;

            modMenu.Enabled = true;
            modMenu.Visible = true;

            settingsMenu.Enabled = false;
            settingsMenu.Visible = false;

            this.modMenu.Focus();
        }

        private void Settings_Click(object sender, EventArgs e)
        {

            GlobalVariables.ReadSettings();
            songMenu.Enabled = false;
            songMenu.Visible = false;

            modMenu.Enabled = false;
            modMenu.Visible = false;

            settingsMenu.Enabled = true;
            settingsMenu.Visible = true;

            this.settingsMenu.Focus();
        }

        private void searchButton_Click(object sender, EventArgs e)
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

            LoadSongs(baseurl + beatmapsurl + "?" + mode + "=" + this.searchText.Text);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
