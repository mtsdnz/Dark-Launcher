using Launcher.Interfaces;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace Launcher.Management
{
    /// <summary>
    /// Download manager class
    /// </summary>
    public class DownloadManager : IDownload
    {
        /// <summary>
        /// Downloads a file.
        /// </summary>
        /// <param name="url">File URL.</param>
        /// <param name="filePath">File path.</param>
        /// <param name="downloadCompletedCallback">Download completed cabllback.</param>
        /// <param name="downloadProgressChangedCallback">Download progress callback.</param>
        public void DownloadFileAsync(string url, string filePath, AsyncCompletedEventHandler downloadCompletedCallback, DownloadProgressChangedEventHandler downloadProgressChangedCallback = null)
        {
            if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(filePath))
            {
                try
                {
                    using (WebClient wb = new WebClient())
                    {
                        if (File.Exists(filePath))
                            File.Delete(filePath);

                        var fileDirectory = Path.GetDirectoryName(filePath);
                        if (!Directory.Exists(fileDirectory))
                            Directory.CreateDirectory(fileDirectory);

                        wb.Proxy = null;
                        wb.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
                        WebRequest.DefaultWebProxy = null;

                        wb.DownloadFileCompleted += downloadCompletedCallback;
                        wb.DownloadProgressChanged += downloadProgressChangedCallback;
                        wb.DownloadFileAsync(new Uri(url), filePath, filePath);
                    }
                }
                catch (Exception e)
                {
                    LogManager.WriteLog($"Exception on download file: {filePath}, error: {e.Message}");
#if DEBUG
                    Debug.Print($"error on download file {filePath} from url {url} : {e.Message}");
#endif
                }
            }
            else
            {
                LogManager.WriteLog("URL or FilePath is null or empty. Failed on download file.");
#if DEBUG
                Debug.Print($"URL or filePath is null. url: {url} filePath: {filePath}");
#endif
            }
        }

        public void DownloadString(string url, DownloadStringCompletedEventHandler downloadStringCompletedCallback)
        {
            if (!string.IsNullOrEmpty(url))
            {
                try
                {
                    using (WebClient wb = new WebClient())
                    {
                        wb.DownloadStringCompleted += downloadStringCompletedCallback;
                        wb.DownloadStringAsync(new Uri(url));
                    }
                }
                catch (Exception e)
                {
                    LogManager.WriteLog($"Exception on download string: {e.Message} ");
                }
            }
            else
            {
                LogManager.WriteLog("Error on download string. Url is empty.");
            }
        }
    }
}
