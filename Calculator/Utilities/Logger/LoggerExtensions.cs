using Calculator.Utilities.SQL.Models;
using Newtonsoft.Json;
using System.Runtime.ConstrainedExecution;

namespace Calculator.Utilities.Logger
{
    public static class LoggerExtensions
    {
        public static void LogSQL(this ILogger logger, LogEntry entry, LogLevel logLevel)
        {
            logger.Log(logLevel, Logger.SQL_EVENTID, JsonConvert.SerializeObject(entry));
        }
    }
}
