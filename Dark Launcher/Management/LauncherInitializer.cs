using Dark_Launcher.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Launcher.Management
{
    public class LauncherInitializer
    {
        public LauncherInitializer()
        {
            loadLanguage();

            var configs = new LauncherConfigurationsManager();
            configs.LoadInternalConfigs("LauncherInternalConfig.xml");
        }

        private void loadLanguage()
        {
            LanguageManager languageManager = new LanguageManager();
            languageManager.LoadLanguages();
            languageManager.LoadLanguageStrings(LauncherConstants.DefaultLanguageID);
        }


    }
}
