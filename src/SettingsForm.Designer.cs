namespace MCBorderless.src {
    partial class SettingsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxContents = new System.Windows.Forms.TextBox();
            this.textBoxExclusions = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDefaults = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Window Title Contents (one entry per line):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Window Title Exclusions (one entry per line):";
            // 
            // textBoxContents
            // 
            this.textBoxContents.AcceptsReturn = true;
            this.textBoxContents.Location = new System.Drawing.Point(12, 27);
            this.textBoxContents.Multiline = true;
            this.textBoxContents.Name = "textBoxContents";
            this.textBoxContents.Size = new System.Drawing.Size(257, 81);
            this.textBoxContents.TabIndex = 3;
            this.textBoxContents.WordWrap = false;
            // 
            // textBoxExclusions
            // 
            this.textBoxExclusions.AcceptsReturn = true;
            this.textBoxExclusions.Location = new System.Drawing.Point(12, 141);
            this.textBoxExclusions.Multiline = true;
            this.textBoxExclusions.Name = "textBoxExclusions";
            this.textBoxExclusions.Size = new System.Drawing.Size(257, 81);
            this.textBoxExclusions.TabIndex = 4;
            this.textBoxExclusions.WordWrap = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 228);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDefaults
            // 
            this.btnDefaults.Location = new System.Drawing.Point(174, 228);
            this.btnDefaults.Name = "btnDefaults";
            this.btnDefaults.Size = new System.Drawing.Size(98, 23);
            this.btnDefaults.TabIndex = 7;
            this.btnDefaults.Text = "Reset to Defaults";
            this.btnDefaults.UseVisualStyleBackColor = true;
            this.btnDefaults.Click += new System.EventHandler(this.btnDefaults_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 263);
            this.Controls.Add(this.btnDefaults);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBoxExclusions);
            this.Controls.Add(this.textBoxContents);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "SettingsForm";
            this.Text = "MCBorderless Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxContents;
        private System.Windows.Forms.TextBox textBoxExclusions;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDefaults;
    }
}