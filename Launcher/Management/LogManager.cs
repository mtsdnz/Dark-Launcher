using System;
using System.IO;

namespace Dark_Launcher.Management
{
    public static class LogManager
    {
        public enum LogType
        {
            WARN,
            ERROR
        }
        public static void CreateLog(string path)
        {
            if (!File.Exists(path))
            {
                Stream st = File.Create(path);
                st.Flush();
                st.Close();
            }
        }

        public static void WriteLog(string error, LogType logType = LogType.ERROR)
        {
            writeOnFile(string.Format("[{0}] <{1}>: {2}", DateTime.Now, logType, error));
        }

        private static void writeOnFile(string stringToWrite)
        {
            try
            {
                using (TextWriter Writer = File.AppendText(Path.Combine(Environment.CurrentDirectory, "LauncherError.log")))
                {
                    Writer.WriteLine(stringToWrite);
                }
            }
            catch
            {
                throw new Exception("Write");
            }
        }
    }
}
