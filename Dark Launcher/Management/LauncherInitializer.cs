using Dark_Launcher.Constants;
using Launcher.Management;
using System;
using System.Collections.Generic;
using System.Windows;
using Dark_Launcher.Settings;

namespace Dark_Launcher.Management
{
    internal sealed class LauncherInitializer
    {
        private readonly LauncherManager _launcherManager;

        internal delegate void OnLauncherInitializerDelegate();

        internal OnLauncherInitializerDelegate OnLauncherInitializerCallback;

        internal LauncherInitializer()
        {
            _launcherManager = new LauncherManager();
        }

        internal void InitializerLauncher()
        {
            try
            {
                LoadLanguage();

                if (_launcherManager.LauncherIsRunning)
                {
                    MessageBox.Show(LanguageManager.GetString(7), "Launcher already running!", MessageBoxButton.OK, MessageBoxImage.Stop);
                    Environment.Exit(0);
                }

                var configs = new LauncherConfigurationsManager();
                configs.LoadInternalConfigs();
                configs.OnConfigurationsLoaded += OnLoadConfigurationsComplete;

            }
            catch (Exception e)
            {
                LogManager.WriteLog("Error on initializer Launcher: " + e.Message);
            }
        }

        private void OnLoadConfigurationsComplete()
        {
            _launcherManager.ValidateLauncherVersion();

            LauncherFileManager launcherFileManager = new LauncherFileManager();
            launcherFileManager.DownloadBlackList();
            launcherFileManager.OnBadFilesLoadCompleteCallback += OnBadFilesDownloadCompleteCallback;

            OnLauncherInitializerCallback?.Invoke();
        }

        private static void OnBadFilesDownloadCompleteCallback(List<LauncherFileManager.BadFile> listBadFiles)
        {
            LauncherFileManager.DeleteBadFiles(listBadFiles);
        }

        private static void LoadLanguage()
        {
            var languageManager = new LanguageManager();
            languageManager.LoadLanguages();
           // if (LauncherSettings.HasDefaultLanguage)
                languageManager.LoadLanguageStrings(1);
            //else
            //{
                //TODO: Colocar para o usuario selecionar a lingua
           // }
        }
    }
}
