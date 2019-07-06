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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coverImage)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(583, 71);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 12;
            this.progressBar1.Visible = false;
            // 
            // pictureBoxNM2
            // 
            this.pictureBoxNM2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBoxNM2.ErrorImage = null;
            this.pictureBoxNM2.InitialImage = null;
            this.pictureBoxNM2.Location = new System.Drawing.Point(45, 158);
            this.pictureBoxNM2.Name = "pictureBoxNM2";
            this.pictureBoxNM2.Size = new System.Drawing.Size(700, 2);
            this.pictureBoxNM2.TabIndex = 14;
            this.pictureBoxNM2.TabStop = false;
            // 
            // mapperName
            // 
            this.mapperName.AutoSize = true;
            this.mapperName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapperName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mapperName.Location = new System.Drawing.Point(154, 59);
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
            this.songName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.songName.Location = new System.Drawing.Point(152, 25);
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
            // SongControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(31)))));
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
    }
}
