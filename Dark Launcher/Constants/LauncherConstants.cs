namespace Dark_Launcher.Constants
{
    internal sealed class LauncherConstants
    {
        #region News Constants 
        internal const int NewsMaxTitleLength = 38;
        #endregion

        #region LanguageConstants
        internal const string LanguageFile = "LauncherLanguage.xml";
        internal const string LanguagesStringsFilePath = "LauncherLanguages/{0}.xml";
        internal const int DefaultLanguageId = 1;
        #endregion

        #region LauncherWindow
        internal const string LauncherTitle = "Launcher";
        internal const string LauncherWindowTitle = "Launcher GC XX";
        #endregion

        #region Download Constants

        internal const int MaxDownloadsAttemps = 5;
        #endregion


        #region Game Configs
        /// <summary>
        /// Main parameter
        /// </summary>
        internal readonly string GameExecuteCommandArgs = "main.exe parameter123";
        #endregion
        

    }
}
