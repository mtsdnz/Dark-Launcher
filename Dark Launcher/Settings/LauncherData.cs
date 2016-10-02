using Launcher.SharedConstants;
using System.Diagnostics;

namespace Dark_Launcher.Settings
{
    public static class LauncherData
    {
        /// <summary>
        /// The current launcher version
        /// </summary>
        public static string CurrentVersion
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
        public static bool IsOutdatedVersion
        {
           get
            {
#if DEBUG
                Debug.Print("Current version -> " + CurrentVersion + " FTP LauncherVersion -> " + FTPSharedSettings.LauncherVersion);
#endif
                return CurrentVersion != FTPSharedSettings.LauncherVersion;
            }
        }

        /// <summary>
        /// Is on maintenance.
        /// </summary>
        /// <returns><c>true</c>, if the launcher is on maintenance, <c>false</c> otherwise.</returns>
        public static bool IsOnMaintenance { get; set; }

    }
}
