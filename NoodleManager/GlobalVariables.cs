using NAudio.Wave;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NoodleManager
{
    public static class GlobalVariables
    {
        public static Dictionary<WebClient, string> clients = new Dictionary<WebClient, string>();

        public static IWavePlayer MusicPlayer;
        public static MediaFoundationReader AudioReader;
    }
}
