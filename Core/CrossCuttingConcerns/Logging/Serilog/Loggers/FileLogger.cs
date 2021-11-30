using Serilog;
using Serilog.Formatting.Compact;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class FileLogger : SerilogManager
    {
        public FileLogger() : base(new LoggerConfiguration()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger())
        {
        }
    }
}