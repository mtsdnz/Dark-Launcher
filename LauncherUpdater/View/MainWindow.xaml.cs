using LauncherUpdater.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;

namespace LauncherUpdater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new MainViewModel();
            vm.UIDispatcher = Dispatcher;
            DataContext = vm;
            Loaded += vm.OnWindowLoaded;
        }
    }
}
