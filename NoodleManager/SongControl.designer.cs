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
            this.songID = new NoodleManager.LabelNM();
            this.mapperName = new NoodleManager.LabelNM();
            this.difficulty4 = new NoodleManager.PictureBoxNM();
            this.difficulty3 = new NoodleManager.PictureBoxNM();
            this.difficulty2 = new NoodleManager.PictureBoxNM();
            this.difficulty1 = new NoodleManager.PictureBoxNM();
            this.songName = new NoodleManager.LabelNM();
            this.coverImage = new NoodleManager.PictureBoxNM();
            this.percentage = new NoodleManager.LabelNM();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coverImage)).BeginInit();
            this.SuspendLayout();
            // 
            // songID
            // 
            this.songID.AutoSize = true;
            this.songID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.songID.Location = new System.Drawing.Point(356, 97);
            this.songID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.songID.Name = "songID";
            this.songID.Size = new System.Drawing.Size(34, 26);
            this.songID.TabIndex = 10;
            this.songID.Text = "ID";
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
            // difficulty4
            // 
            this.difficulty4.BackColor = System.Drawing.SystemColors.Highlight;
            this.difficulty4.ErrorImage = null;
            this.difficulty4.InitialImage = null;
            this.difficulty4.Location = new System.Drawing.Point(297, 95);
            this.difficulty4.Name = "difficulty4";
            this.difficulty4.Size = new System.Drawing.Size(40, 30);
            this.difficulty4.TabIndex = 8;
            this.difficulty4.TabStop = false;
            // 
            // difficulty3
            // 
            this.difficulty3.BackColor = System.Drawing.SystemColors.Highlight;
            this.difficulty3.ErrorImage = null;
            this.difficulty3.InitialImage = null;
            this.difficulty3.Location = new System.Drawing.Point(251, 95);
            this.difficulty3.Name = "difficulty3";
            this.difficulty3.Size = new System.Drawing.Size(40, 30);
            this.difficulty3.TabIndex = 7;
            this.difficulty3.TabStop = false;
            // 
            // difficulty2
            // 
            this.difficulty2.BackColor = System.Drawing.SystemColors.Highlight;
            this.difficulty2.ErrorImage = null;
            this.difficulty2.InitialImage = null;
            this.difficulty2.Location = new System.Drawing.Point(205, 95);
            this.difficulty2.Name = "difficulty2";
            this.difficulty2.Size = new System.Drawing.Size(40, 30);
            this.difficulty2.TabIndex = 6;
            this.difficulty2.TabStop = false;
            // 
            // difficulty1
            // 
            this.difficulty1.BackColor = System.Drawing.SystemColors.Highlight;
            this.difficulty1.ErrorImage = null;
            this.difficulty1.InitialImage = null;
            this.difficulty1.Location = new System.Drawing.Point(158, 95);
            this.difficulty1.Name = "difficulty1";
            this.difficulty1.Size = new System.Drawing.Size(40, 30);
            this.difficulty1.TabIndex = 5;
            this.difficulty1.TabStop = false;
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
            this.coverImage.Location = new System.Drawing.Point(25, 25);
            this.coverImage.Name = "coverImage";
            this.coverImage.Size = new System.Drawing.Size(100, 100);
            this.coverImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coverImage.TabIndex = 1;
            this.coverImage.TabStop = false;
            // 
            // percentage
            // 
            this.percentage.AutoSize = true;
            this.percentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentage.Location = new System.Drawing.Point(526, 69);
            this.percentage.Name = "percentage";
            this.percentage.Size = new System.Drawing.Size(55, 25);
            this.percentage.TabIndex = 11;
            this.percentage.Text = "50%";
            this.percentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.percentage.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(583, 71);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 12;
            // 
            // SongControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.percentage);
            this.Controls.Add(this.songID);
            this.Controls.Add(this.mapperName);
            this.Controls.Add(this.difficulty4);
            this.Controls.Add(this.difficulty3);
            this.Controls.Add(this.difficulty2);
            this.Controls.Add(this.difficulty1);
            this.Controls.Add(this.songName);
            this.Controls.Add(this.coverImage);
            this.Name = "SongControl";
            this.Size = new System.Drawing.Size(767, 150);
            ((System.ComponentModel.ISupportInitialize)(this.difficulty4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coverImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public PictureBoxNM coverImage;
        public LabelNM songName;
        public PictureBoxNM difficulty1;
        public PictureBoxNM difficulty2;
        public PictureBoxNM difficulty3;
        public PictureBoxNM difficulty4;
        public LabelNM mapperName;
        public LabelNM songID;
        private LabelNM percentage;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
