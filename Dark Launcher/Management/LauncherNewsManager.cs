using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using Dark_Launcher.Base;
using Dark_Launcher.Constants;
using Dark_Launcher.Settings;
using Launcher.Management;

namespace Dark_Launcher.Management
{
    internal sealed class LauncherNewsManager
    {
        internal delegate void OnNewsDownloadDelegate(List<News> news);

        internal OnNewsDownloadDelegate OnNewsDownloadCallback;

        internal List<News> News;

        internal void GetNews()
        {
            if (!LauncherSettings.ShowNews) return;
            DownloadManager dm = new DownloadManager();
            dm.DownloadString(FtpSettings.XmlNewsUrl, OnNewsStringDownloadCompleted);
        }

        private void AddDefaultNews(string title = null)
        {
            if (News == null)
                News = new List<News>();
            News.Add(new News
            {
                Date = DateTime.Now.ToString("[dd/MM/yyyy]"),
                Title = title ?? LanguageManager.GetString(9),
                Url = FtpSettings.ForumUrl
            });
        }

        private void OnNewsStringDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {

            News = new List<News>();
            if (string.IsNullOrEmpty(e.Result))
            {
                LogManager.WriteLog("News xml is null or empty");
                AddDefaultNews();
            }
            else
            {
                try
                {
                    XmlManager xm = new XmlManager();
                    xm.InitializeFromString(e.Result);

                    XmlNodeList newsNodeList = xm.GetNodes("notices/notice");
                    foreach (XmlNode newsNode in newsNodeList)
                    {
                        News.Add(new News
                        {
                            Title = newsNode.SelectSingleNode("title").InnerText,
                            Date = newsNode.SelectSingleNode("when").InnerText,
                            Url = FtpSettings.ForumUrl + newsNode.SelectSingleNode("url").InnerText
                        });
                    }

                    if (News.Count == 0)
                        AddDefaultNews(LanguageManager.GetString(10));

                }
                catch (Exception exception)
                {
                    AddDefaultNews();
                    LogManager.WriteLog("Exception on download news Xml: " + exception.Message);
                }
            }

            OnNewsDownloadCallback?.Invoke(News);
        }
    }
    
}
