using System;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace MCBorderless {
    static class Program {

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Keybinding.Hook();
            Application.Run(new AppMain());
            Keybinding.UnHook();
        }
    }
}
