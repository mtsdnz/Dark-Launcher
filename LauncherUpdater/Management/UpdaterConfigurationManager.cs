using Launcher.Helpers;
using Launcher.Management;
using Launcher.SharedConstants;
using LauncherUpdater.ViewModel;
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
            DownloadManager downloadManager = new DownloadManager();
            downloadManager.DownloadFileAsync(LauncherSharedConstants.InternalConfigFileURL, LauncherSharedConstants.InternalConfigFilePath, onDownloadConfigurationsCompleted);

        }

        private void onDownloadConfigurationsCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (NetworkHelper.ValidateDownloadedFile(e))
            {
                loadInternalConfigurations((string)e.UserState);
                OnConfigurationsLoaded();
            }
            else
            {
                LogManager.WriteLog($"Error on download file configurations on Updater: {e.Error}");
            }
        }

        private void loadInternalConfigurations(string xmlFilePath)
        {
            try
            {
                XMLManager xm = new XMLManager();
                xm.InitializeFromFile(xmlFilePath);
                if (string.IsNullOrEmpty(FTPSharedSettings.LauncherVersion) || string.IsNullOrEmpty(FTPSharedSettings.UpdaterURL))
                {
                    FTPSharedSettings.LauncherVersion = xm.GetNode("internalConfigs/version").InnerText;
                    FTPSharedSettings.UpdaterURL = xm.GetNode("internalConfigs/launcherUpdateLink").InnerText;

                    if (string.IsNullOrEmpty(FTPSharedSettings.LauncherVersion) || string.IsNullOrEmpty(FTPSharedSettings.UpdaterURL))
                    {
                        LogManager.WriteLog($"Launcher version or updaterURL is null or empty. \n Version: {FTPSharedSettings.LauncherVersion} \n UpdaterURL: {FTPSharedSettings.UpdaterURL}");
                    }
                }
            }
            catch (Exception er)
            {
                LogManager.WriteLog("Error on load internal configurations " + er.Message);
            }

        }
    }
}
