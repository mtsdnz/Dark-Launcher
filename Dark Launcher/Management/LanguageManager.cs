using Dark_Launcher.Base;
using Dark_Launcher.Constants;
using Launcher.ExtensionMethods;
using Launcher.Management;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Dark_Launcher.Settings;

namespace Dark_Launcher.Management
{
    internal sealed class LanguageManager
    {
        internal List<Language> Languages = new List<Language>();
        internal static Language CurrentLanguage;

        internal void LoadLanguages()
        {
            try
            {
                XmlManager xml = new XmlManager();
                xml.InitializeFromFile("LauncherLanguage.xml");

                XmlNode languagesNode = xml.GetNode("languages");

                XmlNodeList nodeList = languagesNode.SelectNodes("language");// xml.GetNodes("languages/language");

                if (!languagesNode.HasAttribute("currentLanguageId"))
                    LauncherSettings.HasDefaultLanguage = false;
                else
                    LauncherSettings.DefaultLanguageId = languagesNode.ParseIntAttribute("currentLanguageId");

                for (int i = 0; i < nodeList.Count; i++)
                {
                    XmlNode node = nodeList[i];
                    Language language = new Language
                    {
                        Name = node.SelectSingleNode("name")?.InnerText,
                        FileName = node.SelectSingleNode("fileName")?.InnerText,
                        Id = node.ParseIntAttribute("id")
                    };
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

        internal Language LoadLanguageStrings(int languageId)
        {
            try
            {
                Language lang = Languages.FirstOrDefault(l => l.Id == languageId);
                if (lang == null)
                    throw new NullReferenceException("language");

                XmlManager xml = new XmlManager();
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

        internal static string GetString(int stringId)
        {
            try
            {
                return CurrentLanguage.Strings[stringId];
            }
            catch (Exception)
            {
                LogManager.WriteLog("Could not load the string at index: " + stringId);

                return string.Empty;
            }
            
        }
    }
}
