using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCBorderless.src {
    public partial class SettingsForm : Form {

        public SettingsForm() {
            InitializeComponent();

            Config config = Config.loadFromRegistry();
            textBoxContents.Text = String.Join("\n", config.WindowTitleContents);
            textBoxExclusions.Text = String.Join("\n", config.WindowTitleExclusions);
        }

        private void btnSave_Click(object sender, EventArgs e) {
            string[] contents = textBoxContents.Text.Split('\n');
            string[] exclusions = textBoxExclusions.Text.Split('\n');
            Config config = new Config(contents, exclusions);
            config.saveToRegistry();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnDefaults_Click(object sender, EventArgs e) {
            textBoxContents.Text = "Minecraft";
            textBoxExclusions.Text = "Launcher";
        }
    }
}
