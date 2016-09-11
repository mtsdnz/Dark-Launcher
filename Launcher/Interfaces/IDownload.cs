using System.ComponentModel;
using System.Net;
namespace Launcher.Interfaces
{
    /// <summary>
    /// Download interface
    /// </summary>
    interface IDownload
    {
        void DownloadFileAsync(string url, string filePath, AsyncCompletedEventHandler downloadCompletedDelegate, DownloadProgressChangedEventHandler downloadProgressChanged = null);
        void DownloadString(string url, DownloadStringCompletedEventHandler downloadCompletedDelegate);
    }
}
