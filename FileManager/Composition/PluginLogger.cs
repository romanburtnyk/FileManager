using System.Diagnostics;
using FileManager.Intf;
using FileManager.ui.Composition;

namespace FileManager.ui
{
    internal class PluginLogger : ILogger
    {
        public void Log(string message, LogPriority priority)
        {
            Debug.WriteLine(message);
        }
    }
}