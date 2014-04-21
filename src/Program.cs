using System;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace MCBorderless {
    static class Program {

        internal static Assembly AssemblyResolveHandler(object sender, ResolveEventArgs args) {
            if (args.Name.Contains("Newtonsoft") && args.Name.Contains("Json") && !args.Name.EndsWith("_resources")) {
                ResourceManager rm = new ResourceManager("MCBorderless.Properties.Resources", Assembly.GetExecutingAssembly());
                byte[] bytes = (byte[]) rm.GetObject("Newtonsoft_Json");
                return Assembly.Load(bytes);
            } else {
                return null;
            }
        }

        [STAThread]
        static void Main() {
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolveHandler;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Keybinding.Hook();
            Application.Run(new AppMain());
            Keybinding.UnHook();
        }
    }
}
