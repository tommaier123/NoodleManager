using System;
using System.Collections.Generic;
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

                Directory.Delete(dirLocation + @"\NoodleManagerUpdate", true);
            }
            catch (Exception e)
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location, "Log.txt"), true))
                {
                    sw.WriteLine(e.ToString());
                }
            }
        }
    }
}
