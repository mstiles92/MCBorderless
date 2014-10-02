using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace MCBorderless {
    class Config {
        public string[] WindowTitleContents { get; private set; }
        public string[] WindowTitleExclusions { get; private set; }

        public Config(string[] windowTitleContents, string[] windowTitleExclusions) {
            this.WindowTitleContents = windowTitleContents;
            this.WindowTitleExclusions = windowTitleExclusions;
        }

        public static Config loadFromJson(string filename) {
            if (!File.Exists(filename)) {
                string[] windowTitleContents = new string[] { "Minecraft" };
                string[] windowTitleExclusions = new string[] { "Launcher" };
                Config Config = new Config(windowTitleContents, windowTitleExclusions);
                string json = JsonConvert.SerializeObject(Config);
                StreamWriter writer = new StreamWriter(File.OpenWrite(filename));
                writer.Write(json);
                writer.Close();
                return Config;
            } else {
                StreamReader reader = new StreamReader(File.OpenRead(filename));
                string json = reader.ReadToEnd();
                reader.Close();
                return JsonConvert.DeserializeObject<Config>(json);
            }
        }

        public static Config loadFromRegistry() {
            Microsoft.Win32.RegistryKey registry = Application.UserAppDataRegistry;

            string[] windowTitleContents = (string[]) registry.GetValue("WindowTitleContents", "Minecraft");
            string[] windowTitleExclusions = (string[]) registry.GetValue("WindowTitleExclusions", "Launcher");

            return new Config(windowTitleContents, windowTitleExclusions);
        }

        public void saveToRegistry() {
            Microsoft.Win32.RegistryKey registry = Application.UserAppDataRegistry;

            registry.SetValue("WindowTitleContents", WindowTitleContents);
            registry.SetValue("WindowTitleExclusions", WindowTitleExclusions);

            registry.Flush();
        }
    }
}
