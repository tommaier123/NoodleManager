﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoodleManager
{
    public partial class TableMenu : ScrollPanel
    {
        public TableMenu()
        {
            InitializeComponent();
            SetControl(this.tableLayoutPanel);
        }
    }
}
