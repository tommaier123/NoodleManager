using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UpdateHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Thread.Sleep(1000);

                string applicationLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
                applicationLocation = Path.GetDirectoryName(applicationLocation);
                string dirLocation = Path.GetDirectoryName(applicationLocation);

                foreach (string file in Directory.GetFiles(dirLocation + @"\NoodleManagerUpdate"))
                {
                    if (Path.GetFileName(file) != "UpdateHelper.exe")
                    {
                        File.Copy(file, Path.Combine(applicationLocation, Path.GetFileName(file)), true);
                    }
                }

                Thread.Sleep(3000);

                Directory.Delete(dirLocation + @"\NoodleManagerUpdate", true);

                var startInfo = new ProcessStartInfo();

                startInfo.WorkingDirectory = applicationLocation;
                startInfo.FileName = Path.Combine(applicationLocation, "NoodleManager.exe");

                Process proc = Process.Start(startInfo);
            }
            catch (Exception e)
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "Log.txt"), true))
                {
                    sw.WriteLine(e.ToString());
                }
            }
        }
    }
}
