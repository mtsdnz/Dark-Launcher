using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Dark_Launcher.ViewModel;

namespace Dark_Launcher.View
{
    /// <summary>
    /// Interaction logic for LanguageSelector.xaml
    /// </summary>
    public partial class LanguageSelector : Window
    {
        public LanguageSelector()
        {
            InitializeComponent();
            var languageSelectorViewModel = new LanguageSelectorViewModel();
            DataContext = languageSelectorViewModel;
        }
    }
}
