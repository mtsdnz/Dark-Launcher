using Dark_Launcher.Base;
using Dark_Launcher.Command;
using Dark_Launcher.Constants;
using Dark_Launcher.Management;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using static Dark_Launcher.Management.LanguageManager;

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

        #region Commands
        public ICommand playCommand;
        public ICommand PlayCommand
        {
            get { return playCommand; }
            set { SetAndNotify(ref playCommand, value, "PlayCommand"); }
        }
        #endregion

        #region Launcher Strings Language
        public string LastNewsStr { get { return GetString(1).ToUpper(); } }
        public string SeeMoreStr { get { return GetString(2); } }
        //TODO: Put the server status(online and offline)
        public string ServerStatusStr { get { return GetString(3); } }
        public string FileStr { get { return GetString(4); } }
        public string TotalStr { get { return GetString(5); } }
        public string PlayButtonStr { get { return GetString(6).ToUpper(); } }
        public string CurrentTask { get; set; }
        public string LauncherWindowTitle { get { return LauncherConstants.LauncherWindowTitle; } }
        public string LauncherTitle { get { return LauncherConstants.LauncherTitle; } }

        #endregion

        public LauncherViewModel()
        {
            Console.WriteLine("initialized!");
            PlayCommand = new RelayCommand(ExecutePlayCommand);
            LauncherNews = new ObservableCollection<News>();
            launcherNews.Add( new News { Title= "NEWS TITLE TEST 1", Date = "02/02/2012", Url="http://google.com.br" } );
            LauncherNews.Add(new News { Title = "News title test 2", Date = "03/03/2013", Url = "http://google.com.br" });

            CurrentTask = "Initializing update...";
        }

        #region ExecuteCommands
        private void ExecutePlayCommand(object param)
        {
            MessageBox.Show("played!");
        }
        #endregion


    }
}
