using Launcher.Helpers;
using Launcher.Management;
using Launcher.SharedConstants;
using System;
using System.ComponentModel;

namespace LauncherUpdater.Management
{
    internal class UpdaterConfigurationsManager
    {
        public delegate void OnConfigurationsLoadedEventHandler();
        public event OnConfigurationsLoadedEventHandler OnConfigurationsLoaded;

        public UpdaterConfigurationsManager()
        {
            var downloadManager = new DownloadManager();
            downloadManager.DownloadFileAsync(LauncherSharedConstants.InternalConfigFileUrl, LauncherSharedConstants.InternalConfigFilePath, OnDownloadConfigurationsCompleted);

        }

        private void OnDownloadConfigurationsCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (NetworkHelper.ValidateDownloadedFile(e))
            {
                LoadInternalConfigurations((string)e.UserState);
                OnConfigurationsLoaded?.Invoke();
            }
            else
            {
                LogManager.WriteLog($"Error on download file configurations on Updater: {e.Error}");
            }
        }

        private static void LoadInternalConfigurations(string xmlFilePath)
        {
            try
            {
                XmlManager xm = new XmlManager();
                xm.InitializeFromFile(xmlFilePath);
                if (!string.IsNullOrEmpty(FTPSharedSettings.LauncherVersion) &&
                    !string.IsNullOrEmpty(FTPSharedSettings.UpdaterURL)) return;
                FTPSharedSettings.LauncherVersion = xm.GetNode("internalConfigs/version").InnerText;
                FTPSharedSettings.UpdaterURL = xm.GetNode("internalConfigs/launcherUpdateLink").InnerText;

                if (string.IsNullOrEmpty(FTPSharedSettings.LauncherVersion) || string.IsNullOrEmpty(FTPSharedSettings.UpdaterURL))
                {
                    LogManager.WriteLog($"Launcher version or updaterURL is null or empty. \n Version: {FTPSharedSettings.LauncherVersion} \n UpdaterURL: {FTPSharedSettings.UpdaterURL}");
                }
            }
            catch (Exception er)
            {
                LogManager.WriteLog("Error on load internal configurations " + er.Message);
            }

        }
    }
}
