using Dark_Launcher.Constants;
using System.Diagnostics;

namespace Dark_Launcher.Settings
{
    public class LauncherSettings
    {
        /// <summary>
        /// The current launcher version
        /// </summary>
        public string Version
        {
            get
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                return FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
            }
        }

        /// <summary>
        /// Is outdated version
        /// </summary>
        /// <returns><c>true</c>, if the launcher is outdated, <c>false</c> otherwise.</returns>
        public bool IsOutdatedVersion
        {
           get
            {
#if DEBUG
                Debug.Print("Current version -> " + Version + " FTP LauncherVersion -> " + FTPSettings.LauncherVersion);
#endif
                return Version != FTPSettings.LauncherVersion;
            }
        }

        /// <summary>
        /// Is on maintenance.
        /// </summary>
        /// <returns><c>true</c>, if the launcher is on maintenance, <c>false</c> otherwise.</returns>
        public static bool IsOnMaintenance { get; set; }

    }
}
