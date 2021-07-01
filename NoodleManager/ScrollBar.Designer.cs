namespace NoodleManager
{
    partial class ScrollBar
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
            this.grabber = new NoodleManager.PictureBoxNM();
            ((System.ComponentModel.ISupportInitialize)(this.grabber)).BeginInit();
            this.SuspendLayout();
            // 
            // grabber
            // 
            this.grabber.BackColor = System.Drawing.SystemColors.Desktop;
            this.grabber.Location = new System.Drawing.Point(0, 0);
            this.grabber.Name = "grabber";
            this.grabber.Size = new System.Drawing.Size(20, 30);
            this.grabber.TabIndex = 0;
            this.grabber.TabStop = false;
            // 
            // ScrollBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.grabber);
            this.Name = "ScrollBar";
            this.Size = new System.Drawing.Size(20, 498);
            ((System.ComponentModel.ISupportInitialize)(this.grabber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public PictureBoxNM grabber;
    }
}
