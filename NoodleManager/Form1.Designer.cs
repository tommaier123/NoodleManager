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
            this.songsButton = new System.Windows.Forms.Label();
            this.modsButton = new System.Windows.Forms.Label();
            this.settingsButton = new System.Windows.Forms.Label();
            this.searchText = new System.Windows.Forms.TextBox();
            this.searchMode = new System.Windows.Forms.ComboBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.songMenu = new NoodleManager.TableMenu();
            this.modMenu = new NoodleManager.TableMenu();
            this.settingsMenu = new NoodleManager.SettingsMenu();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBoxNM1 = new NoodleManager.PictureBoxNM();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNM1)).BeginInit();
            this.SuspendLayout();
            // 
            // songsButton
            // 
            this.songsButton.AutoSize = true;
            this.songsButton.Location = new System.Drawing.Point(13, 13);
            this.songsButton.Name = "songsButton";
            this.songsButton.Size = new System.Drawing.Size(37, 13);
            this.songsButton.TabIndex = 1;
            this.songsButton.Text = "Songs";
            this.songsButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.songsButton.Click += new System.EventHandler(this.Songs_Click);
            // 
            // modsButton
            // 
            this.modsButton.AutoSize = true;
            this.modsButton.Location = new System.Drawing.Point(56, 13);
            this.modsButton.Name = "modsButton";
            this.modsButton.Size = new System.Drawing.Size(33, 13);
            this.modsButton.TabIndex = 2;
            this.modsButton.Text = "Mods";
            this.modsButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.modsButton.Click += new System.EventHandler(this.Mods_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(95, 13);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(45, 15);
            this.settingsButton.TabIndex = 0;
            this.settingsButton.Text = "Settings";
            this.settingsButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.settingsButton.Click += new System.EventHandler(this.Settings_Click);
            // 
            // searchText
            // 
            this.searchText.Location = new System.Drawing.Point(218, 13);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(100, 20);
            this.searchText.TabIndex = 3;
            // 
            // searchMode
            // 
            this.searchMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchMode.FormattingEnabled = true;
            this.searchMode.Location = new System.Drawing.Point(324, 13);
            this.searchMode.Name = "searchMode";
            this.searchMode.Size = new System.Drawing.Size(121, 21);
            this.searchMode.TabIndex = 4;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(450, 12);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "button1";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
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
            this.settingsMenu.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(712, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(820, 588);
            this.Controls.Add(this.pictureBoxNM1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.searchButton);
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
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button button1;
        private PictureBoxNM pictureBoxNM1;
    }
}

