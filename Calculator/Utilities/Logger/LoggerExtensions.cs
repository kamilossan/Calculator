using System.Runtime.ConstrainedExecution;

namespace Calculator.Utilities.Logger
{
    public static class LoggerExtensions
    {
        public static void LogSQL(this ILogger logger, string message, params object?[] args)
        {
            logger.LogInformation(Logger.SQL_EVENTID, message, args);
        }
    }
}
