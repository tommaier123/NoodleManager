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
using System.Threading;

namespace NoodleManager
{
    public partial class SongControl : UserControl
    {
        public string downloadPath;
        public string previewPath;
        public string originalFilename;
        public bool active = true;
        public string[] difficulties;
        public int id;

        private WebClient client;
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
            GlobalVariables.downloadingSongs.Remove(this);
            GlobalVariables.Available--;

            if (e.Cancelled || e.Error != null)
            {
                client.Disposed += new EventHandler(DisposeCallback);
                this.client.Dispose();
            }
            client = null;
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
                if (!playing)
                {
                    GlobalVariables.PlayNew(this);
                }
                else
                {
                    StopPlayback();
                }
            }
        }


        public void StartPlayback()
        {
            var playThread = new Thread(() => Play());
            playThread.IsBackground = true;
            playThread.Start();
            playing = true;
            this.PlayLabel.Text = "STOP";
            this.PlayButton.Image = global::NoodleManager.Properties.Resources.stop_u;
        }

        public void Play()
        {
            try
            {
                using (Stream ms = new MemoryStream())
                {
                    using (Stream stream = WebRequest.Create(previewPath)
                        .GetResponse().GetResponseStream())
                    {
                        byte[] buffer = new byte[32768];
                        int read;
                        while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, read);
                        }
                    }

                    ms.Position = 0;
                    using (WaveStream blockAlignedStream =
                        new BlockAlignReductionStream(
                            WaveFormatConversionStream.CreatePcmStream(
                                new Mp3FileReader(ms))))
                    {
                        using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                        {
                            waveOut.Init(blockAlignedStream);
                            waveOut.PlaybackStopped += (sender, e) =>
                            {
                                waveOut.Stop();
                                playing = false;
                            };

                            waveOut.Play();
                            while (playing && waveOut.PlaybackState == PlaybackState.Playing)
                            {
                                System.Threading.Thread.Sleep(100);
                            }
                            if (!playing && waveOut.PlaybackState != PlaybackState.Playing)
                            {
                                GlobalVariables.StopPlayback();
                            }
                        }
                    }
                }
            }
            catch { StopPlayback(); }
        }

        public void StopPlayback()
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.PlayLabel.Text = "PLAY";
                this.PlayLabel.ForeColor = Color.White;
                this.PlayButton.Image = global::NoodleManager.Properties.Resources.play_u;
                playing = false;
            });
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                if (Properties.Settings.Default.path != null)
                {
                    if (this.active)
                    {
                        if (downloadPath != null)
                        {
                            Download();
                        }
                    }
                    else
                    {
                        Delete();
                    }
                }
            }
        }

        public void Download()
        {
            try
            {
                string dpath = Properties.Settings.Default.path + @"\CustomSongs\" + originalFilename;
                Console.WriteLine(dpath);
                this.client = new WebClient();

                this.client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.DownloadProgressCallback);
                this.client.DownloadFileCompleted += new AsyncCompletedEventHandler(this.DownlaodCompletedCallback);
                this.client.DownloadFileAsync(new Uri(this.downloadPath), dpath);
                GlobalVariables.downloadingSongs.Add(this);

                this.progressBar1.Value = 1;
                this.progressBar1.Visible = true;
                this.Deactivate();
            }
            catch
            {

            }
        }

        public void Delete()
        {
            GlobalVariables.Available++;
            if (client != null)
            {
                this.client.CancelAsync();
            }
            else
            {
                RemoveFile();
            }
        }

        private void DisposeCallback(object sender, EventArgs e)
        {
            RemoveFile();
        }

        private void RemoveFile()
        {
            string dpath = Properties.Settings.Default.path + @"\CustomSongs\" + originalFilename;
            GlobalVariables.downloadingSongs.Remove(this);
            if (File.Exists(dpath))
            {
                File.Delete(dpath);
            }
            this.Activate();

        }
    }
}
