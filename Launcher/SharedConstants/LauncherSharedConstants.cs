using System;
using System.IO;

namespace Launcher.SharedConstants
{
    public sealed class LauncherSharedConstants
    {
        /// <summary>
        /// The url of the file "LauncherInternalConfig.xml"
        /// </summary>
        public const string InternalConfigFileURL = "http://10.211.55.3/launcher/LauncherInternalConfig.xml";
        /// <summary>
        /// Max download erros attemps
        /// </summary>
        public const int MaxDownloadErrosAttempts = 5;
        /// <summary>
        /// The name of the Executable(Ex: Launcher.exe)
        /// </summary>
        public const string ExecutableName = "Dark Launcher";


        public const string UpdaterExecuteParameter = "test_open";

        /// <summary>
        /// Internal config file path
        /// </summary>
        public static readonly string InternalConfigFilePath = Path.Combine(Environment.CurrentDirectory, "LauncherInternalConfig.xml");

        #region Launcher Cryptography
        public const int AESKeySize = 256;
        /// <summary>
        /// The AES key that your LauncherInternalConfig.xml will be encrypted
        /// </summary>
        public const string AESKey = "darkherotest";
        #endregion

    }
}
