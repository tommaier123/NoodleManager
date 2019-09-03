using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                try
                {
                    Console.WriteLine(args[0]);
                    string id = args[0].Substring(0, args[0].LastIndexOf("/"));
                    id = id.Substring(id.LastIndexOf("/") + 1);
                    Console.WriteLine(id);

                    string applicationLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
                    string directory = applicationLocation.Substring(0, applicationLocation.LastIndexOf(@"\"));

                    using (StreamWriter sw = new StreamWriter(directory + @"\ToDownload.txt", true))
                    {
                        sw.WriteLine(id);
                    }

                    bool found = false;
                    foreach (Process p in Process.GetProcesses())
                    {
                        if (p.ProcessName.Contains("NoodleManager"))
                        {
                            found = true;
                        }
                    }

                    if (found == false)
                    {
                        var startInfo = new ProcessStartInfo();

                        startInfo.WorkingDirectory = directory;
                        startInfo.FileName = directory + @"\NoodleManager.exe";

                        Process proc = Process.Start(startInfo);

                    }

                    Console.WriteLine(found);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
                Console.ReadLine();
            }
        }
    }
}
