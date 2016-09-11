using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Interfaces
{
    interface IDownloadFile
    {
        string FileUrl { get; set; }
        string FilePath { get; set; }
        AsyncCompletedEventHandler DownloadCompletedCallback { get; set; }
        DownloadProgressChangedEventHandler DownloadProgressChangedCallback { get; set; }
    }
}
