using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapoco.Common
{
    delegate void LogReportEventHandler(object sender, LogReportEventArgs e);

    class LogReportEventArgs
    {
        public readonly DateTime DateTime = DateTime.Now;
        public readonly Exception Excetpion;
        public readonly LogLevel Level;
        public readonly string Message;

        public LogReportEventArgs(Exception ex, LogLevel level = LogLevel.Error)
        {
            this.Excetpion = ex;
            this.Level = level ;
            this.Message = ex.Message;
        }

        public LogReportEventArgs(string message, LogLevel level = LogLevel.Information)
        {
            this.Excetpion = null;
            this.Level = level;
            this.Message = message;
        }

        public override string ToString()
        {
            return DateTime.ToString("hh:mm:ss") + " [" + Level + "] " + Message;
        }
    }


    enum LogLevel
    {
        Information,
        Warning,
        Error,
        Fatal
    }
}
