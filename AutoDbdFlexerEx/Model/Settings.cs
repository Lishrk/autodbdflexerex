using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace AutoDbdFlexerEx.Model
{
    public static class Settings
    {
        private static string SavePath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AutoDbdFlexerEx", "Settings.json");
            }
        }
        public static JObject Data { get; private set; }

        static Settings()
        {
            try
            {
                if (!File.Exists(SavePath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(SavePath));
                    File.WriteAllText(SavePath, "{}");
                }
                Data = JObject.Parse(File.ReadAllText(SavePath));
            }
            catch
            {
                Data = new JObject();
            }
        }
        public static void Save()
        {
            File.WriteAllText(SavePath, Data.ToString());
        }
    }
}
