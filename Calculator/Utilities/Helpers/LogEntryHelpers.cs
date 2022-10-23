using Calculator.Utilities.SQL.Models;

namespace Calculator.Utilities.Helpers
{
    public static class LogEntryHelpers
    {
        public static LogEntry GenerateLogEntry(string operation, string[]? args)
        {
            var entry = new LogEntry
            {
                Operation = operation,
                TimeStamp = DateTime.UtcNow,
                Request = args?.Select(x => x.ToString()).Aggregate((x, y) => $"{x}, {y}") ?? "",
            };
            return entry;
        }
        public static LogEntry GenerateLogEntry(string operation, decimal[]? args)
        {
            var convertedArgs = args?.Select(x => $"{x}").ToArray();
            return GenerateLogEntry(operation, convertedArgs);
        }
    }
}
