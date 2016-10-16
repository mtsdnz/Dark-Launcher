using Launcher.SharedConstants;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Dark_Launcher.Settings
{
    internal static class LauncherSettings
    {
        /// <summary>
        /// The current launcher version
        /// </summary>
        internal static string CurrentVersion
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
        internal static bool IsOutdatedVersion
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
        internal static bool IsOnMaintenance { get; set; }

        /// <summary>
        /// Show speed when download a file?
        /// </summary>
        internal static bool ShowSpeed { get; set; }

        /// <summary>
        /// Show the news?
        /// </summary>
        internal static bool ShowNews { get; set; }

        internal static bool HasDefaultLanguage { get; set; }

        internal static int DefaultLanguageId { get; set; }
    }
}
