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
        public bool Active = true;

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
            this.Active = true;
            this.BackColor = this.originalColor;
            this.progressBar1.Value = 0;
        }

        public void Deactivate()
        {
            this.Active = false;
            this.BackColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));

            if (this.big)
            {
                this.coverImage.Size = this.pictureSize;
                this.coverImage.Location = this.pictureLocation;
                this.big = false;
            }
        }

        private void MouseClick_callback(object sender, MouseEventArgs e)
        {
            string dpath = GlobalVariables.settings.directory + @"\Songs\" + originalFilename;

            if (e.Button == MouseButtons.Left)
            {
                if (this.Active && GlobalVariables.settings.directory != null && downloadPath != null)
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
            string dpath = GlobalVariables.settings.directory + @"\Songs\" + originalFilename;

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
            if (this.Active && !this.big)
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
            if (this.Active && this.big)
            {
                this.coverImage.Size = this.pictureSize;
                this.coverImage.Location = this.pictureLocation;
                this.big = false;
            }
        }
    }
}
