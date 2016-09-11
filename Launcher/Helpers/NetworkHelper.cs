using Launcher.Management;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;

namespace Launcher.Helpers
{
    public static class NetworkHelper
    {
        /// <summary>
        /// Check if the file has downloaded sucessfully
        /// </summary>
        /// <param name="e">Completed event args</param>
        /// <param name="showLog">If set to <c>true</c> show error log.</param>
        /// <returns></returns>
        public static bool ValidateDownloadedFile(AsyncCompletedEventArgs e, bool showLog = false)
        {
            if (e.Error != null || e.Cancelled)
            {
#if DEBUG
                Debug.Print(e.Error.ToString());
#endif
                if(showLog)
                    LogManager.WriteLog("Error on download file: " + e.Error);
                return false;
            }
            return true;
        }

        public static bool CheckForInternetConnection(string serverToPing)
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead(serverToPing))
                    {
                        return true;
                    }
                }
            }
            catch (Exception er)
            {
#if DEBUG
                Debug.Print(er.Message);
#endif
                LogManager.WriteLog($"Error on check for internet connection {er.Message}");
                return false;
            }
        }
    }
}
