using System;
using System.ComponentModel;
using System.Windows.Forms;

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
            this.contextMenu.MenuItems.Add("Exit");
            this.contextMenu.MenuItems[0].Click += new EventHandler(this.ExitProgram);
            //TODO: Add settings option as well, remove json settings file.
            this.notifyIcon.Visible = true;

            this.notifyIcon.BalloonTipTitle = "MCBorderless";
            this.notifyIcon.BalloonTipText = "MCBordlerless has started.";
            this.notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            this.notifyIcon.ShowBalloonTip(3000);
        }

        private void ExitProgram(object sender, EventArgs e) {
            this.notifyIcon.Dispose();
            base.ExitThread();
        }
    }
}