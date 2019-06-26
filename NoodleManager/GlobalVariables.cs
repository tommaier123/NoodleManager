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
        public static Settings settings=new Settings();
        public static List<WebClient> clients=new List<WebClient>();

        private static string settingsPath = "settings.txt";

        public static Settings ReadSettings()
        {
            if (File.Exists(settingsPath))
            {
                string text;
                var fileStream = new FileStream(settingsPath, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd();
                }

                settings = JsonConvert.DeserializeObject<Settings>(text);
            }
            else
            {
                settings = new Settings();
                WriteSettings();
            }
            return settings;
        }

        public static void WriteSettings()
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(settingsPath))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, settings);
                }
            }
        }
    }
}
