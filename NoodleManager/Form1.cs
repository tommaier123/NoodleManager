using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoodleManager
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            SongItem songitem1 = new SongItem();
            flowLayoutPanel1.Controls.Add(songitem1.webBrowser1);
            SongItem songitem2 = new SongItem();
            flowLayoutPanel1.Controls.Add(songitem2.webBrowser1);
            SongItem songitem3 = new SongItem();
            flowLayoutPanel1.Controls.Add(songitem3.webBrowser1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
