using Serilog;

namespace Core.CrossCuttingConcerns.Logging.Serilog
{
    public class SerilogManager
    {
        private ILogger _log;

        public SerilogManager(ILogger logger)
        {
            _log = logger;
        }

        public void Info(string logMessage, object data)
        {
            _log.Information(logMessage, data);
        }

        public void Debug(string logMessage, object data)
        {
            _log.Debug(logMessage, data);
        }

        public void Warn(string logMessage, object data)
        {
            _log.Warning(logMessage, data);
        }

        public void Fatal(string logMessage, object data)
        {
            _log.Fatal(logMessage, data);
        }

        public void Error(string logMessage, object data)
        {
            _log.Error(logMessage, data);
        }
    }
}