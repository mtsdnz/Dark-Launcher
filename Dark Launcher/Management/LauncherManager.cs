using Dark_Launcher.Settings;
using Launcher.Management;
using Launcher.SharedConstants;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;

namespace Dark_Launcher.Management
{
    internal sealed class LauncherManager
    {
        internal void ValidateLauncherVersion()
        {
            try
            {
                if (!LauncherSettings.IsOutdatedVersion) return;
                try
                {
                    if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "LauncherUpdater.exe")))
                    {
                        MessageBox.Show(LanguageManager.GetString(8));
                        LogManager.WriteLog("Could not open the file: LauncherUpdater.exe, because it doesn't exists.");
                        Environment.Exit(0);
                    }
                    Process.Start(new ProcessStartInfo("LauncherUpdater.exe", LauncherSharedConstants.UpdaterExecuteParameter)
                    {
                        Verb = "runas"
                    });
                    LogManager.WriteLog("Launcher is outdated! Updating... ", LogManager.LogType.Warn);
                    Environment.Exit(0);
                }
                catch (Exception e)
                {
                    LogManager.WriteLog("Error on open updater: " + e.Message);
                }
            }
            catch (Exception e)
            {
                LogManager.WriteLog("Error on validate launcher version: " + e.Message);
            }
        }

        internal bool LauncherIsRunning => Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)).Length > 1;
    }
}
