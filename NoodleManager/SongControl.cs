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

        private Size pictureSize;
        private Point pictureLocation;
        private bool big = false;
        private int diff = 35;

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
        }

        private void MouseClick_callback(object sender, MouseEventArgs e)
        {
            if (GlobalVariables.settings.directory != null && downloadPath != null)
                using (var client = new WebClient())
                {
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.DownloadProgressCallback);
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(this.DownlaodCompletedCallback);
                    client.DownloadFileAsync(new Uri(this.downloadPath), GlobalVariables.settings.directory+ @"\Songs\" + originalFilename);
                    GlobalVariables.clients.Add(client);
                }
            //this.progressBar1.Visible = true;
            this.percentage.Visible = true;
            this.percentage.Text = "0%";
            //this.Enabled = false;
        }

        private void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            this.percentage.Text = e.ProgressPercentage.ToString() + "%";
            this.percentage.ForeColor = Color.FromArgb(255,255-2*e.ProgressPercentage, 0, 2*e.ProgressPercentage);
            //this.progressBar1.Value = e.ProgressPercentage;
        }

        private void DownlaodCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
           // progressBar1.Visible = false;
            this.percentage.Visible = false;
            GlobalVariables.clients.Remove((WebClient)sender);
        }

        private void MouseEnter_callback(object sender, EventArgs e)
        {
            if (!big)
            {
                big = true;
                pictureSize = this.coverImage.Size;
                pictureSize.Width = pictureSize.Height;
                pictureLocation = this.coverImage.Location;
                Size tempSize = pictureSize;
                Point tempLocation = pictureLocation;
                tempSize.Height += diff;
                tempSize.Width = tempSize.Height;
                tempLocation.X -= diff / 2;
                tempLocation.Y -= diff / 2;
                this.coverImage.Size = tempSize;
                this.coverImage.Location = tempLocation;
            }
        }

        private void MouseLeave_callback(object sender, EventArgs e)
        {
            if (big)
            {
                this.coverImage.Size = pictureSize;
                this.coverImage.Location = pictureLocation;
                big = false;
            }
        }
    }
}
