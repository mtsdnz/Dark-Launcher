namespace FileListGenerator
{
    partial class FileListGenerator
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
            this.components = new System.ComponentModel.Container();
            this.txtClientFolder = new System.Windows.Forms.TextBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.lblImportantFiles = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importantListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.progressStatus = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.listBoxImportantFiles = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtClientFolder
            // 
            this.txtClientFolder.Location = new System.Drawing.Point(6, 31);
            this.txtClientFolder.Name = "txtClientFolder";
            this.txtClientFolder.ReadOnly = true;
            this.txtClientFolder.Size = new System.Drawing.Size(264, 20);
            this.txtClientFolder.TabIndex = 0;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(277, 29);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(86, 23);
            this.btnSelectFolder.TabIndex = 1;
            this.btnSelectFolder.Text = "Select Folder";
            this.toolTip1.SetToolTip(this.btnSelectFolder, "Select your client folder");
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // lblImportantFiles
            // 
            this.lblImportantFiles.AutoSize = true;
            this.lblImportantFiles.Location = new System.Drawing.Point(3, 66);
            this.lblImportantFiles.Name = "lblImportantFiles";
            this.lblImportantFiles.Size = new System.Drawing.Size(78, 13);
            this.lblImportantFiles.TabIndex = 3;
            this.lblImportantFiles.Text = "Important Files:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileListToolStripMenuItem,
            this.importantListToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(368, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileListToolStripMenuItem
            // 
            this.fileListToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem});
            this.fileListToolStripMenuItem.Name = "fileListToolStripMenuItem";
            this.fileListToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.fileListToolStripMenuItem.Text = "FileList";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Enabled = false;
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.createToolStripMenuItem.Text = "Create";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // importantListToolStripMenuItem
            // 
            this.importantListToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFileToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.discartToolStripMenuItem});
            this.importantListToolStripMenuItem.Name = "importantListToolStripMenuItem";
            this.importantListToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.importantListToolStripMenuItem.Text = "ImportantList";
            // 
            // addFileToolStripMenuItem
            // 
            this.addFileToolStripMenuItem.Enabled = false;
            this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            this.addFileToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.addFileToolStripMenuItem.Text = "Add File";
            this.addFileToolStripMenuItem.Click += new System.EventHandler(this.addFileToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // discartToolStripMenuItem
            // 
            this.discartToolStripMenuItem.Name = "discartToolStripMenuItem";
            this.discartToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.discartToolStripMenuItem.Text = "Discart Changes";
            // 
            // progressStatus
            // 
            this.progressStatus.Location = new System.Drawing.Point(6, 356);
            this.progressStatus.Name = "progressStatus";
            this.progressStatus.Size = new System.Drawing.Size(353, 23);
            this.progressStatus.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(3, 340);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Status:";
            // 
            // listBoxImportantFiles
            // 
            this.listBoxImportantFiles.FormattingEnabled = true;
            this.listBoxImportantFiles.Location = new System.Drawing.Point(6, 82);
            this.listBoxImportantFiles.Name = "listBoxImportantFiles";
            this.listBoxImportantFiles.Size = new System.Drawing.Size(344, 251);
            this.listBoxImportantFiles.TabIndex = 8;
            this.toolTip1.SetToolTip(this.listBoxImportantFiles, "This list contains the files that will be checked with MD5");
            // 
            // FileListGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 391);
            this.Controls.Add(this.listBoxImportantFiles);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressStatus);
            this.Controls.Add(this.lblImportantFiles);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.txtClientFolder);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FileListGenerator";
            this.Text = "FileList Generator";
            this.Load += new System.EventHandler(this.FileListGenerator_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtClientFolder;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Label lblImportantFiles;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importantListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox listBoxImportantFiles;
    }
}

