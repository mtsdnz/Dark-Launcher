using Dark_Launcher.Base;
using Dark_Launcher.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Dark_Launcher.ViewModel
{
    public sealed class LauncherViewModel : ViewModelBase
    {
        public Dispatcher UIDispatcher;

        private ObservableCollection<News> launcherNews;
        public ObservableCollection<News> LauncherNews
        {
            get { return launcherNews; }
            set { SetAndNotify(ref launcherNews, value, "LauncherNews"); }
        }

        public ICommand playCommand;
        public ICommand PlayCommand
        {
            get { return playCommand; }
            set { SetAndNotify(ref playCommand, value, "PlayCommand"); }
        }

        public LauncherViewModel()
        {
            Console.WriteLine("initialized!");
            PlayCommand = new RelayCommand(ExecutePlayCommand);
            LauncherNews = new ObservableCollection<News>();
            launcherNews.Add( new News { Title= "NEWS TITLE TEST 1", Date = "02/02/2012", Url="http://google.com.br" } );
            LauncherNews.Add(new News { Title = "News title test 2", Date = "03/03/2013", Url = "http://google.com.br" });

        }

        private void ExecutePlayCommand(object param)
        {
            MessageBox.Show("played!");
            
        }

        
    }
}
