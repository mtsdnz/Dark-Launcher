using System.ComponentModel;
using System.Net;
namespace Dark_Launcher.Management.Interfaces
{
    /// <summary>
    /// Download interface, will be updated soon.
    /// </summary>
    interface IDownload
    {
        void DownloadFile(string url, string filePath, AsyncCompletedEventHandler downloadCompletedDelegate, DownloadProgressChangedEventHandler downloadProgressChanged = null);
        void DownloadString(string url, DownloadStringCompletedEventHandler downloadCompletedDelegate);
    }
}
