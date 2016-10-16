using System.Windows;
using System.Windows.Input;
using Dark_Launcher.ViewModel;
using System.Diagnostics;

namespace Dark_Launcher
{
    /// <summary>
    /// Interaction logic for Launcher.xaml
    /// </summary>
    public partial class LauncherMainWindow : Window
    {

        public LauncherMainWindow()
        {
            InitializeComponent();
            var launcherViewModel = new LauncherViewModel();
            DataContext = launcherViewModel;
        }

        /// <summary>
        /// On drag window event handler
        /// </summary>
        private void OnDragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        /// <summary>
        /// On hyperlink eventhandler click
        /// </summary>
        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true; //abre o navegador padrão
        }

        /// <summary>
        /// Close the launcher
        /// </summary>
        private void CloseCommand()
        {
            Application.Current.Shutdown();
        }
    }
}
