using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UpdateHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 1)
                {
                    string applicationLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
                    applicationLocation = applicationLocation.Substring(0, applicationLocation.LastIndexOf(@"\"));
                    string dirLocation = applicationLocation.Substring(0, applicationLocation.LastIndexOf(@"\"));

                    Directory.Delete(dirLocation+@"\"+args[0]);
                    Directory.Move(applicationLocation, dirLocation + @"\" + args[0]);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
