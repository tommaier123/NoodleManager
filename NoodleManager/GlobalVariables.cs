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
        public static List<SongControl> downloadingSongs=new List<SongControl>();

        public static SongControl PlayingSongs;

        public static string TagName = "V1.3.7";

        public static int Available = 0;

        public static void PlayNew(SongControl s)
        {
            if (PlayingSongs != null)
            {
                PlayingSongs.StopPlayback();
            }
            PlayingSongs = s;
            PlayingSongs.StartPlayback();
        }

        public static void StopPlayback()
        {
            if (PlayingSongs != null)
            {
                PlayingSongs.StopPlayback();
            }
        }
    }
}
