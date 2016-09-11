using Launcher.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Launcher.Management
{
    public class LauncherFileManager
    {
        private struct FileListItem
        {
            public int Size { get; set; }
            public string MD5 { get; set; }
            public bool Verify { get; set; }
        }
        private List<FileListItem> ListFiles;
        public void LoadFileList(string xml)
        {
            ListFiles = new List<FileListItem>();
            XMLManager xm = new XMLManager();
            xm.InitializeFromString(xml);

        
        }
    }
}
