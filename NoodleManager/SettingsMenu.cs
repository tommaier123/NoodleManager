﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace NoodleManager
{
    public partial class SettingsMenu : UserControl
    {
        public Settings settings;

        public SettingsMenu()
        {
            InitializeComponent();
            this.textBox1.Text = GlobalVariables.settings.directory;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.SelectedPath = this.textBox1.Text;
            DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.textBox1.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            GlobalVariables.settings.directory = this.textBox1.Text;
            GlobalVariables.WriteSettings();
        }
    }
}
