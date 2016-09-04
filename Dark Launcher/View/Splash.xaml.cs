using Dark_Launcher.Management;
using System.Windows;
namespace Dark_Launcher.View
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        public Splash()
        {
            InitializeComponent();
            LauncherInitializer initializer = new LauncherInitializer();
            OpenForm();
            
        }

        private void OpenForm()
        {
            LauncherMainWindow main = new LauncherMainWindow();
            main.Show();

            this.Close();
        }
    }
}
