using System;

namespace FileManager.ui
{
    static class LogManager
    {
        private static ILog ms_Logger = new NullLog();

        private class NullLog : ILog
        {
            void ILog.Info(string format, params object[] args)
            {
            }

            void ILog.Warning(string format, params object[] args)
            {
            }

            void ILog.Error(string format, params object[] args)
            {
            }

            void ILog.Error(Exception exception, string format, params object[] args)
            {
            }
        }

        public static void Configure(Func<ILog> getLogger)
        {
            var logger = getLogger();
            if (logger != null)
            {
                ms_Logger = logger;   
            }
        }

        public static void Info(string format, params object[] args)
        {
            ms_Logger.Info(format, args);
        }

        public static void Warning(string format, params object[] args)
        {
            ms_Logger.Warning(format, args);
        }

        public static void Error(string format, params object[] args)
        {
            ms_Logger.Error(format, args);
        }

    }
}