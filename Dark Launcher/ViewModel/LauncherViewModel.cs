using Dark_Launcher.Base;
using Dark_Launcher.Command;
using Dark_Launcher.Constants;
using Dark_Launcher.Model;
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

        private IList<News> launcherNews;
        public IList<News> LauncherNews
        {
            get { return launcherNews; }
            set { SetAndNotify(ref launcherNews, value); }
        }

        #region Commands
        public ICommand playCommand;
        public ICommand PlayCommand
        {
            get { return playCommand; }
            set { SetAndNotify(ref playCommand, value); }
        }

        public ICommand closeCommand;
        public ICommand CloseCommand
        {
            get { return closeCommand; }
            set { SetAndNotify(ref closeCommand, value); }
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
        public string LauncherWindowTitle { get { return LauncherConstants.LauncherWindowTitle; } }
        public string LauncherTitle { get { return LauncherConstants.LauncherTitle; } }

        private string _currentTask;
        public string CurrentTask {
            get { return _currentTask; }
            set { SetAndNotify(ref _currentTask, value); }
        }

        #endregion

        public LauncherViewModel()
        {
            PlayCommand = new RelayCommand(ExecutePlayCommand);
            CloseCommand = new RelayCommand(ExecuteCloseCommand);
            LauncherNews = new List<News>();

            launcherNews.Add(new News { Title = "NEWS TITLE TEST 1", Date = "02/02/2012", Url = "http://google.com.br" });
            LauncherNews.Add(new News { Title = "News title test 2", Date = "03/03/2013", Url = "http://google.com.br" });

            CurrentTask = "Initializing update...";
        }

        #region ExecuteCommands
        private void ExecutePlayCommand(object param)
        {
            MessageBox.Show("played!");
            CurrentTask = "playing";
        }

        private void ExecuteCloseCommand(object obj)
        {
            Environment.Exit(1);
        }
        #endregion


    }
}
