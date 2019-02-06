using System;
using SOLIDLogger.Appenders.Contracts;
using SOLIDLogger.Layouts.Contracts;
using SOLIDLogger.Loggers;

namespace SOLIDLogger.Appenders.Factory
{
    public class AppenderFactory : IAppenderFactory
    {
        public Appender CreateAppender(string type, ILayout layout)
        {
            switch (type)
            {
                case "ConsoleAppender":
                    return new ConsoleAppender(layout);
                case "FileAppender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type!");
                    
            }
        }
    }
}