using Dark_Launcher.Management;
using System;
using System.Windows;
namespace Dark_Launcher.View
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        public static Splash SplashInstance;
        public Splash()
        {
            SplashInstance = this;
            InitializeComponent();
        }

        public void OnSplashContentRendered(object sender, EventArgs e)
        {
            LauncherInitializer initializer = new LauncherInitializer();
            initializer.InitializerLauncher();
            initializer.OnLauncherInitializerCallback += OpenForm;
        }

        public void OpenForm()
        {
            var mainWindow = new LauncherMainWindow();
            mainWindow.Show();

            Close();
        }
    }
}
