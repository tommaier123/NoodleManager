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
    public partial class RightClickDialog : Form
    {
        public Func<int, bool> Callback;

        public RightClickDialog()
        {
            InitializeComponent();
            this.Deactivate += new EventHandler(this.DeactivateCallback);
            this.CancelButton = this.Cancel;
        }

        private void DeactivateCallback(object sender, EventArgs e)
        {
            if (Callback(0))
            {
                this.Close();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (Callback(0))
            {
                this.Close();
            }
        }

        private void Reload_Click(object sender, EventArgs e)
        {
            if (Callback(1))
            {
                this.Close();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (Callback(2))
            {
                this.Close();
            }
        }
    }
}
