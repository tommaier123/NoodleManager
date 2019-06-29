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
        private const int cCaption = 48;   // Caption bar height;


        public const string baseurl = "https://synthriderz.com";
        public const string beatmapsurl = "/api/beatmaps";
        public const string path = @"C:\Users\BFM2FE\AppData\Roaming\download";

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.searchMode.DataSource = new string[] { "All", "Title", "Mapper", "Artist" };

            GlobalVariables.ReadSettings();

            this.FormClosing += FormclosingCallback;

            LoadSongs(baseurl + beatmapsurl);
        }




        protected override void OnPaint(PaintEventArgs e)
        {
            // Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            // ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            //rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            //e.Graphics.FillRectangle(Brushes.DarkBlue, rc);
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
                else if (pos.Y <  cGrip)
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
                } else if (left)
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
                else if(bottom)
                {
                    m.Result = (IntPtr)15;  // HTBOTTOM
                    return;
                }
                else if (top)
                {
                    m.Result = (IntPtr)12;  // HTTOP
                    return;
                }
                else if(pos.Y < cCaption)
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
                song.songID.Text = item.id.ToString();

                foreach (string difficulty in item.difficulties)
                {
                    if (difficulty.Equals("Easy"))
                    {
                        song.difficulty1.BackColor = SystemColors.HotTrack;
                    }
                    else if (difficulty.Equals("Normal"))
                    {
                        song.difficulty2.BackColor = SystemColors.HotTrack;
                    }
                    else if (difficulty.Equals("Hard"))
                    {
                        song.difficulty3.BackColor = SystemColors.HotTrack;
                    }
                    else if (difficulty.Equals("Expert"))
                    {
                        song.difficulty4.BackColor = SystemColors.HotTrack;
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
            int i = 0;
            foreach (WebClient c in GlobalVariables.clients)
            {
                if (c != null)
                {
                    i++;
                }
            }
            if (i > 0)
            {
                ErrorDialog errorDialog = new ErrorDialog(i.ToString() + " Songs are still downloading");
                DialogResult result = errorDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    foreach (WebClient c in GlobalVariables.clients)
                    {
                        if (c != null)
                        {
                            c.CancelAsync();
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
        }

        private void Mods_Click(object sender, EventArgs e)
        {
            songMenu.Enabled = false;
            songMenu.Visible = false;

            modMenu.Enabled = true;
            modMenu.Visible = true;

            settingsMenu.Enabled = false;
            settingsMenu.Visible = false;
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
