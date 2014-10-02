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

        public static Config loadFromRegistry() {
            Microsoft.Win32.RegistryKey registry = Application.UserAppDataRegistry;

            string[] windowTitleContents = (string[]) registry.GetValue("WindowTitleContents", new string[] {"Minecraft"});
            string[] windowTitleExclusions = (string[]) registry.GetValue("WindowTitleExclusions", new string[] {"Launcher"});

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
