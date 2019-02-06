
namespace SOLIDLogger.Appenders.Contracts
{
    using Layouts.Contracts;

    public interface IAppenderFactory
    {
        Appender CreateAppender(string type, ILayout layout);
    }
}