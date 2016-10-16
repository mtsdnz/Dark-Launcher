using Dark_Launcher.Base;
using Dark_Launcher.Command;
using Dark_Launcher.Constants;
using Dark_Launcher.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Dark_Launcher.Management;
using Dark_Launcher.Settings;
using Launcher.ExtensionMethods;
using Launcher.Helpers;
using Launcher.Management;
using static Dark_Launcher.Management.LanguageManager;

namespace Dark_Launcher.ViewModel
{
    internal sealed class LauncherViewModel : ViewModelBase
    {
        #region Binding Variables

        private List<News> _launcherNews;

        public List<News> LauncherNews
        {
            get { return _launcherNews; }
            set { SetAndNotify(ref _launcherNews, value); }
        }

        private int _currentFileProgressbarValue;

        public int CurrentFileProgressbarValue
        {
            get { return _currentFileProgressbarValue; }
            set { SetAndNotify(ref _currentFileProgressbarValue, value); }
        }

        private int _totalFilesProgressbarValue;

        public int TotalFilesProgressbarValue
        {
            get { return _totalFilesProgressbarValue; }
            set { SetAndNotify(ref _totalFilesProgressbarValue, value); }
        }

        private string _currentTask;

        public string CurrentTask
        {
            get { return _currentTask; }
            set { SetAndNotify(ref _currentTask, value); }
        }

        private bool _playButtonEnabled;

        public bool PlayButtonEnabled
        {
            get { return _playButtonEnabled; }
            set { SetAndNotify(ref _playButtonEnabled, value); }
        }

        #endregion

        #region Commands

        private ICommand _playCommand;

        public ICommand PlayCommand
        {
            get { return _playCommand; }
            set { SetAndNotify(ref _playCommand, value); }
        }

        private ICommand _closeCommand;

        public ICommand CloseCommand
        {
            get { return _closeCommand; }
            set { SetAndNotify(ref _closeCommand, value); }
        }

        #endregion

        #region Launcher Strings Language

        public string LastNewsStr => GetString(1).ToUpper();
        public string SeeMoreStr => GetString(2);

        //TODO: insert the server status(online and offline)
        public string ServerStatusStr => GetString(3);
        public string FileStr => GetString(4);
        public string TotalStr => GetString(5);
        public string PlayButtonStr => GetString(6).ToUpper();
        public string LauncherWindowTitle => LauncherConstants.LauncherWindowTitle;
        public string LauncherTitle => LauncherConstants.LauncherTitle;
        public string SeeMoreUrl => FtpSettings.ForumUrl;

        #endregion

        #region Local variables
        private int _fileDownloadIndex;
        private List<LauncherFileManager.FileListItem> _listToUpdate;
        private Stopwatch _sw = new Stopwatch();
        private string _currentDownloadingFileName;
        private int _downloadsErros;
        #endregion

        #region Constructor
        
        public LauncherViewModel()
        {
            PlayCommand = new RelayCommand(ExecutePlayCommand);
            CloseCommand = new RelayCommand(ExecuteCloseCommand);

            CurrentTask = GetString(12);

            if (LauncherSettings.ShowNews)
            {
                LauncherNews = new List<News>
                {
                    new News
                    {
                        Title = GetString(11),
                        Date = DateTime.Now.ToString("[dd/MM/yyyy]"),
                        Url = FtpSettings.ForumUrl
                    }
                };
                //initializer the launcher news
                var launcherNewsManager = new LauncherNewsManager();
                launcherNewsManager.GetNews();
                launcherNewsManager.OnNewsDownloadCallback += OnNewsDownloadCallback;
            }

            //initializer launcher update
            var launcherFileManager = new LauncherFileManager();
            launcherFileManager.DownloadFileList();
            launcherFileManager.OnDownloadFileListCompleteCallback += () =>
            {
                _listToUpdate = launcherFileManager.FilesToUpdateList;
                DownloadFile();
            };
        }
        #endregion

        #region Download Methods and Callbacks
        private void OnNewsDownloadCallback(List<News> news)
        {
            LauncherNews = news;
        }

        private void DownloadFile()
        {
            if (_listToUpdate.Count == 0)
            {
                FilesDownloadCompleted();
                return;
            }
            PlayButtonEnabled = false;
            LauncherFileManager.FileListItem currentFileListItem = _listToUpdate[_fileDownloadIndex];
            DownloadManager downloadManager = new DownloadManager();
            _sw.Start();
            downloadManager.DownloadFileAsync(FtpSettings.ClientMirrorUrl + currentFileListItem.Path,
                currentFileListItem.FullPath, OnDownloadFileCompleted, OnDownloadFileProgressChanged);
            _currentDownloadingFileName = System.IO.Path.GetFileName(currentFileListItem.FullPath);
        }

        private void FilesDownloadCompleted()
        {
            CurrentTask = GetString(13);
            CurrentFileProgressbarValue = 100;
            TotalFilesProgressbarValue = 100;
            PlayButtonEnabled = true;
        }

        private void OnDownloadFileCompleted(object sender, AsyncCompletedEventArgs eventArgs)
        {
            _sw.Reset();
            if (!NetworkHelper.ValidateDownloadedFile(eventArgs))
            {
                LogManager.WriteLog("Error on download file: " + eventArgs.Error);
                CurrentFileProgressbarValue = 0;
                if (++_downloadsErros <= LauncherConstants.MaxDownloadsAttemps)
                    DownloadFile();
                else
                {
                    string message = string.Format(GetString(16), _listToUpdate[_fileDownloadIndex].Path);
                    MessageBox.Show(message, "Error on download file", MessageBoxButton.OK, MessageBoxImage.Error);
                    LogManager.WriteLog(message);
                    Environment.Exit(1);
                }
                return;
            }
            _downloadsErros = 0;
            ++_fileDownloadIndex;
            int totalFilesToUpdate = _listToUpdate.Count;
            TotalFilesProgressbarValue = (int) ((float) _fileDownloadIndex/totalFilesToUpdate*100);

            if (totalFilesToUpdate == _fileDownloadIndex)
                FilesDownloadCompleted();
            else
                DownloadFile();
        }

        private void OnDownloadFileProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                if (LauncherSettings.ShowSpeed)
                {
                    string downloadSpeed;
                    CurrentTask = string.Format(GetString(14), _currentDownloadingFileName,
                        NetworkHelper.GetDownloadSpeed(e.BytesReceived, _sw.Elapsed.TotalSeconds, out downloadSpeed),
                        downloadSpeed, e.BytesReceived.ToPrettySize(),
                        e.TotalBytesToReceive.ToPrettySize());
                }
                else
                {
                    CurrentTask = string.Format(GetString(15), _currentDownloadingFileName,
                        e.BytesReceived.ToPrettySize(), e.TotalBytesToReceive.ToPrettySize());
                }

                CurrentFileProgressbarValue = e.ProgressPercentage;
            }
            catch (Exception er)
            {
                LogManager.WriteLog("Error on update file progress: " + er.Message);
                DownloadFile();
            }
        }
#endregion

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
