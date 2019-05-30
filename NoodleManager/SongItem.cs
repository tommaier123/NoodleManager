using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoodleManager
{
    class SongItem
    {
        public WebBrowser webBrowser1;
        public SongItem()
        {
            webBrowser1 = new WebBrowser();
            webBrowser1.AllowNavigation = false;
            webBrowser1.AllowWebBrowserDrop = false;
            webBrowser1.Dock = DockStyle.Fill;
            webBrowser1.IsWebBrowserContextMenuEnabled = false;
            webBrowser1.Location = new System.Drawing.Point(3, 3);
            webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            webBrowser1.Name = "webBrowser1";
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.ScrollBarsEnabled = false;
            webBrowser1.Size = new System.Drawing.Size(250, 250);
            webBrowser1.AutoSize = true;
            webBrowser1.TabIndex = 0;
            webBrowser1.TabStop = false;
            webBrowser1.Url = new Uri("https://www.google.com/", UriKind.Absolute);
            webBrowser1.WebBrowserShortcutsEnabled = false;
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(Resize);
        }

        private void Resize(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.Size = webBrowser1.Document.Body.ScrollRectangle.Size;
            webBrowser1.Enabled
        }
    }
}
