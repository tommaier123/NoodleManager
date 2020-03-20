using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoodleManager
{
    public partial class Form1 : Form
    {
        private const int cGrip = 10;      // Grip size
        private const int cCaption = 70;   // Caption bar height;
        private List<WebClient> downloadMarker = new List<WebClient>();
        private bool update = false;

        public const string baseurl = "https://synthriderz.com";
        public const string beatmapsurl = "/api/beatmaps";

        FileSystemWatcher watcher;

        public Form1()
        {

            try
            {
                Octokit.GitHubClient github = new Octokit.GitHubClient(new Octokit.ProductHeaderValue("NoodleManager"));
                Octokit.Release latest = github.Repository.Release.GetLatest("tommaier123", "NoodleManager").Result;

                if (GlobalVariables.TagName != latest.TagName)
                {
                    ErrorDialog errorDialog = new ErrorDialog("New Update to " + latest.TagName + " available:" + Environment.NewLine + Environment.NewLine + latest.Body + Environment.NewLine + Environment.NewLine + "Do you want to Download it?");
                    DialogResult result = errorDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
#if DEBUG
#else
                        UpdateFiles();
#endif
                    }
                }
            }
            catch (Exception e)
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location, "Log.txt"), true))
                {
                    sw.WriteLine(e.ToString());
                }
            }

#if DEBUG
#else
            RegisterUriScheme();
