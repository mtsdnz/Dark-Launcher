namespace SettingsManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkListVoice = new System.Windows.Forms.CheckedListBox();
            this.lblVoices = new System.Windows.Forms.Label();
            this.lblGUI = new System.Windows.Forms.Label();
            this.chkListGUI = new System.Windows.Forms.CheckedListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkRepair = new System.Windows.Forms.CheckBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkListText = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // chkListVoice
            // 
            this.chkListVoice.CheckOnClick = true;
            this.chkListVoice.FormattingEnabled = true;
            this.chkListVoice.Items.AddRange(new object[] {
            "English",
            "Português"});
            this.chkListVoice.Location = new System.Drawing.Point(32, 53);
            this.chkListVoice.Name = "chkListVoice";
            this.chkListVoice.Size = new System.Drawing.Size(120, 94);
            this.chkListVoice.TabIndex = 0;
            // 
            // lblVoices
            // 
            this.lblVoices.AutoSize = true;
            this.lblVoices.Location = new System.Drawing.Point(32, 34);
            this.lblVoices.Name = "lblVoices";
            this.lblVoices.Size = new System.Drawing.Size(104, 13);
            this.lblVoices.TabIndex = 1;
            this.lblVoices.Text = "Voices / Dublagens ";
            // 
            // lblGUI
            // 
            this.lblGUI.AutoSize = true;
            this.lblGUI.Location = new System.Drawing.Point(250, 34);
            this.lblGUI.Name = "lblGUI";
            this.lblGUI.Size = new System.Drawing.Size(26, 13);
            this.lblGUI.TabIndex = 3;
            this.lblGUI.Text = "GUI";
            // 
            // chkListGUI
            // 
            this.chkListGUI.FormattingEnabled = true;
            this.chkListGUI.Items.AddRange(new object[] {
            "English",
            "Português"});
            this.chkListGUI.Location = new System.Drawing.Point(211, 53);
            this.chkListGUI.Name = "chkListGUI";
            this.chkListGUI.Size = new System.Drawing.Size(120, 94);
            this.chkListGUI.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(218, 280);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 40);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkRepair
            // 
            this.chkRepair.AutoSize = true;
            this.chkRepair.Location = new System.Drawing.Point(32, 176);
            this.chkRepair.Name = "chkRepair";
            this.chkRepair.Size = new System.Drawing.Size(217, 17);
            this.chkRepair.TabIndex = 6;
            this.chkRepair.Text = "Repair Launcher / Reparação Lançador";
            this.chkRepair.UseVisualStyleBackColor = true;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(180, 253);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(96, 13);
            this.lblVersion.TabIndex = 7;
            this.lblVersion.Text = "Launcher Version: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(390, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Text / Texto";
            // 
            // chkListText
            // 
            this.chkListText.FormattingEnabled = true;
            this.chkListText.Items.AddRange(new object[] {
            "English",
            "Português"});
            this.chkListText.Location = new System.Drawing.Point(390, 53);
            this.chkListText.Name = "chkListText";
            this.chkListText.Size = new System.Drawing.Size(120, 94);
            this.chkListText.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 353);
            this.Controls.Add(this.lblVoices);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkListText);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.chkRepair);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblGUI);
            this.Controls.Add(this.chkListGUI);
            this.Controls.Add(this.chkListVoice);
            this.Name = "Form1";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkListVoice;
        private System.Windows.Forms.Label lblVoices;
        private System.Windows.Forms.Label lblGUI;
        private System.Windows.Forms.CheckedListBox chkListGUI;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkRepair;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox chkListText;
    }
}

