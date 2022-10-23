using Calculator.Utilities.SQL.Models;

namespace Calculator.Utilities.Helpers
{
    public static class LogEntryHelpers
    {
        public static LogEntry GenerateLogEntry(string operation, params object[]? args)
        {
            var entry = new LogEntry
            {
                Operation = operation,
                TimeStamp = DateTime.UtcNow,
                Request = args?.Select(x => x.ToString()).Aggregate((x, y) => $"{x}, {y}") ?? "",
            };
            return entry;
        }
    }
}
