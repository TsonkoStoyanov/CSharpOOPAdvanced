
using SOLIDLogger.Loggers.Enums;

namespace SOLIDLogger.Appenders
{
    using System;
    using Contracts;
    using Layouts.Contracts;


    public class ConsoleAppender : Appender
    {

        public ConsoleAppender(ILayout layout)
            : base(layout)
        {

        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                this.MessageCount++;
                Console.WriteLine(string.Format(this.Layout.Format, dateTime, reportLevel, message));
            }
        }

        public override string ToString()
        {
            return String.Format("Appender type: {0}, Layout type: {1}, Report level: {2}, Messages appended: {3}", 
                this.GetType().Name, 
                this.Layout.GetType().Name, 
                this.ReportLevel.ToString().ToUpper(), 
                this.MessageCount);
            
        }
    }
}