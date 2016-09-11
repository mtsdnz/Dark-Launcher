using Dark_Launcher.Base;
using Dark_Launcher.Constants;
using Launcher.ExtensionMethods;
using Launcher.Management;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;

namespace Dark_Launcher.Management
{
    internal class LanguageManager
    {
        public List<Language> Languages = new List<Language>();
        public static Language CurrentLanguage;

        public void LoadLanguages()
        {
            try
            {
                XMLManager xml = new XMLManager();
                xml.InitializeFromFile("LauncherLanguage.xml");

                XmlNodeList nodeList = xml.GetNodes("languages/language");
                for (int i = 0; i < nodeList.Count; i++)
                {
                    XmlNode node = nodeList[i];
                    Language language = new Language();
                    language.Name = node.SelectSingleNode("name").InnerText;
                    language.FileName = node.SelectSingleNode("fileName").InnerText;
                    language.Id = node.ParseIntAttribute("id");
                    Languages.Add(language);
                }
#if DEBUG
                Debug.WriteLine("Loaded languages count -> " + Languages.Count);
#endif
            }
            catch (Exception er)
            {
                LogManager.WriteLog("Exception on load languages:" + er.Message);
            }
        }

        public Language LoadLanguageStrings(int languageID)
        {
            try
            {
                Language lang = Languages.FirstOrDefault(l => l.Id == languageID);
                if (lang == null)
                    throw new NullReferenceException("language");

                XMLManager xml = new XMLManager();
                xml.InitializeFromFile(string.Format(LauncherConstants.LanguagesStringsFilePath, lang.FileName));

                XmlNodeList languageNodes = xml.GetNodes("language/strings/string");

                foreach (XmlNode nodeString in languageNodes)
                    lang.Strings.Add(nodeString.ParseIntAttribute("id"), nodeString.InnerText);

#if DEBUG
                Debug.Print("Loaded strings -> {0} from language {1}", lang.Strings.Count, lang.Name);
#endif

                CurrentLanguage = lang;
                return lang;
            }
            catch (Exception er)
            {
                LogManager.WriteLog("Exception on load language strings: " + er.Message);
                return null;
            }
        }

        public static string GetString(int stringId)
        {
            return CurrentLanguage.Strings[stringId];
        }
    }
}
