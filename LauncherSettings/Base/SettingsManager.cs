using System;
using Launcher.ExtensionMethods;
using Launcher.Management;
using System.Xml;
using System.Diagnostics;

namespace LauncherSettings.Base
{
    public class SettingsManager
    {

        public int GUI { get; set; }
        public int Text { get; set; }
        public int Audio { get; set; }

        public void LoadSettings()
        {
            try
            {
                XMLManager xml = new XMLManager();
                xml.InitializeFromFile("LanguageSettings.xml");

                XmlNodeList nodeList = xml.GetNodes("languageSettings");
                for (int i = 0; i < nodeList.Count; i++)
                {
                    XmlNode node = nodeList[i];
                    this.GUI = node.ParseIntAttribute("gui");
                    this.Text = node.ParseIntAttribute("text");
                    this.Audio = node.ParseIntAttribute("audio");
                }
#if DEBUG
                Debug.WriteLine("Language settings loaded");
#endif
            }
            catch (Exception er)
            {
                LogManager.WriteLog("Exception on loading language settings:" + er.Message);
            }
        }


    }
}
