using System;
using Launcher.ExtensionMethods;
using Launcher.Management;
using System.Xml;
using System.Diagnostics;

namespace LauncherSettings.Base
{
    public class SettingsManager
    {

      /*  private XMLManager xml;

        public int GUI { get; set; }
        public int Text { get; set; }
        public int Audio { get; set; }
        public int Client { get; set; }


        public void LoadSettings()
        {
            try
            {
                xml = new XMLManager();
                xml.InitializeFromFile("LanguageSettings.xml");

                XmlNodeList nodeList = xml.GetNodes("languageSettings");
                for (int i = 0; i < nodeList.Count; i++)
                {
                    XmlNode node = nodeList[i];
                    GUI = int.Parse(node["gui"].InnerText);
                    Text = int.Parse(node["text"].InnerText); 
                    Audio = int.Parse(node["audio"].InnerText);
                    Client = int.Parse(node["client"].InnerText);
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
        public void saveToXML(string option, string value)
        {
            XmlNode node = xml.GetNode("languageSettings");
            node[option].InnerText = value;
            xml.saveFile("LanguageSettings.xml");
        }*/
    }
}
