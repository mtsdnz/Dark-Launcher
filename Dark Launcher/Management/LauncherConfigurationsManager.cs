using System;
using Dark_Launcher.Constants;
using System.Xml;
using Dark_Launcher.Settings;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;
using Launcher.SharedConstants;
using Launcher.Management;
using Launcher.Helpers;

namespace Dark_Launcher.Management
{
    internal sealed class LauncherConfigurationsManager
    {
        public delegate void OnConfigurationsLoad();
        public event OnConfigurationsLoad OnConfigurationsLoaded; 

        public void LoadInternalConfigs()
        {
            DownloadManager dm = new DownloadManager();
            dm.DownloadFileAsync(LauncherSharedConstants.InternalConfigFileUrl, LauncherSharedConstants.InternalConfigFilePath, OnDownloadInternalConfigFileCompleted);
            
        }

        private void OnDownloadInternalConfigFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (NetworkHelper.ValidateDownloadedFile(e))
                LoadInternalConfigsFromXml((string)e.UserState);
            else
                LogManager.WriteLog("Error on download internal config file: " + e.Error);
        }

        internal void LoadInternalConfigsFromXml(string xmlFilePath)
        {
            try
            {
                XmlManager xmlManager = new XmlManager();
                xmlManager.InitializeFromFile(xmlFilePath);
                
                XmlNode internalConfigsNode = xmlManager.GetNode("internalConfigs");
                FTPSharedSettings.LauncherVersion = internalConfigsNode.SelectSingleNode("version")?.InnerText;
                FTPSharedSettings.UpdaterURL = internalConfigsNode.SelectSingleNode("launcherUpdateLink")?.InnerText;
                FtpSettings.ClientMirrorUrl = internalConfigsNode.SelectSingleNode("clientMirror")?.InnerText;
                FtpSettings.FileListUrl = internalConfigsNode.SelectSingleNode("fileListURL")?.InnerText;
                FtpSettings.BlackListUrl = internalConfigsNode.SelectSingleNode("blackListURL").InnerText;
                
                XmlNode newsNode = internalConfigsNode.SelectSingleNode("news");
                FtpSettings.ForumUrl = newsNode.SelectSingleNode("forumURL").InnerText;
                FtpSettings.XmlNewsUrl = newsNode.SelectSingleNode("xmlNewsUrl")?.InnerText;
                //optional!
                

                LauncherSettings.ShowNews = bool.Parse(newsNode.SelectSingleNode("showNews").InnerText);

                LauncherSettings.IsOnMaintenance = bool.Parse(internalConfigsNode.SelectSingleNode("maintenance").InnerText);

                if (!HasLoadedAllInternalConfigs(FTPSharedSettings.LauncherVersion, FTPSharedSettings.UpdaterURL, FtpSettings.ClientMirrorUrl, FtpSettings.FileListUrl, FtpSettings.ForumUrl, FtpSettings.XmlNewsUrl))
                {
                    LogManager.WriteLog("Not all internal configs was loaded correctly.");
                }
                OnConfigurationsLoaded?.Invoke();

#if DEBUG
                Debug.Print("Internal configs loaded sucessfully");
#endif
            }
            catch (Exception er)
            {
#if DEBUG
                Debug.Print(er.Message);
#endif
                LogManager.WriteLog("Error on load internal configs: " + er.Message);
            }

        }

        private static bool HasLoadedAllInternalConfigs(params string[] strs)
        {
            foreach (var str in strs)
            {
                if (!string.IsNullOrEmpty(str)) continue;
                LogManager.WriteLog($"Internal config {str} is empty or null. ", LogManager.LogType.Warn);
                return false;
            }
            return true;
        }
    }
}
