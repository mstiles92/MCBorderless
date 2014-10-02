using System;
using System.ComponentModel;
using System.Windows.Forms;
using MCBorderless.src;

namespace MCBorderless {
    internal class AppMain : ApplicationContext {
        private NotifyIcon notifyIcon;
        private ContextMenu contextMenu;

        public AppMain() {
            this.notifyIcon = new NotifyIcon(new Container());
            this.contextMenu = new ContextMenu();
            this.notifyIcon.ContextMenu = this.contextMenu;
            this.notifyIcon.Icon = MCBorderless.Properties.Resources.minecraft;
            this.notifyIcon.Text = "MCBorderless";
            this.contextMenu.MenuItems.Add("Config");
            this.contextMenu.MenuItems[0].Click += new EventHandler(this.OpenSettings);
            this.contextMenu.MenuItems.Add("Exit");
            this.contextMenu.MenuItems[1].Click += new EventHandler(this.ExitProgram);
            this.notifyIcon.Visible = true;

            this.notifyIcon.BalloonTipTitle = "MCBorderless";
            this.notifyIcon.BalloonTipText = "MCBordlerless has started.";
            this.notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            this.notifyIcon.ShowBalloonTip(3000);
        }

        private void OpenSettings(object sender, EventArgs e) {
            SettingsForm form = new SettingsForm();
            form.Show();
        }

        private void ExitProgram(object sender, EventArgs e) {
            this.notifyIcon.Dispose();
            base.ExitThread();
        }
    }
}