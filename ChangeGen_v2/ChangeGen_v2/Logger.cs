using System;
using System.IO;

namespace ChangeGen_v2
{
    internal static class Logger
    {
        private static readonly object Lock = new object();

        public static void Log(string logMessage, LogLevel level = LogLevel.Info, string serverIp = "")
        {
            lock (Lock)
            {
                using (var w = File.AppendText("log.txt"))
                {
                    w.WriteLine("[{0}][{1}][{2}]: {3}", level, serverIp, DateTime.Now, logMessage);
                }
            }
        }

        public static void LogError(string logMessage, string serverIp, Exception e)
        {
            lock (Lock)
            {
                using (var w = File.AppendText("log.txt"))
                {
                    w.WriteLine("[{0}][{1}][{2}]: {3}" + Environment.NewLine +
                        e.GetType() + Environment.NewLine+
                        e.Message + Environment.NewLine+
                        e.StackTrace, LogLevel.Error, serverIp, DateTime.Now, logMessage);
                }
            }
        }

        public enum LogLevel
        {
            Info,
            Warning,
            Error
        }
    }
}
