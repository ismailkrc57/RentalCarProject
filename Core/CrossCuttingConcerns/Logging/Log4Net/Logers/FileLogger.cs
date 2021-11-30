namespace Core.CrossCuttingConcerns.Logging.Log4Net.Logers
{
    public class FileLogger : LoggerServiceBase
    {
        public FileLogger() : base("JsonFileLogger")
        {
        }
    }
}