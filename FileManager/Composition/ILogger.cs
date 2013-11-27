using System;

namespace FileManager.ui
{

    public enum LogPriority
    {
        Debug, 
        Info, 
        Warning,
        Critical
    }

    public interface ILogger
    {
        void Log(String message, LogPriority priority);
    }
}
