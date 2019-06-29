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






        public const string baseurl = "https://synthriderz.com";
        public const string beatmapsurl = "/api/beatmaps";
        public const string path = @"C:\Users\BFM2FE\AppData\Roaming\download";

        public Form1()
        {
            InitializeComponent();
            this.searchMode.DataSource = new string[] { "All", "Title", "Mapper", "Artist" };

            GlobalVariables.ReadSettings();

            this.FormClosing += FormclosingCallback;

            LoadSongs(baseurl + beatmapsurl);
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
    }
}
