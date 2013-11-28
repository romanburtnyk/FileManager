using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using FileManager.ui;

// ReSharper disable CheckNamespace
namespace FileManager.ui
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// Implementation of the ILog and ILogExtended interfaces using
    /// <see cref="Debug"/>.
    /// </summary>
    public class DebugLogger : ILog
    {
        private const string ErrorText = "ERROR";
        private const string WarnText = "WARN";
        private const string InfoText = "INFO";

        public DebugLogger()
        {
        }

        private string CreateLogMessage(string format, params object[] args)
        {
            return string.Format("[{0}] {1}", DateTime.Now.ToString("o"), string.Format(format, args));
        }

        public void Info(string format, params object[] args)
        {
            Debug.WriteLine(CreateLogMessage(format, args), InfoText);
        }

        public void Warning(string format, params object[] args)
        {
            Debug.WriteLine(CreateLogMessage(format, args), WarnText);
        }


        public void Error(string format, params object[] args)
        {
            Debug.WriteLine(CreateLogMessage(format, args), ErrorText);
        }

        public void Error(Exception exception, string format, params object[] args)
        {
            Debug.WriteLine(CreateLogMessage(format + " - Exception = " + exception.ToString(), args), ErrorText);
        }
    }
}
