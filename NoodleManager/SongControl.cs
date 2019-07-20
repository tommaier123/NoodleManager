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
using NAudio.Wave;

namespace NoodleManager
{
    public partial class SongControl : UserControl
    {
        public string downloadPath;
        public string previewPath;
        public string originalFilename;
        public bool active = true;
        public string[] difficulties;

        private bool mouseOver = false;
        private Size pictureSize;
        private Point pictureLocation;
        private bool big = false;
        private int diff = 35;
        private Color originalColor;
        private bool playing = false;

        public SongControl()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.MouseEnter += new EventHandler(MouseEnter_callback);
            this.MouseLeave += new EventHandler(MouseLeave_callback);

            foreach (Control c in this.Controls)
            {
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
            this.DownloadButton.Image = global::NoodleManager.Properties.Resources.download_u;
            this.DownloadLabel.Text = "DOWNLOAD";
            this.DownloadLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(234)))), ((int)(((byte)(59)))));

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
            this.DownloadButton.Image = global::NoodleManager.Properties.Resources.delete_u;
            this.DownloadLabel.Text = "DELETE";
            this.DownloadLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(59)))), ((int)(((byte)(103)))));

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

        private void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }

        private void DownlaodCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            this.progressBar1.Visible = false;
            GlobalVariables.clients.Remove((WebClient)sender);

            if (e.Cancelled || e.Error != null)
            {
                this.Delete();
            }
        }

        private void MouseEnter_callback(object sender, EventArgs e)
        {
            mouseOver = true;
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
            this.mouseOver = false;
            Task.Delay(1).ContinueWith(t => MouseLeave_F());
        }

        private void MouseLeave_F()
        {
            MethodInvoker methodInvokerDelegate = delegate ()
            {
                if (!mouseOver && active && big)
                {
                    coverImage.Size = pictureSize;
                    coverImage.Location = pictureLocation;
                    big = false;
                }
            };

            if (this.InvokeRequired)
            {
                this.Invoke(methodInvokerDelegate);
            }
            else
            {
                methodInvokerDelegate();
            }
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                if (GlobalVariables.AudioReader != null) { GlobalVariables.AudioReader.Dispose(); }
                if (GlobalVariables.MusicPlayer != null) { GlobalVariables.MusicPlayer.Dispose(); }

                if (!playing)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        GlobalVariables.AudioReader = new MediaFoundationReader(previewPath);
                        GlobalVariables.MusicPlayer = new WaveOut();
                        GlobalVariables.MusicPlayer.PlaybackStopped += PlaybackStoppedCallback;
                        GlobalVariables.MusicPlayer.Init(GlobalVariables.AudioReader);
                        GlobalVariables.MusicPlayer.Play();
                        playing = true;
                        this.PlayLabel.Text = "STOP";
                        this.PlayLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(34)))), ((int)(((byte)(203)))));
                        this.PlayButton.Image = global::NoodleManager.Properties.Resources.stop_u;
                        Cursor.Current = Cursors.Default;
                    }
                    catch
                    {

                    }
                }
                else
                {
                    StopPlayback();
                }
            }
        }

        public void StopPlayback()
        {
            this.PlayLabel.Text = "PLAY";
            this.PlayLabel.ForeColor = Color.White;
            this.PlayButton.Image = global::NoodleManager.Properties.Resources.play_u;
            playing = false;
        }

        private void PlaybackStoppedCallback(object sender, StoppedEventArgs e)
        {
            StopPlayback();
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                string dpath = Properties.Settings.Default.path + @"\CustomSongs\" + originalFilename;

                if (this.active && Properties.Settings.Default.path != null && downloadPath != null)
                {
                    try
                    {
                        Console.WriteLine(dpath);
                        using (var client = new WebClient())
                        {
                            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.DownloadProgressCallback);
                            client.DownloadFileCompleted += new AsyncCompletedEventHandler(this.DownlaodCompletedCallback);
                            client.DownloadFileAsync(new Uri(this.downloadPath), dpath);
                            GlobalVariables.clients.Add(client, dpath);
                        }
                        this.progressBar1.Value = 1;
                        this.progressBar1.Visible = true;
                        this.Deactivate();
                    }
                    catch
                    {

                    }
                }
                else
                {
                    Delete();
                }
            }
        }

        private void Delete()
        {
            string dpath = Properties.Settings.Default.path + @"\CustomSongs\" + originalFilename;

            if (GlobalVariables.clients.ContainsValue(dpath))
            {
                foreach (KeyValuePair<WebClient, string> c in GlobalVariables.clients)
                {
                    if (c.Value.Equals(dpath))
                    {
                        if (c.Key != null)
                        {
                            c.Key.CancelAsync();
                            c.Key.Dispose();
                        }
                    }
                }
            }

            if (File.Exists(dpath))
            {
                File.Delete(dpath);
            }
            this.Activate();
        }
    }
}
