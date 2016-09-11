using System;
using System.Linq;
using Launcher.ExtensionMethods;
using Launcher.Management;
using System.Xml;
using System.Diagnostics;

namespace SettingsManager.Base
{
    class LanguageSettings
    {
        // Texture contains texture files
        // Stage contains all text
        // ResSet contains character voices 
        // Sound contains music

        private string[] textureFiles = { "ui1.kom", "ui2.kom", "ui3.kom", "ui4.kom", "ui_seasson2.kom", "tex_dungeon_infoimage.kom", "loading.kom", "eventbannerimages.kom", "Catalog.kom" };
        private string[] stageFiles = { "string.kom" };
        private string[] ressetFiles = { "char_special4_type2.kom", "char_mariskilltree.kom", "petminielesis.kom", "char_amy4.kom", "Char_Asin1.kom", "Char_Asin2.kom", "char_beigas1.kom", "char_dio1.kom", "char_dio2.kom", "char_dio3.kom", "char_dio4.kom", "char_edel.kom", "char_edel2.kom", "Char_Jin2.kom", "Char_Jin4.kom", "Char_Ley1.kom", "Char_Ley2.kom", "Char_Ley3.kom", "Char_Ley4.kom", "Char_Lime1.kom", "Char_Lime2.kom", "char_lupus.kom", "Char_Mari.kom", "Char_Mari1.kom", "Char_Mari2.kom", "Char_Mari3.kom", "Char_Rin1.kom", "Char_Rin2.kom", "Char_Rin3.kom", "char_rin4.kom", "Char_Sieg2.kom", "Char_Sieg3.kom", "Char_Sieg4.kom", "char_sp4.kom", "char_zero1.kom", "Char_Zero2.kom", "Char_Zero3.kom", "Char_Zero4.kom", "renew_arme.kom", "Skill_Amy1.kom", "Skill_Jin1.kom", "Skill_Ronan1.kom", "Skill_Sieg1.kom" };
        private string[] soundFiles = { "sound_korea.kom", "sound_korea2.kom", "sound_korea3.kom", "sound_korea4.kom", "sound4.kom" };

        public int GUI { get; set; }
        public int Text { get; set; }
        public int Audio { get; set; }

        public void  LoadSettings()
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
                    this.Text =   node.ParseIntAttribute("text");
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
