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
    internal class LauncherConfigurationsManager
    {
        public delegate void OnConfigurationsLoad();
        public event OnConfigurationsLoad OnConfigurationsLoaded; 

        public void LoadInternalConfigs()
        {
            DownloadManager dm = new DownloadManager();
            //TODO: Change to TEMP folder!
            //Path.TempFolder()
            var filePath = Path.Combine(Environment.CurrentDirectory, "LauncherInternalConfig.xml");
            dm.DownloadFileAsync(LauncherSharedConstants.InternalConfigFileURL, LauncherSharedConstants.InternalConfigFilePath, onDownloadInternalConfigFileCompleted);
            
        }

        private void onDownloadInternalConfigFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (NetworkHelper.ValidateDownloadedFile(e))
            {
                //TODO: Remove this on final version
#if DEBUG
                Debug.Print("filepath(user state) -> " + (string)e.UserState);
#endif
                LoadInternalConfigsXml((string)e.UserState);
            }
            else
            {
#if DEBUG
                Debug.Print("error on download file!");
#endif
            }
        }

        public void LoadInternalConfigsXml(string xmlFilePath)
        {
            try
            {
                XMLManager xmlManager = new XMLManager();
                xmlManager.InitializeFromFile(xmlFilePath);
                
                XmlNode internalConfigsNode = xmlManager.GetNode("internalConfigs");
                FTPSharedSettings.LauncherVersion = internalConfigsNode.SelectSingleNode("version").InnerText;
                FTPSharedSettings.UpdaterURL = internalConfigsNode.SelectSingleNode("launcherUpdateLink").InnerText;
                FTPSettings.ClientMirrorURL = internalConfigsNode.SelectSingleNode("clientMirror").InnerText;
                FTPSettings.FileListURL = internalConfigsNode.SelectSingleNode("fileListURL").InnerText;
                

                XmlNode newsNode = internalConfigsNode.SelectSingleNode("news");
                FTPSettings.ForumURL = newsNode.SelectSingleNode("forumURL").InnerText;
                FTPSettings.XMLNewsURL = newsNode.SelectSingleNode("xmlNewsUrl").InnerText;


                LauncherData.IsOnMaintenance = bool.Parse(internalConfigsNode.SelectSingleNode("maintenance").InnerText);

                if (!HasLoadedAllInternalConfigs(FTPSharedSettings.LauncherVersion, FTPSharedSettings.UpdaterURL, FTPSettings.ClientMirrorURL, FTPSettings.FileListURL, FTPSettings.ForumURL, FTPSettings.XMLNewsURL))
                {
                    LogManager.WriteLog("Not all internal configs was loaded correctly.");
                }
                OnConfigurationsLoaded();

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

        private bool HasLoadedAllInternalConfigs(params string[] strs)
        {
            foreach (string str in strs)
            {
                if (str == string.Empty || str == null)
                {
                    LogManager.WriteLog($"Internal config {str} is empty or null. ", LogManager.LogType.WARN);
                    return false;
                }
            }
            return true;
        }
    }
}
