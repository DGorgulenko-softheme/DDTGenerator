using System;
using System.IO;

namespace ChangeGen_v2
{
    internal static class Logger
    {
        private static readonly object Lock = new object();

        public static void Log(string logMessage, LogLevel level, string serverIp)
        {
            lock (Lock)
            {
                using (var w = File.AppendText("log.txt"))
                {
                    w.WriteLine("[{0}][{1}][{2}]: {3}", level.ToString(), serverIp, DateTime.Now.ToString(), logMessage);
                }
            }
        }

        public static void Log(string logMessage)
        {
            Log(logMessage, LogLevel.Info, "");
        }

        public static void Log(string logMessage, LogLevel level)
        {
            Log(logMessage, level, "");
        }
        public static void Log(string logMessage, string serverIp)
        {
            Log(logMessage, LogLevel.Info, serverIp);
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
                        e.StackTrace, LogLevel.Error, serverIp, DateTime.Now.ToString(), logMessage);
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
