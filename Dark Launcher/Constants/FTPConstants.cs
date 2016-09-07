using System;

namespace Dark_Launcher.Constants
{
    internal sealed class FTPSettings
    {
        /// <summary>
        /// The url of the file "LauncherInternalConfig.xml"
        /// </summary>
        public const string InternalConfigFileURL = "http://10.211.55.3/launcher/LauncherInternalConfig.xml";

        //the configurations below are loaded from LauncherConfig.xml
        public static string FileListURL;
        public static string UpdaterURL;
        public static string ClientMirrorURL;
        public static string ForumURL;
        public static string XMLNewsURL;

        public static string LauncherVersion;

    }
}
