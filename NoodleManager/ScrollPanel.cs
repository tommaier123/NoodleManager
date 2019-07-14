using System;
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
    public partial class ScrollPanel : UserControl
    {
        private Control scrollControl;
        private bool down = false;
        private Point down_mloc;
        private Point down_sloc;

        public ScrollPanel()
        {
            InitializeComponent();

            this.scrollBar.MouseDown += new MouseEventHandler(this.MouseDown_callback);
            this.scrollBar.MouseUp += new MouseEventHandler(this.MouseUp_callback);
            this.scrollBar.MouseMove += new MouseEventHandler(this.MouseMove_callback);
            this.scrollBar.MouseWheel += new MouseEventHandler(this.MouseWheel_callback);
            this.scrollBar.Resize += new EventHandler(this.Resize_callback);

            this.scrollBar.MouseLeave += new EventHandler(this.MouseLeave_callback);

            //this.scrollBar.MouseWheel += new MouseEventHandler(this.MouseWheel_callback);
        }

        public void SetControl(Control s)
        {
            scrollControl = s;
            scrollControl.MouseWheel += new MouseEventHandler(this.MouseWheel_callback);
            foreach (Control c in scrollControl.Controls)
            {
                c.MouseWheel += new MouseEventHandler(this.MouseWheel_callback);
                foreach (Control cc in c.Controls)
                {
                    cc.MouseWheel += new MouseEventHandler(this.MouseWheel_callback); 
                }
            }
        }

        private void MouseMove_callback(object sender, MouseEventArgs e)
        {
            if (scrollControl != null && down)
            {
                int scrollheight = this.scrollBar.Size.Height - this.scrollBar.grabber.Size.Height;
                int scrollable = this.scrollControl.Size.Height - this.scrollBar.Size.Height;
                Point temp = scrollControl.Location;

                temp.Y = (int)(down_sloc.Y + scrollable * ((down_mloc.Y - e.Location.Y) / (double)scrollheight));

                if (temp.Y > 0)
                {
                    temp.Y = 0;
                }
                else if (temp.Y < -scrollable)
                {
                    temp.Y = -scrollable;
                }

                this.scrollControl.Location = temp;

                Point temp2 = this.scrollBar.grabber.Location;
                temp2.Y = (int)(-scrollheight * temp.Y / (double)scrollable);
                this.scrollBar.grabber.Location = temp2;
            }
        }

        private void MouseWheel_callback(object sender, MouseEventArgs e)
        {
            if (scrollControl != null)
            {
                int scrollheight = this.scrollBar.Size.Height - this.scrollBar.grabber.Size.Height;
                int scrollable = this.scrollControl.Size.Height - this.scrollBar.Size.Height;
                Point temp = scrollControl.Location;

                if (e.Delta>0)
                {
                    temp.Y += 60;
                }
                else if (e.Delta < 0)
                {
                    temp.Y -= 60;
                }

                if (temp.Y > 0)
                {
                    temp.Y = 0;
                }
                else if (temp.Y < -scrollable)
                {
                    temp.Y = -scrollable;
                }

                this.scrollControl.Location = temp;

                Point temp2 = this.scrollBar.grabber.Location;
                temp2.Y = (int)(-scrollheight * temp.Y / (double)scrollable);
                this.scrollBar.grabber.Location = temp2;
            }
        }

        private void Resize_callback(object sender, EventArgs e)
        {
            if (scrollControl != null)
            {
                int scrollheight = this.scrollBar.Size.Height - this.scrollBar.grabber.Size.Height;
                int scrollable = this.scrollControl.Size.Height - this.scrollBar.Size.Height;
                Point temp = scrollControl.Location;

                if (temp.Y < -scrollable)
                {
                    temp.Y = -scrollable;
                    this.scrollControl.Location = temp;
                }

                Point temp2 = this.scrollBar.grabber.Location;
                temp2.Y = (int)(-scrollheight * temp.Y / (double)scrollable);
                this.scrollBar.grabber.Location = temp2;
            }
        }

        private void MouseDown_callback(object sender, MouseEventArgs e)
        {
            down = true;
            down_mloc = e.Location;
            if (scrollControl != null)
            {
                down_sloc = this.scrollControl.Location;
            }
        }

        private void MouseUp_callback(object sender, MouseEventArgs e)
        {
            down = false;
        }

        private void MouseLeave_callback(object sender, EventArgs e)
        {
            down = false;
        }
    }
}
