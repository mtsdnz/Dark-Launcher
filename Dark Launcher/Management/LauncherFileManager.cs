using Launcher.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Dark_Launcher.Constants;
using Launcher.ExtensionMethods;
using Launcher.Helpers;

namespace Dark_Launcher.Management
{
    internal sealed class LauncherFileManager
    {
        internal delegate void OnDownloadFileListCompleteDelegate();
        internal OnDownloadFileListCompleteDelegate OnDownloadFileListCompleteCallback;

        internal delegate void OnBadFilesLoadCompleteDelegate(List<BadFile> badFiles);

        internal OnBadFilesLoadCompleteDelegate OnBadFilesLoadCompleteCallback;

        internal struct FileListItem
        {
            public string Path { get; set; }
            public long Size { get; set; }
            public bool VerifyMD5 { get; set; }
            public string MD5 { get; set; }
            public string FullPath => Environment.CurrentDirectory + "/" + Path;
        }

        internal struct BadFile
        {
            public string Path { get; set; }
            public string FullPath => Environment.CurrentDirectory + "/" + Path;
        }

        internal List<FileListItem> ListFiles { get; private set; }
        internal List<BadFile> ListBadFiles;

        internal void LoadBadListFiles(string filePath)
        {
            ListBadFiles = new List<BadFile>();
            using (var xm = new XmlManager())
            {
                xm.InitializeFromFile(filePath);
                XmlNodeList badFilesNodes = xm.GetNodes("Files/File");
                foreach (XmlNode badFilesNode in badFilesNodes)
                {
                    ListBadFiles.Add(new BadFile
                    {
                        Path = badFilesNode.InnerText
                    });
                }
            }

            OnBadFilesLoadCompleteCallback?.Invoke(ListBadFiles);
#if DEBUG
            Debug.Print(ListBadFiles.Count + " Bad files loaded");
#endif
        }

        internal static void DeleteBadFiles(List<BadFile> listBadFiles )
        {
            foreach (BadFile badFile in listBadFiles)
            {
                if (string.IsNullOrEmpty(badFile.Path)) continue;
                var fullPath = badFile.FullPath;
                if (File.Exists(fullPath))
                    File.Delete(fullPath);
                Debug.Print("file deleted-> " + badFile.FullPath);
            }
        }

        internal void LoadFileList(string filePath)
        {
            ListFiles = new List<FileListItem>();
            using (var xm = new XmlManager())
            {
                xm.InitializeFromFile(filePath);
                XmlNodeList filesNodes = xm.GetNodes("Files/File");

                foreach (XmlNode fileNode in filesNodes)
                {
                    var fileItem = new FileListItem
                    {
                        Path = fileNode.InnerText,
                        Size = fileNode.ParseIntAttribute("Size")
                    };
                    if (fileNode.HasAttribute("Verify"))
                    {
                        fileItem.VerifyMD5 = true;
                        fileItem.MD5 = fileNode.ParseStringAttribute("MD5");
                    }

                    ListFiles.Add(fileItem);
                }
            }

#if DEBUG
            Debug.Print("{0} Files Loaded from FileList.xml!", ListFiles.Count);
#endif
        }

        internal void DownloadFileList()
        {
            try
            {
                var dm = new DownloadManager();
                dm.DownloadFileAsync(FtpSettings.FileListUrl, Environment.CurrentDirectory + "/FileList.xml",
                    OnFileListDownloadCompleteCallback);
            }
            catch (Exception er)
            {
#if  DEBUG
                Debug.Print("Error on download FileList.xml -> " + er.Message);
#endif
                LogManager.WriteLog("Error on download FileList.xml");
                throw new DataException("FileList");
            }
        }

        internal void DownloadBlackList()
        {
            try
            {
                if (string.IsNullOrEmpty(FtpSettings.BlackListUrl))
                    return;
                var dm = new DownloadManager();
                //TODO: Mover para a pasta temporaria
                dm.DownloadFileAsync(FtpSettings.BlackListUrl, Environment.CurrentDirectory + "/BlackList.xml", OnBlackListDownloadCompleteCallback);
#if DEBUG
                Debug.Print("Downloading black list Url..");
#endif
            }
            catch (Exception er)
            {
                LogManager.WriteLog("Exception on download blackList: " + er.Message);
            }
        }

        internal void OnBlackListDownloadCompleteCallback(object sender, AsyncCompletedEventArgs eventArgs)
        {
            if (NetworkHelper.ValidateDownloadedFile(eventArgs))
                LoadBadListFiles((string) eventArgs.UserState);
            else
            {
                LogManager.WriteLog("Error on download blacklist: " + eventArgs.Error + " IsCanceled -> " + eventArgs.Cancelled);
            }
        }

        internal void OnFileListDownloadCompleteCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (NetworkHelper.ValidateDownloadedFile(e))
            {
                LoadFileList((string)e.UserState);
                OnDownloadFileListCompleteCallback?.Invoke();
            }
            else
            {
#if DEBUG
                Debug.Print("Error on download fileList");
#endif
                LogManager.WriteLog("Error on download FileList.xml. Please, check your connection and try again.");
            }

        }

        
        public List<FileListItem> FilesToUpdateList
        {
            get
            {
                var list = new List<FileListItem>();
                if (ListFiles == null)
                    return list;

                list.AddRange(ListFiles.Where(fileListItem => NeedDownloadFile(fileListItem)));
                return list;
            }
        }

        public bool NeedDownloadFile(FileListItem file, bool isOnRepair = false)
        {
            string filePath = file.FullPath;
            if (!File.Exists(filePath) || file.Size != new FileInfo(filePath).Length)
                return true;

            if (!file.VerifyMD5 && !isOnRepair) return false;

            return file.MD5 != MD5Helper.GetChecksumBuffered(filePath);
        }
    }
}
