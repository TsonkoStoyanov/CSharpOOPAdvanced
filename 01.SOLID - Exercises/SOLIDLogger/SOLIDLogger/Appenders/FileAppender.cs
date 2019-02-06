
namespace SOLIDLogger.Appenders
{
    using System;
    using System.IO;
    using Loggers.Contracts;
    using Loggers.Enums;
    using Layouts.Contracts;

    public class FileAppender : Appender
    {
        private const string path = "../../../log.txt";
        private readonly ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile) : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                this.MessageCount++;
                string content = string.Format(this.Layout.Format, dateTime, reportLevel, message) +
                                 Environment.NewLine;

                this.logFile.Write(content);

                File.AppendAllText(path, content);
            }
        }

        public override string ToString()
        {
            return String.Format("Appender type: {0}, Layout type: {1}, Report level: {2}, Messages appended: {3}, File size: {4}",
                this.GetType().Name,
                this.Layout.GetType().Name,
                this.ReportLevel.ToString().ToUpper(),
                this.MessageCount,
                this.logFile.Size);
        }
    }
}