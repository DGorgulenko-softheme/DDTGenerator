using System;
using System.IO;

namespace ChangeGen_v2
{
    static class Logger
    {
        private static readonly object _lock = new object();

        public static void Log(string logMessage, LogLevel level, string serverIP)
        {
            lock (_lock)
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    w.WriteLine("[{0}][{1}][{2}]: {3}", level.ToString(), serverIP, DateTime.Now.ToString(), logMessage);
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
        public static void Log(string logMessage, string serverIP)
        {
            Log(logMessage, LogLevel.Info, serverIP);
        }

        public enum LogLevel
        {
            Info,
            Warning,
            Error
        }
    }
}
