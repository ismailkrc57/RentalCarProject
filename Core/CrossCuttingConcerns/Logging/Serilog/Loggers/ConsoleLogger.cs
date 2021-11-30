using Serilog;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class ConsoleLogger : SerilogManager
    {
        public ConsoleLogger() : base(new LoggerConfiguration().WriteTo.Console().CreateLogger())
        {
            
        }
    }
}