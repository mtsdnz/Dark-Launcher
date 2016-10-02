using Dark_Launcher.Settings;
using Launcher.Management;
using Launcher.SharedConstants;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dark_Launcher.Management
{
    public class LauncherManager
    {
        public void ValidateLauncherVersion()
        {
            try
            {
                if (LauncherData.IsOutdatedVersion)
                {
                    try
                    {
                        if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "LauncherUpdater.exe")))
                        {
                            MessageBox.Show(LanguageManager.GetString(8));
                            LogManager.WriteLog("Could not open the file: LauncherUpdater.exe, because it doesn't exists.");
                            Environment.Exit(0);
                            return;
                        }
                        Process.Start(new ProcessStartInfo("LauncherUpdater.exe", LauncherSharedConstants.UpdaterExecuteParameter)
                        {
                            Verb = "runas"
                        });
                        LogManager.WriteLog("Launcher is outdated! Updating... ", LogManager.LogType.WARN);
                        Environment.Exit(0);
                    }
                    catch (Exception e)
                    {
                        LogManager.WriteLog("Error on open updater: " + e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.WriteLog("Error on validate launcher version: " + e.Message);
            }
        }

        public bool LauncherIsRunning
        {
            get { return (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)).Count() > 1); }
        }
    }
}
