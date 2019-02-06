
using SOLIDLogger.Appenders;
using SOLIDLogger.Core;
using SOLIDLogger.Core.Contracts;
using SOLIDLogger.Layouts;
using SOLIDLogger.Loggers;
using SOLIDLogger.Loggers.Enums;

namespace SOLIDLogger
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
