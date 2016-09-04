using System;

namespace Dark_Launcher.Constants
{
    internal sealed class LauncherConstants
    {
        #region News Constants 
        public const int NewsMaxTitleLength = 38;
        #endregion

        #region LanguageConstants
        public const string LanguageFile = "LauncherLanguage.xml";
        public const string LanguagesStringsFilePath = "LauncherLanguages/{0}.xml";
        public const int DefaultLanguageID = 1;
        #endregion

        #region LauncherWindow
        public const string LauncherTitle = "Launcher";
        public const string LauncherWindowTitle = "Launcher GC XX";
        #endregion

        #region Internal Path Configs
        public const string PathLogFileName = "LauncherError.log";
        #endregion

        #region Launcher Cryptography Settings
        /// <summary>
        /// The AES key that your LauncherConfig.xml will be encrypted
        /// </summary>
        public const string AESKey = "darkherotest";

        /// <summary>
        /// This constant is used to determine the keysize of the encryption algorithm.
        /// </summary>
        public const int KeySize = 256;
        #endregion

        #region Game Configs
        /// <summary>
        /// Main parameter
        /// </summary>
        public readonly string MainParameter = "parameter123";

        #endregion
        

    }
}
