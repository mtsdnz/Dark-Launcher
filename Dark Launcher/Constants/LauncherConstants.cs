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

        #region InternalConfigs
        public const string DefaultLogFileName = "LauncherError.log";
        #endregion
    }
}
