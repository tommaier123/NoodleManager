﻿namespace NoodleManager
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
            this.songMenu.Location = new System.Drawing.Point(0, 50);
            this.songMenu.Name = "songMenu";
            this.songMenu.Size = new System.Drawing.Size(800, 400);
            this.songMenu.TabIndex = 0;
            // 
            // modMenu
            // 
            this.modMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modMenu.Enabled = false;
            this.modMenu.Location = new System.Drawing.Point(0, 50);
            this.modMenu.Name = "modMenu";
            this.modMenu.Size = new System.Drawing.Size(800, 400);
            this.modMenu.TabIndex = 0;
            this.modMenu.Visible = false;
            // 
            // settingsMenu
            // 
            this.settingsMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.settingsMenu.Enabled = false;
            this.settingsMenu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.settingsMenu.Location = new System.Drawing.Point(0, 30);
            this.settingsMenu.Name = "settingsMenu";
            this.settingsMenu.Size = new System.Drawing.Size(800, 400);
            this.settingsMenu.TabIndex = 0;
            this.settingsMenu.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Name = "Form1";
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
    }
}

