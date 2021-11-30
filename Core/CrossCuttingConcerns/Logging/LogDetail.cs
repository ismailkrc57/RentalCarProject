using System.Collections.Generic;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;

namespace Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string MethodName { get; set; }
        public List<LogParameter> LogParameters { get; set; }
        
    }
}