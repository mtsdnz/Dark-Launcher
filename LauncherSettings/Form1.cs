using LauncherSettings.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherSettings
{
    public partial class Form1 : Form
    {

        SettingsManager settingsManager;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            settingsManager = new SettingsManager();
#if DEBUG
            settingsManager.LoadSettings();
#endif

            setButtonsOnLoad(pnlAudio, settingsManager.Audio);
            setButtonsOnLoad(pnlGUI, settingsManager.GUI);
            setButtonsOnLoad(pnlText, settingsManager.Text);
            chkClient.Checked = isClientChecked();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var audioChecked = pnlAudio.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
            var textChecked = pnlText.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
            var guiChecked = pnlGUI.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;

            settingsManager.GUI = getLanguageOptionById(guiChecked);
            settingsManager.Text = getLanguageOptionById(textChecked);
            settingsManager.Audio = getLanguageOptionById(audioChecked);
            settingsManager.Client = getLanguageOptionById(chkClient);


            settingsManager.saveToXML("gui", settingsManager.GUI.ToString());
            settingsManager.saveToXML("text", settingsManager.Text.ToString());
            settingsManager.saveToXML("audio", settingsManager.Audio.ToString());
            settingsManager.saveToXML("client", settingsManager.Client.ToString());

        }
        public int getLanguageOptionById(CheckBox chk)
        {
            if(chk.Checked)
            {
                return 1;
            }else
            {
                return 0;
            }
        }
        public Boolean isClientChecked()
        {
            if (settingsManager.Client == 1) return true;
            return false;
        }
        public int getLanguageOptionById(String name)
        {
            if (name.Equals("Português"))
            {
                return 0;
            }else if (name.Equals("English"))
            {
                return 1;
            }
            return 1;
        }
        public void setButtonsOnLoad(Panel pnl, int id)
        {
            RadioButton rb = pnl.Controls[id] as RadioButton;
            rb.Checked = true;
        }
    }
}
