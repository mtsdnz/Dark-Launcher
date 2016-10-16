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
            this.lblGUI = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.lblAudio = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlGUI = new System.Windows.Forms.Panel();
            this.btnPortugueseGUI = new System.Windows.Forms.RadioButton();
            this.btnEnglishGUI = new System.Windows.Forms.RadioButton();
            this.pnlText = new System.Windows.Forms.Panel();
            this.btnPortugueseText = new System.Windows.Forms.RadioButton();
            this.btnEnglishText = new System.Windows.Forms.RadioButton();
            this.pnlAudio = new System.Windows.Forms.Panel();
            this.btnPortugueseAudio = new System.Windows.Forms.RadioButton();
            this.btnEnglishAudio = new System.Windows.Forms.RadioButton();
            this.chkClient = new System.Windows.Forms.CheckBox();
            this.pnlGUI.SuspendLayout();
            this.pnlText.SuspendLayout();
            this.pnlAudio.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGUI
            // 
            this.lblGUI.AutoSize = true;
            this.lblGUI.Location = new System.Drawing.Point(46, 82);
            this.lblGUI.Name = "lblGUI";
            this.lblGUI.Size = new System.Drawing.Size(26, 13);
            this.lblGUI.TabIndex = 3;
            this.lblGUI.Text = "GUI";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(243, 82);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(28, 13);
            this.lblText.TabIndex = 4;
            this.lblText.Text = "Text";
            // 
            // lblAudio
            // 
            this.lblAudio.AutoSize = true;
            this.lblAudio.Location = new System.Drawing.Point(433, 82);
            this.lblAudio.Name = "lblAudio";
            this.lblAudio.Size = new System.Drawing.Size(34, 13);
            this.lblAudio.TabIndex = 5;
            this.lblAudio.Text = "Audio";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(257, 309);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 38);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlGUI
            // 
            this.pnlGUI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGUI.Controls.Add(this.btnPortugueseGUI);
            this.pnlGUI.Controls.Add(this.btnEnglishGUI);
            this.pnlGUI.Location = new System.Drawing.Point(36, 101);
            this.pnlGUI.Name = "pnlGUI";
            this.pnlGUI.Size = new System.Drawing.Size(144, 94);
            this.pnlGUI.TabIndex = 7;
            // 
            // btnPortugueseGUI
            // 
            this.btnPortugueseGUI.AutoSize = true;
            this.btnPortugueseGUI.Location = new System.Drawing.Point(12, 12);
            this.btnPortugueseGUI.Name = "btnPortugueseGUI";
            this.btnPortugueseGUI.Size = new System.Drawing.Size(73, 17);
            this.btnPortugueseGUI.TabIndex = 1;
            this.btnPortugueseGUI.TabStop = true;
            this.btnPortugueseGUI.Text = "Português";
            this.btnPortugueseGUI.UseVisualStyleBackColor = true;
            // 
            // btnEnglishGUI
            // 
            this.btnEnglishGUI.AutoSize = true;
            this.btnEnglishGUI.Location = new System.Drawing.Point(12, 47);
            this.btnEnglishGUI.Name = "btnEnglishGUI";
            this.btnEnglishGUI.Size = new System.Drawing.Size(59, 17);
            this.btnEnglishGUI.TabIndex = 0;
            this.btnEnglishGUI.TabStop = true;
            this.btnEnglishGUI.Text = "English";
            this.btnEnglishGUI.UseVisualStyleBackColor = true;
            // 
            // pnlText
            // 
            this.pnlText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlText.Controls.Add(this.btnPortugueseText);
            this.pnlText.Controls.Add(this.btnEnglishText);
            this.pnlText.Location = new System.Drawing.Point(230, 101);
            this.pnlText.Name = "pnlText";
            this.pnlText.Size = new System.Drawing.Size(144, 94);
            this.pnlText.TabIndex = 8;
            // 
            // btnPortugueseText
            // 
            this.btnPortugueseText.AutoSize = true;
            this.btnPortugueseText.Location = new System.Drawing.Point(15, 12);
            this.btnPortugueseText.Name = "btnPortugueseText";
            this.btnPortugueseText.Size = new System.Drawing.Size(73, 17);
            this.btnPortugueseText.TabIndex = 1;
            this.btnPortugueseText.TabStop = true;
            this.btnPortugueseText.Text = "Português";
            this.btnPortugueseText.UseVisualStyleBackColor = true;
            // 
            // btnEnglishText
            // 
            this.btnEnglishText.AutoSize = true;
            this.btnEnglishText.Location = new System.Drawing.Point(15, 47);
            this.btnEnglishText.Name = "btnEnglishText";
            this.btnEnglishText.Size = new System.Drawing.Size(59, 17);
            this.btnEnglishText.TabIndex = 0;
            this.btnEnglishText.TabStop = true;
            this.btnEnglishText.Text = "English";
            this.btnEnglishText.UseVisualStyleBackColor = true;
            // 
            // pnlAudio
            // 
            this.pnlAudio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAudio.Controls.Add(this.btnPortugueseAudio);
            this.pnlAudio.Controls.Add(this.btnEnglishAudio);
            this.pnlAudio.Location = new System.Drawing.Point(418, 101);
            this.pnlAudio.Name = "pnlAudio";
            this.pnlAudio.Size = new System.Drawing.Size(144, 94);
            this.pnlAudio.TabIndex = 9;
            // 
            // btnPortugueseAudio
            // 
            this.btnPortugueseAudio.AutoSize = true;
            this.btnPortugueseAudio.Location = new System.Drawing.Point(17, 12);
            this.btnPortugueseAudio.Name = "btnPortugueseAudio";
            this.btnPortugueseAudio.Size = new System.Drawing.Size(73, 17);
            this.btnPortugueseAudio.TabIndex = 1;
            this.btnPortugueseAudio.TabStop = true;
            this.btnPortugueseAudio.Text = "Português";
            this.btnPortugueseAudio.UseVisualStyleBackColor = true;
            // 
            // btnEnglishAudio
            // 
            this.btnEnglishAudio.AutoSize = true;
            this.btnEnglishAudio.Location = new System.Drawing.Point(17, 47);
            this.btnEnglishAudio.Name = "btnEnglishAudio";
            this.btnEnglishAudio.Size = new System.Drawing.Size(59, 17);
            this.btnEnglishAudio.TabIndex = 0;
            this.btnEnglishAudio.TabStop = true;
            this.btnEnglishAudio.Text = "English";
            this.btnEnglishAudio.UseVisualStyleBackColor = true;
            // 
            // chkClient
            // 
            this.chkClient.AutoSize = true;
            this.chkClient.Location = new System.Drawing.Point(36, 244);
            this.chkClient.Name = "chkClient";
            this.chkClient.Size = new System.Drawing.Size(138, 17);
            this.chkClient.TabIndex = 11;
            this.chkClient.Text = "Launch client in English";
            this.chkClient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkClient.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 378);
            this.Controls.Add(this.chkClient);
            this.Controls.Add(this.pnlAudio);
            this.Controls.Add(this.pnlText);
            this.Controls.Add(this.pnlGUI);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblAudio);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblGUI);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlGUI.ResumeLayout(false);
            this.pnlGUI.PerformLayout();
            this.pnlText.ResumeLayout(false);
            this.pnlText.PerformLayout();
            this.pnlAudio.ResumeLayout(false);
            this.pnlAudio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblGUI;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblAudio;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlGUI;
        private System.Windows.Forms.RadioButton btnPortugueseGUI;
        private System.Windows.Forms.RadioButton btnEnglishGUI;
        private System.Windows.Forms.Panel pnlText;
        private System.Windows.Forms.RadioButton btnPortugueseText;
        private System.Windows.Forms.RadioButton btnEnglishText;
        private System.Windows.Forms.Panel pnlAudio;
        private System.Windows.Forms.RadioButton btnPortugueseAudio;
        private System.Windows.Forms.RadioButton btnEnglishAudio;
        private System.Windows.Forms.CheckBox chkClient;
    }
}

