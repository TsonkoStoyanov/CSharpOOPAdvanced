
using System.Linq;

namespace SOLIDLogger.Loggers
{
    using Contracts;

    public class LogFile : ILogFile
    {
        public int Size { get; private set; }

        public void Write(string message) => this.Size += message.Where(char.IsLetter).Sum(c => c);
    }
}