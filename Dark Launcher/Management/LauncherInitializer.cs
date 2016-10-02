using Dark_Launcher.Constants;
using Dark_Launcher.Settings;
using LauncherSettings;
using Launcher.Management;
using Launcher.SharedConstants;
using System;
using System.Diagnostics;
using System.Windows;
using LauncherSettings.Base;

namespace Dark_Launcher.Management
{
    internal class LauncherInitializer
    {
        LauncherManager launcherManager;
        SettingsManager settingsManager;

        public LauncherInitializer()
        {
            try
            {
                settingsManager = new SettingsManager();
                settingsManager.LoadSettings();

                launcherManager = new LauncherManager();
                loadLanguage();

                if (launcherManager.LauncherIsRunning)
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
            launcherManager.ValidateLauncherVersion();
        }

        private void loadLanguage()
        {
            LanguageManager languageManager = new LanguageManager();
            languageManager.LoadLanguages();
            languageManager.LoadLanguageStrings(LauncherConstants.DefaultLanguageID);
        }
    }
}
