using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace NoodleManager
{
    public partial class SongControl : UserControl
    {
        public string downloadPath;
        public string originalFilename;
        public bool active = true;
        public string[] difficulties;

        private Size pictureSize;
        private Point pictureLocation;
        private bool big = false;
        private int diff = 35;
        private Color originalColor;

        public SongControl()
        {
            InitializeComponent();

            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.MouseClick += new MouseEventHandler(this.MouseClick_callback);
            this.MouseEnter += new EventHandler(MouseEnter_callback);
            this.MouseLeave += new EventHandler(MouseLeave_callback);

            foreach (Control c in this.Controls)
            {
                c.MouseClick += new MouseEventHandler(this.MouseClick_callback);
                c.MouseEnter += new EventHandler(MouseEnter_callback);
                c.MouseLeave += new EventHandler(MouseLeave_callback);
            }

            this.originalColor = this.BackColor;
        }

        public void Activate()
        {
            this.active = true;
            this.BackColor = this.originalColor;
            this.progressBar1.Value = 0;

            this.songName.ForeColor = System.Drawing.Color.White;
            this.mapperName.ForeColor = System.Drawing.Color.White;
            this.artist.ForeColor = System.Drawing.Color.White;
            this.duration.ForeColor = System.Drawing.Color.White;

            foreach (string difficulty in this.difficulties)
            {
                if (difficulty.Equals("Easy"))
                {
                    this.Easy.ForeColor = System.Drawing.Color.White;
                }
                else if (difficulty.Equals("Normal"))
                {
                    this.Normal.ForeColor = System.Drawing.Color.White;
                }
                else if (difficulty.Equals("Hard"))
                {
                    this.Hard.ForeColor = System.Drawing.Color.White;
                }
                else if (difficulty.Equals("Expert"))
                {
                    this.Expert.ForeColor = System.Drawing.Color.White;
                }
                else if (difficulty.Equals("Master"))
                {
                    this.Master.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        public void Deactivate()
        {
            this.active = false;
            this.BackColor = Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.songName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.mapperName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.artist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.duration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));

            foreach (string difficulty in this.difficulties)
            {
                if (difficulty.Equals("Easy"))
                {
                    this.Easy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
                }
                else if (difficulty.Equals("Normal"))
                {
                    this.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
                }
                else if (difficulty.Equals("Hard"))
                {
                    this.Hard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
                }
                else if (difficulty.Equals("Expert"))
                {
                    this.Expert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
                }
                else if (difficulty.Equals("Master"))
                {
                    this.Master.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
                }
            }

            if (this.big)
            {
                this.coverImage.Size = this.pictureSize;
                this.coverImage.Location = this.pictureLocation;
                this.big = false;
            }
        }

        private void MouseClick_callback(object sender, MouseEventArgs e)
        {
            string dpath = Properties.Settings.Default.path + @"\CustomSongs\" + originalFilename;

            if (e.Button == MouseButtons.Left)
            {
                if (this.active && Properties.Settings.Default.path != null && downloadPath != null)
                {
                    Console.WriteLine(dpath);
                    using (var client = new WebClient())
                    {
                        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.DownloadProgressCallback);
                        client.DownloadFileCompleted += new AsyncCompletedEventHandler(this.DownlaodCompletedCallback);
                        client.DownloadFileAsync(new Uri(this.downloadPath), dpath);
                        GlobalVariables.clients.Add(client, dpath);
                    }
                    this.progressBar1.Visible = true;
                    this.Deactivate();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (!GlobalVariables.clients.ContainsValue(dpath)) {
                    RightClickDialog rightClickDialog = new RightClickDialog();
                    Point tmp = this.PointToScreen(e.Location);
                    tmp.X -= (rightClickDialog.Size.Width / 2);
                    tmp.Y -= (rightClickDialog.Size.Height / 2);
                    rightClickDialog.Location = tmp;
                    rightClickDialog.Callback = this.RightClickDialogCallback;
                    rightClickDialog.Show();
                }
            }
        }

        public bool RightClickDialogCallback(int e)
        {
            string dpath = Properties.Settings.Default.path + @"\CustomSongs\" + originalFilename;

            if (e == 1)//reload
            {
                using (var client = new WebClient())
                {
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.DownloadProgressCallback);
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(this.DownlaodCompletedCallback);
                    client.DownloadFileAsync(new Uri(this.downloadPath), dpath);
                    GlobalVariables.clients.Add(client, dpath);
                }
                this.progressBar1.Visible = true;
                this.Deactivate();
            }
            else if (e==2)//delete
            {
                if (File.Exists(dpath))
                {
                    File.Delete(dpath);
                }
                this.Activate();
            }
            return true;
        }

        private void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }

        private void DownlaodCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            this.progressBar1.Visible = false;
            GlobalVariables.clients.Remove((WebClient)sender);
        }

        private void MouseEnter_callback(object sender, EventArgs e)
        {
            if (this.active && !this.big)
            {
                this.big = true;
                this.pictureSize = this.coverImage.Size;
                this.pictureSize.Width = this.pictureSize.Height;
                this.pictureLocation = this.coverImage.Location;
                Size tempSize = this.pictureSize;
                Point tempLocation = this.pictureLocation;
                tempSize.Height += this.diff;
                tempSize.Width = tempSize.Height;
                tempLocation.X -= this.diff / 2;
                tempLocation.Y -= this.diff / 2;
                this.coverImage.Size = tempSize;
                this.coverImage.Location = tempLocation;
            }
        }

        private void MouseLeave_callback(object sender, EventArgs e)
        {
            if (this.active && this.big)
            {
                this.coverImage.Size = this.pictureSize;
                this.coverImage.Location = this.pictureLocation;
                this.big = false;
            }
        }
    }
}
