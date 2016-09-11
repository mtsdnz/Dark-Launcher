using Launcher.Helpers;
using Launcher.Management;
using Launcher.SharedConstants;
using LauncherUpdater.Base;
using LauncherUpdater.Management;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace LauncherUpdater.ViewModel
{
    public sealed class MainViewModel : ViewModelBase
    {
        public Dispatcher UIDispatcher;
        private int _downloadsAttempts = 0;
        private double _updaterProgressBar;
        public double UpdaterProgressBar
        {
            get { return _updaterProgressBar; }
            set { SetAndNotify(ref _updaterProgressBar, value); }
        }

        public MainViewModel()
        {
            bool isRightParameter = (Environment.GetCommandLineArgs().Length > 1 && Environment.GetCommandLineArgs()[1] == LauncherSharedConstants.UpdaterExecuteParameter);
            if (!isRightParameter)
            {
                if(File.Exists(Path.Combine(Environment.CurrentDirectory, LauncherSharedConstants.ExecutableName)))
                    Process.Start(LauncherSharedConstants.ExecutableName);
                Environment.Exit(1);
            }
        }
        public void OnWindowLoaded(object ob, RoutedEventArgs e)
        {
            UpdaterConfigurationsManager updatermng = new UpdaterConfigurationsManager();
            updatermng.OnConfigurationsLoaded += new UpdaterConfigurationsManager.OnConfigurationsLoadedEventHandler(UpdateLauncher);
        }

        private void UpdateLauncher()
        {
            try
            {
                _downloadsAttempts++;
                DownloadManager dm = new DownloadManager();
                dm.DownloadFileAsync(FTPSharedSettings.UpdaterURL,
                    Path.Combine(Environment.CurrentDirectory, LauncherSharedConstants.ExecutableName),
                    OnDownloadFinishedCallback, (s, e) =>
                    {
                        UpdaterProgressBar = e.ProgressPercentage;
                    });
            }
            catch (Exception er)
            {
                LogManager.WriteLog("[UPDATER]" + er.Message);
            }
        }

        private void OnDownloadFinishedCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (NetworkHelper.ValidateDownloadedFile(e))
            {
                Process.Start(LauncherSharedConstants.ExecutableName);
                Environment.Exit(1);
            }
            else
            {
                LogManager.WriteLog("[UPDATER] Error on update launcher: " + e.Error.Message);

                if(_downloadsAttempts <= LauncherSharedConstants.MaxDownloadErrosAttempts)
                    UpdateLauncher(); //try again
                else
                {
                    MessageBox.Show("Error on update the launcher. You will be redirected to the download page, to download the Launcher manually.");
                    Process.Start(FTPSharedSettings.UpdaterURL);    
                }
            }
        }
    }
}
