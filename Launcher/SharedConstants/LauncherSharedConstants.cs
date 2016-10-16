using System;
using System.IO;

namespace Launcher.SharedConstants
{
    public sealed class LauncherSharedConstants
    {
        /// <summary>
        /// The url of the file "LauncherInternalConfig.xml"
        /// </summary>
        public const string InternalConfigFileUrl = "http://10.211.55.3/launcher/LauncherInternalConfig.xml";
        /// <summary>
        /// Max download erros attemps
        /// </summary>
        public const int MaxDownloadErrosAttempts = 5;
        /// <summary>
        /// The name of the Executable(Ex: Launcher.exe)
        /// </summary>
        public const string ExecutableName = "Dark Launcher";


        /// <summary>
        /// The parameter of the Updater.exe
        /// </summary>
        public const string UpdaterExecuteParameter = "test_open";

        /// <summary>
        /// Internal config file path
        /// </summary>
        //TODO: Mudar para a pasta temporaria
        public static readonly string InternalConfigFilePath = Path.Combine(Environment.CurrentDirectory, "LauncherInternalConfig.xml");

        #region Launcher Cryptography
        public const int AesKeySize = 256;
        /// <summary>
        /// The AES key that your LauncherInternalConfig.xml will be encrypted
        /// </summary>
        public const string AesKey = "darkherotest";
        #endregion

    }
}
