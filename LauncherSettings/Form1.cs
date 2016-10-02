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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void chkAudio_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < chkAudio.Items.Count; ++ix)
                if (ix != e.Index) chkAudio.SetItemChecked(ix, false);
        }

        private void chkText_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < chkText.Items.Count; ++ix)
                if (ix != e.Index) chkText.SetItemChecked(ix, false);
        }

        private void chkGUI_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < chkGUI.Items.Count; ++ix)
                if (ix != e.Index) chkGUI.SetItemChecked(ix, false);
        }
    }
}
