namespace NoodleManager
{
    partial class SongControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pictureBoxNM2 = new NoodleManager.PictureBoxNM();
            this.mapperName = new NoodleManager.LabelNM();
            this.songName = new NoodleManager.LabelNM();
            this.coverImage = new NoodleManager.PictureBoxNM();
            this.artist = new NoodleManager.LabelNM();
            this.duration = new NoodleManager.LabelNM();
            this.Easy = new NoodleManager.LabelNM();
            this.Normal = new NoodleManager.LabelNM();
            this.Hard = new NoodleManager.LabelNM();
            this.Expert = new NoodleManager.LabelNM();
            this.Master = new NoodleManager.LabelNM();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coverImage)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(645, 115);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 12;
            this.progressBar1.Visible = false;
            // 
            // pictureBoxNM2
            // 
            this.pictureBoxNM2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pictureBoxNM2.ErrorImage = null;
            this.pictureBoxNM2.InitialImage = null;
            this.pictureBoxNM2.Location = new System.Drawing.Point(20, 158);
            this.pictureBoxNM2.Name = "pictureBoxNM2";
            this.pictureBoxNM2.Size = new System.Drawing.Size(725, 2);
            this.pictureBoxNM2.TabIndex = 14;
            this.pictureBoxNM2.TabStop = false;
            // 
            // mapperName
            // 
            this.mapperName.AutoSize = true;
            this.mapperName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapperName.ForeColor = System.Drawing.Color.White;
            this.mapperName.Location = new System.Drawing.Point(174, 71);
            this.mapperName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mapperName.Name = "mapperName";
            this.mapperName.Size = new System.Drawing.Size(75, 24);
            this.mapperName.TabIndex = 9;
            this.mapperName.Text = "Mapper";
            // 
            // songName
            // 
            this.songName.AutoSize = true;
            this.songName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songName.ForeColor = System.Drawing.Color.White;
            this.songName.Location = new System.Drawing.Point(172, 10);
            this.songName.Name = "songName";
            this.songName.Size = new System.Drawing.Size(93, 33);
            this.songName.TabIndex = 4;
            this.songName.Text = "Name";
            // 
            // coverImage
            // 
            this.coverImage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.coverImage.ErrorImage = null;
            this.coverImage.InitialImage = null;
            this.coverImage.Location = new System.Drawing.Point(45, 30);
            this.coverImage.Name = "coverImage";
            this.coverImage.Size = new System.Drawing.Size(100, 100);
            this.coverImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coverImage.TabIndex = 1;
            this.coverImage.TabStop = false;
            // 
            // artist
            // 
            this.artist.AutoSize = true;
            this.artist.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artist.ForeColor = System.Drawing.Color.White;
            this.artist.Location = new System.Drawing.Point(174, 43);
            this.artist.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.artist.Name = "artist";
            this.artist.Size = new System.Drawing.Size(50, 24);
            this.artist.TabIndex = 15;
            this.artist.Text = "Artist";
            // 
            // duration
            // 
            this.duration.AutoSize = true;
            this.duration.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duration.ForeColor = System.Drawing.Color.White;
            this.duration.Location = new System.Drawing.Point(172, 105);
            this.duration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.duration.Name = "duration";
            this.duration.Size = new System.Drawing.Size(92, 33);
            this.duration.TabIndex = 16;
            this.duration.Text = "10:30";
            // 
            // Easy
            // 
            this.Easy.AutoSize = true;
            this.Easy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Easy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Easy.Location = new System.Drawing.Point(282, 115);
            this.Easy.Name = "Easy";
            this.Easy.Size = new System.Drawing.Size(48, 16);
            this.Easy.TabIndex = 17;
            this.Easy.Text = "EASY";
            // 
            // Normal
            // 
            this.Normal.AutoSize = true;
            this.Normal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Normal.Location = new System.Drawing.Point(336, 115);
            this.Normal.Name = "Normal";
            this.Normal.Size = new System.Drawing.Size(71, 16);
            this.Normal.TabIndex = 18;
            this.Normal.Text = "NORMAL";
            // 
            // Hard
            // 
            this.Hard.AutoSize = true;
            this.Hard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Hard.Location = new System.Drawing.Point(413, 115);
            this.Hard.Name = "Hard";
            this.Hard.Size = new System.Drawing.Size(51, 16);
            this.Hard.TabIndex = 19;
            this.Hard.Text = "HARD";
            // 
            // Expert
            // 
            this.Expert.AutoSize = true;
            this.Expert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Expert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Expert.Location = new System.Drawing.Point(470, 115);
            this.Expert.Name = "Expert";
            this.Expert.Size = new System.Drawing.Size(68, 16);
            this.Expert.TabIndex = 20;
            this.Expert.Text = "EXPERT";
            // 
            // Master
            // 
            this.Master.AutoSize = true;
            this.Master.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Master.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Master.Location = new System.Drawing.Point(544, 115);
            this.Master.Name = "Master";
            this.Master.Size = new System.Drawing.Size(71, 16);
            this.Master.TabIndex = 21;
            this.Master.Text = "MASTER";
            // 
            // SongControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(31)))));
            this.Controls.Add(this.Master);
            this.Controls.Add(this.Expert);
            this.Controls.Add(this.Hard);
            this.Controls.Add(this.Normal);
            this.Controls.Add(this.Easy);
            this.Controls.Add(this.duration);
            this.Controls.Add(this.artist);
            this.Controls.Add(this.pictureBoxNM2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.mapperName);
            this.Controls.Add(this.songName);
            this.Controls.Add(this.coverImage);
            this.Name = "SongControl";
            this.Size = new System.Drawing.Size(780, 160);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coverImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public PictureBoxNM coverImage;
        public LabelNM songName;
        public LabelNM mapperName;
        private System.Windows.Forms.ProgressBar progressBar1;
        private PictureBoxNM pictureBoxNM2;
        public LabelNM artist;
        public LabelNM duration;
        public LabelNM Easy;
        public LabelNM Normal;
        public LabelNM Hard;
        public LabelNM Expert;
        public LabelNM Master;
    }
}
