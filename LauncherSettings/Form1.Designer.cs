namespace LauncherSettings
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
            this.chkGUI = new System.Windows.Forms.CheckedListBox();
            this.chkText = new System.Windows.Forms.CheckedListBox();
            this.chkAudio = new System.Windows.Forms.CheckedListBox();
            this.lblGUI = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.lblAudio = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkGUI
            // 
            this.chkGUI.CheckOnClick = true;
            this.chkGUI.FormattingEnabled = true;
            this.chkGUI.Items.AddRange(new object[] {
            "English",
            "Português"});
            this.chkGUI.Location = new System.Drawing.Point(46, 101);
            this.chkGUI.Name = "chkGUI";
            this.chkGUI.Size = new System.Drawing.Size(120, 94);
            this.chkGUI.TabIndex = 0;
            this.chkGUI.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkGUI_ItemCheck);
            // 
            // chkText
            // 
            this.chkText.CheckOnClick = true;
            this.chkText.FormattingEnabled = true;
            this.chkText.Items.AddRange(new object[] {
            "English",
            "Português"});
            this.chkText.Location = new System.Drawing.Point(237, 101);
            this.chkText.Name = "chkText";
            this.chkText.Size = new System.Drawing.Size(120, 94);
            this.chkText.TabIndex = 1;
            this.chkText.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkText_ItemCheck);
            // 
            // chkAudio
            // 
            this.chkAudio.CheckOnClick = true;
            this.chkAudio.FormattingEnabled = true;
            this.chkAudio.Items.AddRange(new object[] {
            "English",
            "Português"});
            this.chkAudio.Location = new System.Drawing.Point(428, 101);
            this.chkAudio.Name = "chkAudio";
            this.chkAudio.Size = new System.Drawing.Size(120, 94);
            this.chkAudio.TabIndex = 2;
            this.chkAudio.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkAudio_ItemCheck);
            // 
            // lblGUI
            // 
            this.lblGUI.AutoSize = true;
            this.lblGUI.Location = new System.Drawing.Point(43, 78);
            this.lblGUI.Name = "lblGUI";
            this.lblGUI.Size = new System.Drawing.Size(26, 13);
            this.lblGUI.TabIndex = 3;
            this.lblGUI.Text = "GUI";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(237, 82);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(28, 13);
            this.lblText.TabIndex = 4;
            this.lblText.Text = "Text";
            // 
            // lblAudio
            // 
            this.lblAudio.AutoSize = true;
            this.lblAudio.Location = new System.Drawing.Point(425, 85);
            this.lblAudio.Name = "lblAudio";
            this.lblAudio.Size = new System.Drawing.Size(34, 13);
            this.lblAudio.TabIndex = 5;
            this.lblAudio.Text = "Audio";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(257, 257);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 38);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 332);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblAudio);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblGUI);
            this.Controls.Add(this.chkAudio);
            this.Controls.Add(this.chkText);
            this.Controls.Add(this.chkGUI);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkGUI;
        private System.Windows.Forms.CheckedListBox chkText;
        private System.Windows.Forms.CheckedListBox chkAudio;
        private System.Windows.Forms.Label lblGUI;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblAudio;
        private System.Windows.Forms.Button btnSave;
    }
}

