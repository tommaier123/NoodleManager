using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoodleManager
{
    class SongInfo
    {
        public int id = -1;
        public string title = "N/A";
        public string artist = "N/A";
        public string mapper = "N/A";
        public string bpm = "N/A";
        public string[] difficulties = { "", "", "", "" };
        public string filename_original = "default.synth";
        public string cover_url = "";
        public string download_url = "";
        public string preview_url = "";
        public string created_at = "N/A";
        public string updated_at = "N/A";
        public int version = -1;
        public string duration = "N/A";
    }
}
