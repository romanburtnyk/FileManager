using System;
using System.Diagnostics;

namespace FileManager.ui
{
    public class TraceLogger : ILog
    {
        private const string ErrorText = "ERROR";
        private const string WarnText = "WARN";
        private const string InfoText = "INFO";

        public TraceLogger()
        {
        }

        private string CreateLogMessage(string format, params object[] args)
        {
            return string.Format("[{0}] {1}", (object) DateTime.Now.ToString("o"), (object) string.Format(format, args));
        }

        public void Error(Exception exception)
        {
            Trace.WriteLine(this.CreateLogMessage(exception.ToString(), new object[0]), "ERROR");
        }

        public void Info(string format, params object[] args)
        {
            Trace.WriteLine(this.CreateLogMessage(format, args), "INFO");
        }

        public void Warning(string format, params object[] args)
        {
            Trace.WriteLine(this.CreateLogMessage(format, args), "WARN");
        }

        public void Error(string format, params object[] args)
        {
            Trace.WriteLine(this.CreateLogMessage(format, args), "ERROR");
        }

        public void Error(Exception exception, string format, params object[] args)
        {
            Trace.WriteLine(this.CreateLogMessage(format + " - Exception = " + exception.ToString(), args), "ERROR");
        }
    }
}