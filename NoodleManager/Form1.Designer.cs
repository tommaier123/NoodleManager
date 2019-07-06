namespace NoodleManager
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.songsButton = new System.Windows.Forms.Label();
            this.modsButton = new System.Windows.Forms.Label();
            this.settingsButton = new System.Windows.Forms.Label();
            this.searchText = new System.Windows.Forms.TextBox();
            this.searchMode = new System.Windows.Forms.ComboBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.PictureBox();
            this.pictureBoxNM3 = new NoodleManager.PictureBoxNM();
            this.pictureBoxNM2 = new NoodleManager.PictureBoxNM();
            this.pictureBoxNM1 = new NoodleManager.PictureBoxNM();
            this.songMenu = new NoodleManager.TableMenu();
            this.modMenu = new NoodleManager.TableMenu();
            this.settingsMenu = new NoodleManager.SettingsMenu();
            ((System.ComponentModel.ISupportInitialize)(this.searchButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNM3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNM1)).BeginInit();
            this.SuspendLayout();
            // 
            // songsButton
            // 
            this.songsButton.AutoSize = true;
            this.songsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songsButton.Location = new System.Drawing.Point(137, 23);
            this.songsButton.Name = "songsButton";
            this.songsButton.Size = new System.Drawing.Size(72, 20);
            this.songsButton.TabIndex = 1;
            this.songsButton.Text = "SONGS";
            this.songsButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.songsButton.Click += new System.EventHandler(this.Songs_Click);
            // 
            // modsButton
            // 
            this.modsButton.AutoSize = true;
            this.modsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modsButton.Location = new System.Drawing.Point(232, 23);
            this.modsButton.Name = "modsButton";
            this.modsButton.Size = new System.Drawing.Size(61, 20);
            this.modsButton.TabIndex = 2;
            this.modsButton.Text = "MODS";
            this.modsButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.modsButton.Click += new System.EventHandler(this.Mods_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsButton.Location = new System.Drawing.Point(310, 23);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(26, 28);
            this.settingsButton.TabIndex = 0;
            this.settingsButton.Text = "S";
            this.settingsButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.settingsButton.Click += new System.EventHandler(this.Settings_Click);
            // 
            // searchText
            // 
            this.searchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchText.BackColor = System.Drawing.Color.Black;
            this.searchText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchText.ForeColor = System.Drawing.Color.Gray;
            this.searchText.Location = new System.Drawing.Point(392, 23);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(130, 15);
            this.searchText.TabIndex = 3;
            this.searchText.WordWrap = false;
            // 
            // searchMode
            // 
            this.searchMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchMode.ForeColor = System.Drawing.Color.Gray;
            this.searchMode.FormattingEnabled = true;
            this.searchMode.Location = new System.Drawing.Point(566, 23);
            this.searchMode.Name = "searchMode";
            this.searchMode.Size = new System.Drawing.Size(73, 24);
            this.searchMode.TabIndex = 4;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(774, 25);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(22, 22);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "C";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.ErrorImage = null;
            this.searchButton.Image = ((System.Drawing.Image)(resources.GetObject("searchButton.Image")));
            this.searchButton.InitialImage = null;
            this.searchButton.Location = new System.Drawing.Point(528, 23);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(15, 15);
            this.searchButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.searchButton.TabIndex = 9;
            this.searchButton.TabStop = false;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // pictureBoxNM3
            // 
            this.pictureBoxNM3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxNM3.ErrorImage = null;
            this.pictureBoxNM3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNM3.Image")));
            this.pictureBoxNM3.InitialImage = null;
            this.pictureBoxNM3.Location = new System.Drawing.Point(392, 42);
            this.pictureBoxNM3.Name = "pictureBoxNM3";
            this.pictureBoxNM3.Size = new System.Drawing.Size(151, 2);
            this.pictureBoxNM3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxNM3.TabIndex = 10;
            this.pictureBoxNM3.TabStop = false;
            // 
            // pictureBoxNM2
            // 
            this.pictureBoxNM2.ErrorImage = null;
            this.pictureBoxNM2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNM2.Image")));
            this.pictureBoxNM2.InitialImage = null;
            this.pictureBoxNM2.Location = new System.Drawing.Point(8, 10);
            this.pictureBoxNM2.Name = "pictureBoxNM2";
            this.pictureBoxNM2.Size = new System.Drawing.Size(105, 45);
            this.pictureBoxNM2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxNM2.TabIndex = 8;
            this.pictureBoxNM2.TabStop = false;
            // 
            // pictureBoxNM1
            // 
            this.pictureBoxNM1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxNM1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(31)))));
            this.pictureBoxNM1.ErrorImage = null;
            this.pictureBoxNM1.InitialImage = null;
            this.pictureBoxNM1.Location = new System.Drawing.Point(0, 70);
            this.pictureBoxNM1.Name = "pictureBoxNM1";
            this.pictureBoxNM1.Size = new System.Drawing.Size(820, 518);
            this.pictureBoxNM1.TabIndex = 7;
            this.pictureBoxNM1.TabStop = false;
            // 
            // songMenu
            // 
            this.songMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.songMenu.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.songMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(31)))));
            this.songMenu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.songMenu.Location = new System.Drawing.Point(10, 80);
            this.songMenu.Name = "songMenu";
            this.songMenu.Size = new System.Drawing.Size(800, 498);
            this.songMenu.TabIndex = 0;
            this.songMenu.TabStop = false;
            // 
            // modMenu
            // 
            this.modMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(31)))));
            this.modMenu.Enabled = false;
            this.modMenu.Location = new System.Drawing.Point(10, 80);
            this.modMenu.Name = "modMenu";
            this.modMenu.Size = new System.Drawing.Size(800, 498);
            this.modMenu.TabIndex = 0;
            this.modMenu.TabStop = false;
            this.modMenu.Visible = false;
            // 
            // settingsMenu
            // 
            this.settingsMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(31)))));
            this.settingsMenu.Enabled = false;
            this.settingsMenu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.settingsMenu.Location = new System.Drawing.Point(10, 80);
            this.settingsMenu.Name = "settingsMenu";
            this.settingsMenu.Size = new System.Drawing.Size(800, 498);
            this.settingsMenu.TabIndex = 0;
            this.settingsMenu.TabStop = false;
            this.settingsMenu.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(820, 588);
            this.Controls.Add(this.pictureBoxNM3);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.pictureBoxNM2);
            this.Controls.Add(this.pictureBoxNM1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.searchMode);
            this.Controls.Add(this.searchText);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.modsButton);
            this.Controls.Add(this.songsButton);
            this.Controls.Add(this.songMenu);
            this.Controls.Add(this.modMenu);
            this.Controls.Add(this.settingsMenu);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "NoodleManager";
            ((System.ComponentModel.ISupportInitialize)(this.searchButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNM3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNM1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableMenu songMenu;
        private TableMenu modMenu;
        private SettingsMenu settingsMenu;
        private System.Windows.Forms.Label songsButton;
        private System.Windows.Forms.Label modsButton;
        private System.Windows.Forms.Label settingsButton;
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.ComboBox searchMode;
        private System.Windows.Forms.Button closeButton;
        private PictureBoxNM pictureBoxNM1;
        private PictureBoxNM pictureBoxNM2;
        private System.Windows.Forms.PictureBox searchButton;
        private PictureBoxNM pictureBoxNM3;
    }
}

