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
            this.searchText = new System.Windows.Forms.TextBox();
            this.searchMode = new System.Windows.Forms.ComboBox();
            this.MinimizeButton = new System.Windows.Forms.PictureBox();
            this.FullscreenButton = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.PictureBox();
            this.SettingsButton = new System.Windows.Forms.PictureBox();
            this.searchButton = new System.Windows.Forms.PictureBox();
            this.displayMode = new System.Windows.Forms.ComboBox();
            this.labelNM1 = new NoodleManager.LabelNM();
            this.pictureBoxNM3 = new NoodleManager.PictureBoxNM();
            this.pictureBoxNM2 = new NoodleManager.PictureBoxNM();
            this.pictureBoxNM1 = new NoodleManager.PictureBoxNM();
            this.songMenu = new NoodleManager.TableMenu();
            this.modMenu = new NoodleManager.TableMenu();
            this.settingsMenu = new NoodleManager.SettingsMenu();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullscreenButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNM3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNM1)).BeginInit();
            this.SuspendLayout();
            // 
            // songsButton
            // 
            this.songsButton.AutoSize = true;
            this.songsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.songsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(249)))), ((int)(((byte)(28)))), ((int)(((byte)(133)))));
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
            this.modsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.modsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(170)))), ((int)(((byte)(73)))), ((int)(((byte)(224)))));
            this.modsButton.Location = new System.Drawing.Point(232, 23);
            this.modsButton.Name = "modsButton";
            this.modsButton.Size = new System.Drawing.Size(61, 20);
            this.modsButton.TabIndex = 2;
            this.modsButton.Text = "MODS";
            this.modsButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.modsButton.Click += new System.EventHandler(this.Mods_Click);
            // 
            // searchText
            // 
            this.searchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchText.BackColor = System.Drawing.Color.Black;
            this.searchText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchText.ForeColor = System.Drawing.Color.Gray;
            this.searchText.Location = new System.Drawing.Point(382, 23);
            this.searchText.MinimumSize = new System.Drawing.Size(0, 20);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(202, 20);
            this.searchText.TabIndex = 3;
            this.searchText.WordWrap = false;
            // 
            // searchMode
            // 
            this.searchMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchMode.ForeColor = System.Drawing.Color.Gray;
            this.searchMode.FormattingEnabled = true;
            this.searchMode.Location = new System.Drawing.Point(627, 24);
            this.searchMode.Name = "searchMode";
            this.searchMode.Size = new System.Drawing.Size(73, 24);
            this.searchMode.TabIndex = 4;
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimizeButton.ErrorImage = null;
            this.MinimizeButton.Image = global::NoodleManager.Properties.Resources.minimize;
            this.MinimizeButton.InitialImage = null;
            this.MinimizeButton.Location = new System.Drawing.Point(832, 5);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(20, 20);
            this.MinimizeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MinimizeButton.TabIndex = 16;
            this.MinimizeButton.TabStop = false;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // FullscreenButton
            // 
            this.FullscreenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FullscreenButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FullscreenButton.ErrorImage = null;
            this.FullscreenButton.Image = global::NoodleManager.Properties.Resources.fullscreen;
            this.FullscreenButton.InitialImage = null;
            this.FullscreenButton.Location = new System.Drawing.Point(858, 5);
            this.FullscreenButton.Name = "FullscreenButton";
            this.FullscreenButton.Size = new System.Drawing.Size(20, 20);
            this.FullscreenButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FullscreenButton.TabIndex = 15;
            this.FullscreenButton.TabStop = false;
            this.FullscreenButton.Click += new System.EventHandler(this.FullscreenButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.ErrorImage = null;
            this.CloseButton.Image = global::NoodleManager.Properties.Resources.close;
            this.CloseButton.InitialImage = null;
            this.CloseButton.Location = new System.Drawing.Point(884, 5);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(20, 20);
            this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CloseButton.TabIndex = 14;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SettingsButton.ErrorImage = null;
            this.SettingsButton.Image = global::NoodleManager.Properties.Resources.settings_u;
            this.SettingsButton.InitialImage = null;
            this.SettingsButton.Location = new System.Drawing.Point(317, 18);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(30, 30);
            this.SettingsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SettingsButton.TabIndex = 13;
            this.SettingsButton.TabStop = false;
            this.SettingsButton.Click += new System.EventHandler(this.Settings_Click);
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchButton.ErrorImage = null;
            this.searchButton.Image = global::NoodleManager.Properties.Resources.search;
            this.searchButton.InitialImage = null;
            this.searchButton.Location = new System.Drawing.Point(590, 23);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(24, 24);
            this.searchButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.searchButton.TabIndex = 9;
            this.searchButton.TabStop = false;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // displayMode
            // 
            this.displayMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.displayMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.displayMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.displayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.displayMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.displayMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayMode.ForeColor = System.Drawing.Color.Gray;
            this.displayMode.FormattingEnabled = true;
            this.displayMode.Location = new System.Drawing.Point(715, 24);
            this.displayMode.Name = "displayMode";
            this.displayMode.Size = new System.Drawing.Size(83, 24);
            this.displayMode.TabIndex = 18;
            // 
            // labelNM1
            // 
            this.labelNM1.AutoSize = true;
            this.labelNM1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.labelNM1.Location = new System.Drawing.Point(95, 49);
            this.labelNM1.Name = "labelNM1";
            this.labelNM1.Size = new System.Drawing.Size(42, 13);
            this.labelNM1.TabIndex = 17;
            this.labelNM1.Text = "V1.2.9*";
            // 
            // pictureBoxNM3
            // 
            this.pictureBoxNM3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxNM3.ErrorImage = null;
            this.pictureBoxNM3.Image = global::NoodleManager.Properties.Resources.searchUnderline;
            this.pictureBoxNM3.InitialImage = null;
            this.pictureBoxNM3.Location = new System.Drawing.Point(382, 45);
            this.pictureBoxNM3.Name = "pictureBoxNM3";
            this.pictureBoxNM3.Size = new System.Drawing.Size(208, 3);
            this.pictureBoxNM3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxNM3.TabIndex = 10;
            this.pictureBoxNM3.TabStop = false;
            // 
            // pictureBoxNM2
            // 
            this.pictureBoxNM2.ErrorImage = null;
            this.pictureBoxNM2.Image = global::NoodleManager.Properties.Resources.noodleManagerLogo;
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
            this.pictureBoxNM1.Size = new System.Drawing.Size(920, 518);
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
            this.songMenu.Size = new System.Drawing.Size(890, 498);
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
            this.modMenu.Size = new System.Drawing.Size(900, 498);
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
            this.settingsMenu.Size = new System.Drawing.Size(900, 498);
            this.settingsMenu.TabIndex = 0;
            this.settingsMenu.TabStop = false;
            this.settingsMenu.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(910, 588);
            this.Controls.Add(this.displayMode);
            this.Controls.Add(this.labelNM1);
            this.Controls.Add(this.MinimizeButton);
            this.Controls.Add(this.FullscreenButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.pictureBoxNM3);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.pictureBoxNM2);
            this.Controls.Add(this.pictureBoxNM1);
            this.Controls.Add(this.searchMode);
            this.Controls.Add(this.searchText);
            this.Controls.Add(this.modsButton);
            this.Controls.Add(this.songsButton);
            this.Controls.Add(this.songMenu);
            this.Controls.Add(this.modMenu);
            this.Controls.Add(this.settingsMenu);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(910, 70);
            this.Name = "Form1";
            this.Text = "NoodleManager";
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullscreenButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsButton)).EndInit();
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
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.ComboBox searchMode;
        private PictureBoxNM pictureBoxNM1;
        private PictureBoxNM pictureBoxNM2;
        private System.Windows.Forms.PictureBox searchButton;
        private PictureBoxNM pictureBoxNM3;
        private System.Windows.Forms.PictureBox SettingsButton;
        private System.Windows.Forms.PictureBox CloseButton;
        private System.Windows.Forms.PictureBox FullscreenButton;
        private System.Windows.Forms.PictureBox MinimizeButton;
        private LabelNM labelNM1;
        private System.Windows.Forms.ComboBox displayMode;
    }
}

