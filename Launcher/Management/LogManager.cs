using System;
using System.Diagnostics;
using System.IO;

namespace Launcher.Management
{
    public static class LogManager
    {
        public enum LogType
        {
            Warn,
            Error
        }
        public static void CreateLog(string path)
        {
            if (File.Exists(path)) return;
            Stream st = File.Create(path);
            st.Flush();
            st.Close();
        }

        public static void WriteLog(string error, LogType logType = LogType.Error)
        {
            string errorLog = $"[{DateTime.Now}] <{logType}>: {error}";
            WriteOnFile(errorLog);
#if DEBUG
            Debug.Print(errorLog);
#endif
        }

        private static void WriteOnFile(string stringToWrite)
        {
            try
            {
                using (TextWriter writer = File.AppendText(Path.Combine(Environment.CurrentDirectory, "LauncherError.log")))
                {
                    writer.WriteLine(stringToWrite);
                }
            }
            catch
            {
                throw new ApplicationException();
            }
        }
    }
}