#endif


            InitializeComponent();

            this.labelNM1.Text = GlobalVariables.TagName;

            Label te = new Label();
            te.Text = "Mods Coming Soon";
            te.Size = new Size(600, 300);
            te.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            te.ForeColor = System.Drawing.Color.White;
            modMenu.Controls.Add(te);

            this.pictureBoxNM1.SendToBack();

            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.searchMode.DataSource = new string[] { "All", "Title", "Mapper", "Artist" };
            this.displayMode.DataSource = new string[] { "All", "Available", "Installed" };

            this.FormClosing += FormclosingCallback;

            this.searchText.KeyDown += new KeyEventHandler(this.SearchKeyDownCallback);

            if (!Directory.Exists(Path.Combine(Properties.Settings.Default.path, @"CustomSongs\")))
            {
                ShowSettings();
            }
            else
            {
                watcher = new FileSystemWatcher();
                string applicationLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
                watcher.Path = "./";
                watcher.NotifyFilter = NotifyFilters.LastWrite;
                watcher.Filter = "ToDownload.txt";
                watcher.Changed += OnFileChanged;
                watcher.EnableRaisingEvents = true;

                this.songMenu.Focus();
                if (ReadDownloadFile() == false)
                {
                    DownloadString(baseurl + beatmapsurl);
                }
            }
        }

        private void UpdateFiles()
        {
            try
            {
                string applicationLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
                applicationLocation = Path.GetDirectoryName(applicationLocation);
                string dirLocation = Path.GetDirectoryName(applicationLocation);

                if (File.Exists(Path.Combine(dirLocation, "NoodleManagerDownload.zip")))
                {
                    File.Delete(Path.Combine(dirLocation, "NoodleManagerDownload.zip"));
                }

                if (Directory.Exists(Path.Combine(dirLocation, "NoodleManagerUpdate")))
                {
                    Directory.Delete(Path.Combine(dirLocation, "NoodleManagerUpdate"), true);
                }

                if (Directory.Exists(Path.Combine(dirLocation, "NoodleManagerDownload")))
                {
                    Directory.Delete(Path.Combine(dirLocation, "NoodleManagerDownload"), true);
                }

                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/tommaier123/NoodleManager/releases/latest/download/NoodleManager.zip", Path.Combine(dirLocation, "NoodleManagerDownload.zip"));
                }

                ZipFile.ExtractToDirectory(Path.Combine(dirLocation, "NoodleManagerDownload.zip"), Path.Combine(dirLocation, "NoodleManagerDownload"));
                File.Delete(Path.Combine(dirLocation, "NoodleManagerDownload.zip"));
                Directory.Move(Path.Combine(dirLocation, @"NoodleManagerDownload\NoodleManagerRelease"), Path.Combine(dirLocation, "NoodleManagerUpdate"));
                Directory.Delete(Path.Combine(dirLocation, "NoodleManagerDownload"), true);


                if (File.Exists(Path.Combine(dirLocation, @"NoodleManagerUpdate\UpdateHelper.exe")))
                {
                    //File.Copy(Path.Combine(dirLocation, @"NoodleManagerUpdate\UpdateHelper.exe"), Path.Combine(applicationLocation, "UpdateHelper.exe"), true);
                }

                update = true;

                Thread thread1 = new Thread(() =>
                {
                    Thread.Sleep(100);
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.Close();
                    });
                });
                thread1.Start();
            }
            catch (Exception e)
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location, "Log.txt"), true))
                {
                    sw.WriteLine(e.ToString());
                }
            }
        }

        private void OnFileChanged(object source, FileSystemEventArgs e)
        {
            Thread.Sleep(5);
            ReadDownloadFile();
        }

        public bool ReadDownloadFile()
        {
            bool ret = false;
            if (!File.Exists("ToDownload.txt"))
            {
                File.Create("ToDownload.txt");
                Thread.Sleep(5);
            }
            string[] lines = File.ReadAllLines("ToDownload.txt");
            foreach (string line in lines)
            {
                if (line != null && line != "")
                {
                    ret = true;
                    DownloadString(baseurl + beatmapsurl + "/" + line, false, true);
                }
            }
            Thread.Sleep(5);
            try
            {
                using (StreamWriter sw = new StreamWriter("ToDownload.txt", false))
                {
                    sw.Write("");
                }
            }
            catch (Exception e)
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location, "Log.txt"), true))
                {
                    sw.WriteLine(e.ToString());
                }
            }
            return ret;
        }

        private void DownloadString(string path, bool clear = true, bool download = false)
        {
            if (clear)
            {
                this.songMenu.tableLayoutPanel.Controls.Clear();
                this.songMenu.tableLayoutPanel.Visible = false;
                this.songMenu.tableLayoutPanel.Location = new Point(0, 0);
                this.songMenu.scrollBar.grabber.Location = new Point(0, 0);
                this.Cursor = Cursors.WaitCursor;
            }

            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadStringCompleted += DownloadCompleteCallback;
                    if (download)
                    {
                        downloadMarker.Add(client);
                    }
                    client.DownloadStringAsync(new Uri(path));
                }
            }
            catch (Exception e)
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location, "Log.txt"), true))
                {
                    sw.WriteLine(e.ToString());
                }
            }
        }

        private void DownloadCompleteCallback(object sender, DownloadStringCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null && e.Result != null && e.Result != "")
            {
                GlobalVariables.Available = 0;
                byte[] bytes = Encoding.Default.GetBytes(e.Result);
                string content = Encoding.UTF8.GetString(bytes);
                SongInfo[] items = new SongInfo[1];
                try
                {
                    items = JsonConvert.DeserializeObject<SongInfo[]>(content);
                }
                catch
                {
                    items[0] = JsonConvert.DeserializeObject<SongInfo>(content);
                }

                foreach (SongInfo item in items)
                {
                    if (GlobalVariables.downloadingSongs.Where(i => i.id == item.id).Count() > 0)
                    {
                        Console.WriteLine("already exists");
                        this.Invoke((MethodInvoker)delegate
                        {
                            RemoveDuplicates(item.id);
                            this.songMenu.tableLayoutPanel.Controls.Add(GlobalVariables.downloadingSongs.Where(i => i.id == item.id).ElementAt(0));
                        });
                    }
                    else
                    {
                        SongControl song = new SongControl();
                        song.downloadPath = baseurl + item.download_url;
                        song.previewPath = baseurl + item.preview_url;
                        song.originalFilename = item.filename_original;
                        song.coverImage.ImageLocation = baseurl + item.cover_url + "?size=150";
                        song.songName.Text = item.title;
                        song.mapperName.Text = item.mapper;
                        song.difficulties = item.difficulties;
                        song.artist.Text = item.artist;
                        song.duration.Text = item.duration;
                        song.id = item.id;

                        foreach (string difficulty in item.difficulties)
                        {
                            if (difficulty.Equals("Easy"))
                            {
                                song.Easy.ForeColor = System.Drawing.Color.White;
                            }
                            else if (difficulty.Equals("Normal"))
                            {
                                song.Normal.ForeColor = System.Drawing.Color.White;
                            }
                            else if (difficulty.Equals("Hard"))
                            {
                                song.Hard.ForeColor = System.Drawing.Color.White;
                            }
                            else if (difficulty.Equals("Expert"))
                            {
                                song.Expert.ForeColor = System.Drawing.Color.White;
                            }
                            else if (difficulty.Equals("Master"))
                            {
                                song.Master.ForeColor = System.Drawing.Color.White;
                            }
                        }

                        if (this.songMenu.tableLayoutPanel.Controls.Count < 180)
                        {
                            this.Invoke((MethodInvoker)delegate
                        {
                            RemoveDuplicates(song.id);

                            this.songMenu.tableLayoutPanel.Controls.Add(song);
                        });
                        }

                        if (File.Exists(Properties.Settings.Default.path + @"\CustomSongs\" + item.filename_original))
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                song.Deactivate();

                                if (this.displayMode.SelectedIndex == 1)
                                {
                                    this.songMenu.tableLayoutPanel.Controls.Remove(song);
                                }
                            });
                        }
                        else
                        {
                            GlobalVariables.Available++;
                            if (this.displayMode.SelectedIndex == 2)
                            {
                                this.songMenu.tableLayoutPanel.Controls.Remove(song);
                            }
                            if (sender != null && downloadMarker.Contains(sender))
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    song.Download();
                                });
                            }
                        }
                    }
                }
                this.Invoke((MethodInvoker)delegate
                {
                    this.songMenu.tableLayoutPanel.Visible = true;
                });
            }
            this.Invoke((MethodInvoker)delegate
            {
                foreach (SongControl c in GlobalVariables.downloadingSongs)
                {
                    if (!this.songMenu.tableLayoutPanel.Controls.Contains(c) && this.songMenu.tableLayoutPanel.Controls.Count < 180)
                    {
                        this.songMenu.tableLayoutPanel.Controls.Add(c);
                    }
                }
                this.Cursor = Cursors.Default;
            });
            downloadMarker.Remove((WebClient)sender);
        }

        private void RemoveDuplicates(int id)
        {
            List<SongControl> duplicates = new List<SongControl>();
            foreach (SongControl c in this.songMenu.tableLayoutPanel.Controls)
            {
                if (c.id == id)
                {
                    duplicates.Add(c);
                }
            }
            if (duplicates.Count > 0)
            {
                foreach (SongControl duplicate in duplicates)
                {
                    this.songMenu.tableLayoutPanel.Controls.Remove(duplicate);
                }
            }
        }

        private void GetAll(bool download = true)
        {
            this.songMenu.tableLayoutPanel.Controls.Clear();
            this.songMenu.tableLayoutPanel.Visible = false;
            this.songMenu.tableLayoutPanel.Location = new Point(0, 0);
            this.songMenu.scrollBar.grabber.Location = new Point(0, 0);
            this.Cursor = Cursors.WaitCursor;

            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadStringCompleted += DownloadCompleteCallback;

                    if (download)
                    {
                        downloadMarker.Add(client);
                    }
                    client.DownloadStringAsync(new Uri(baseurl + beatmapsurl));
                }
            }
            catch(Exception e)
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location, "Log.txt"), true))
                {
                    sw.WriteLine(e.ToString());
                }
            }
        }

        private void FormclosingCallback(object sender, FormClosingEventArgs e)
        {
            if (GlobalVariables.downloadingSongs.Count > 0)
            {
                ErrorDialog errorDialog = new ErrorDialog(GlobalVariables.downloadingSongs.Count.ToString() + " Songs are still Downloading." + Environment.NewLine + "Stop the Download?");
                DialogResult result = errorDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    var dsongs = GlobalVariables.downloadingSongs;
                    foreach (SongControl c in dsongs)
                    {
                        if (c != null)
                        {
                            c.Delete();
                        }
                    }
                    if (update)
                    {
                        Rename();
                    }
                }
                else
                {
                    GlobalVariables.StopPlayback();
                    e.Cancel = true;
                }
            }
            else
            {
                if (update)
                {
                    Rename();
                }
            }
        }

        private void Rename()
        {
            string applicationLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
            applicationLocation = Path.GetDirectoryName(applicationLocation);

            if (File.Exists(Path.Combine(applicationLocation, "UpdateHelper.exe")))
            {
                var startInfo = new ProcessStartInfo();

                startInfo.WorkingDirectory = applicationLocation;
                startInfo.FileName = Path.Combine(applicationLocation, "UpdateHelper.exe");

                Process proc = Process.Start(startInfo);
            }
        }

        private void Songs_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                this.searchText.Text = "";
                GlobalVariables.StopPlayback();
                if (!Directory.Exists(Path.Combine(settingsMenu.textBox1.Text, @"CustomSongs\")))
                {
                    ShowSettings();
                }
                else
                {
                    Properties.Settings.Default.path = settingsMenu.textBox1.Text;
                    Properties.Settings.Default.Save();

                    songMenu.Enabled = true;
                    songMenu.Visible = true;

                    modMenu.Enabled = false;
                    modMenu.Visible = false;

                    settingsMenu.Enabled = false;
                    settingsMenu.Visible = false;

                    this.songsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(249)))), ((int)(((byte)(28)))), ((int)(((byte)(133)))));
                    this.modsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(170)))), ((int)(((byte)(73)))), ((int)(((byte)(224)))));
                    this.SettingsButton.Image = global::NoodleManager.Properties.Resources.settings_u;

                    DownloadString(baseurl + beatmapsurl);
                    this.songMenu.Focus();
                }
            }
        }

        private void Mods_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                this.searchText.Text = "";
                GlobalVariables.StopPlayback();
                if (!Directory.Exists(Path.Combine(settingsMenu.textBox1.Text, @"CustomSongs\")))
                {
                    ShowSettings();
                }
                else
                {
                    Properties.Settings.Default.path = settingsMenu.textBox1.Text;
                    Properties.Settings.Default.Save();

                    songMenu.Enabled = false;
                    songMenu.Visible = false;

                    modMenu.Enabled = true;
                    modMenu.Visible = true;

                    settingsMenu.Enabled = false;
                    settingsMenu.Visible = false;

                    this.songsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(170)))), ((int)(((byte)(73)))), ((int)(((byte)(224)))));
                    this.modsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(249)))), ((int)(((byte)(28)))), ((int)(((byte)(133)))));
                    this.SettingsButton.Image = global::NoodleManager.Properties.Resources.settings_u;

                    this.modMenu.Focus();
                }
            }
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                ShowSettings();
            }
        }

        private void ShowSettings()
        {
            this.searchText.Text = "";

            GlobalVariables.StopPlayback();

            songMenu.Enabled = false;
            songMenu.Visible = false;

            modMenu.Enabled = false;
            modMenu.Visible = false;

            settingsMenu.Enabled = true;
            settingsMenu.Visible = true;

            settingsMenu.textBox1.Text = Properties.Settings.Default.path;

            this.songsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(170)))), ((int)(((byte)(73)))), ((int)(((byte)(224)))));
            this.modsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(170)))), ((int)(((byte)(73)))), ((int)(((byte)(224)))));
            this.SettingsButton.Image = global::NoodleManager.Properties.Resources.settings_s;

            this.settingsMenu.Focus();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                Search();
            }
        }

        private void SearchKeyDownCallback(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void Search()
        {
            GlobalVariables.StopPlayback();
            string mode = "q";
            if (this.searchMode.SelectedIndex == 1)
            {
                mode = "title";
            }
            else if (this.searchMode.SelectedIndex == 2)
            {
                mode = "mapper";
            }
            else if (this.searchMode.SelectedIndex == 3)
            {
                mode = "artist";
            }

            DownloadString(baseurl + beatmapsurl + "?" + mode + "=" + this.searchText.Text);
        }

        protected override void WndProc(ref Message m)//using the windows defaut resize with a borderless window
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                bool right = false;
                bool left = false;
                bool top = false;
                bool bottom = false;

                if (pos.X >= this.ClientSize.Width - cGrip)
                {
                    right = true;
                }
                else if (pos.X < cGrip)
                {
                    left = true;
                }

                if (pos.Y >= this.ClientSize.Height - cGrip)
                {
                    bottom = true;
                }
                else if (pos.Y < cGrip)
                {
                    top = true;
                }

                if (right)
                {
                    if (bottom)
                    {
                        m.Result = (IntPtr)17;  // HTBOTTOMRIGHT
                        return;
                    }
                    else if (top)
                    {
                        m.Result = (IntPtr)14;  // HTTOPRIGHT
                        return;
                    }
                    else
                    {
                        m.Result = (IntPtr)11;  // HTRIGHT
                        return;
                    }
                }
                else if (left)
                {
                    if (bottom)
                    {
                        m.Result = (IntPtr)16;  // HTBOTTOMLEFT
                        return;
                    }
                    else if (top)
                    {
                        m.Result = (IntPtr)13;  // HTTOPLEFT
                        return;
                    }
                    else
                    {
                        m.Result = (IntPtr)10;  // HTLEFT
                        return;
                    }
                }
                else if (bottom)
                {
                    m.Result = (IntPtr)15;  // HTBOTTOM
                    return;
                }
                else if (top)
                {
                    m.Result = (IntPtr)12;  // HTTOP
                    return;
                }
                else if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
            }
            base.WndProc(ref m);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Return)
            {
                this.Search();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                this.Close();
            }
        }

        private void FullscreenButton_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;
                }
            }
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void RegisterUriScheme()
        {
            using (var key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\" + "synthriderz"))
            {
                string applicationLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
                applicationLocation = applicationLocation.Substring(0, applicationLocation.LastIndexOf(@"\")) + @"\DownloadHelper.exe";
                Console.WriteLine(applicationLocation);
                key.SetValue("", "URL:" + "Synthriderz");
                key.SetValue("URL Protocol", "");
                using (var defaultIcon = key.CreateSubKey("DefaultIcon"))
                {
                    defaultIcon.SetValue("", applicationLocation + ",1");
                }
                using (var commandKey = key.CreateSubKey(@"shell\open\command"))
                {
                    commandKey.SetValue("", "\"" + applicationLocation + "\" \"%1\"");
                }
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            Process.Start("https://synthriderz.com");
        }

        private void displayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void searchMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DownloadAll();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DownloadAll();
        }

        private void DownloadAll()
        {
            if (GlobalVariables.Available > 0)
            {
                ErrorDialog errorDialog = new ErrorDialog("Do you want to Download " + GlobalVariables.Available.ToString() + " new Songs?");
                DialogResult result = errorDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    GetAll(true);
                }
            }
            else
            {
                ErrorDialog errorDialog = new ErrorDialog("No new Songs available");
                DialogResult result = errorDialog.ShowDialog();
            }
        }
    }
}
