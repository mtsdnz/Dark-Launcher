using Launcher.Helpers;
using Launcher.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FileListGenerator
{
    public partial class FileListGenerator : Form
    {

        public FileListGenerator()
        {
            InitializeComponent();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dg = new FolderBrowserDialog();
            if (dg.ShowDialog() != DialogResult.OK) return;

            txtClientFolder.Text = dg.SelectedPath;
            addFileToolStripMenuItem.Enabled = true;
            createToolStripMenuItem.Enabled = true;
        }

        private void addFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog {InitialDirectory = txtClientFolder.Text};

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                listBoxImportantFiles.Items.Add(ofd.FileName.Replace(txtClientFolder.Text + "\\", string.Empty));
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter fs = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "Important.list"));

                foreach (string item in listBoxImportantFiles.Items.Cast<string>())
                {
                    fs.WriteLine(item);
                }
                fs.Close();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog("Error on save important list: " + ex.Message);
            }
        }

        private void FileListGenerator_Load(object sender, EventArgs e)
        {
            LogManager.CreateLog(Environment.CurrentDirectory + "/ErrorLog.log");
            try
            {
                string path = Path.Combine(Environment.CurrentDirectory, "Important.list");
                if (!File.Exists(path)) return;
                string[] flist = File.ReadAllLines(path);
                flist.ToList().ForEach(f => listBoxImportantFiles.Items.Add(f));
            }
            catch (Exception ex)
            {
                LogManager.WriteLog("Error on load: " + ex.Message);
            }
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFileList(txtClientFolder.Text);
        }

        private async void CreateFileList(string pathClient)
        {
            try
            {
                if (!Directory.Exists(pathClient)) return;

                XMLCreatorManager xm = new XMLCreatorManager();
                xm.CreateDocument("Files");
                string[] fileListDir = Directory.GetFiles(pathClient, "*.*", SearchOption.AllDirectories);
                int totalFiles = fileListDir.Length;

                xm.CreateComment($"Total Client Files: {totalFiles}, Created on {DateTime.Now}", xm.Doc.DocumentElement);

                List<string> importantFiles = listBoxImportantFiles.Items.Cast<string>().ToList();//.Select(i => i.Text).ToList();
                for (int i = 0; i < totalFiles; i++)
                {
                    var i1 = i;
                    await Task.Run(() =>
                    {
                        string filePath = fileListDir[i1];
                        string fileClientPath = filePath.Replace(pathClient, string.Empty);

                        FileInfo file = new FileInfo(filePath);

                        if (fileClientPath[0] == Path.DirectorySeparatorChar)
                            fileClientPath = fileClientPath.Substring(1);
                        if (fileClientPath[0] == Path.AltDirectorySeparatorChar)
                            fileClientPath = fileClientPath.Substring(1);

                        XmlElement fileElement = xm.CreateElement("File");
                        fileElement.InnerText = fileClientPath;

                        if (importantFiles.Contains(fileClientPath))
                            xm.CreateAttribute(fileElement, "Verify", true);

                        xm.CreateAttribute(fileElement, "MD5", MD5Helper.GetChecksumBuffered(filePath));

                        xm.CreateAttribute(fileElement, "Size", file.Length.ToString());

                        this.Invoke(new MethodInvoker(delegate
                        {
                            progressStatus.Value = (i1 + 1) * 100 / totalFiles;
                            lblStatus.Text = $"Status: Parsing file {file.Name} ({i1}/{totalFiles}) - ({progressStatus.Value}%)";
                        }));
                    });
                }
                lblStatus.Text = "Status: Completed";
                xm.SaveXml(Path.Combine(Environment.CurrentDirectory, "FileList.xml"));
            } catch (Exception e)
            {
                LogManager.WriteLog("Exception on create file list: " + e.Message);
            }
        }
    }
}
