using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Dark_Launcher.Model;

namespace Dark_Launcher.ViewModel
{
    internal sealed class LanguageSelectorViewModel : ViewModelBase
    {
        public struct Languages
        {
            public string Name;
        }
        private ListView _languagesList;

        public ListView LanguageList
        {
            get { return _languagesList; }
            set { SetAndNotify(ref _languagesList, value);}
        }

        public LanguageSelectorViewModel()
        {
            List<Languages> langs = new List<Languages>
            {
                new Languages {Name = "PORTUGUESE"},
                new Languages {Name = "ENGLISH"}
            };

            LanguageList = new ListView {ItemsSource = langs};

        }


    }
}
