using Newtonsoft.Json;
using System.IO;

namespace MCBorderless {
    class Config {
        public string LauncherFilename { get; private set; }
        public string[] WindowTitleContents { get; private set; }
        public string[] WindowTitleExclusions { get; private set; }

        public Config(string launcherFilename, string[] windowTitleContents, string[] windowTitleExclusions) {
            this.LauncherFilename = launcherFilename;
            this.WindowTitleContents = windowTitleContents;
            this.WindowTitleExclusions = windowTitleExclusions;
        }

        public static Config loadFromJson(string filename) {
            if (!File.Exists(filename)) {
                string launcherFilename = "Minecraft.exe";
                string[] windowTitleContents = new string[] { "Minecraft" };
                string[] windowTitleExclusions = new string[] { "Launcher" };
                Config Config = new Config(launcherFilename, windowTitleContents, windowTitleExclusions);
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
    }
}
