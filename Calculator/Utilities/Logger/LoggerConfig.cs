namespace Calculator.Utilities.Logger
{
    public class LoggerConfig
    {
        public Dictionary<LogLevel, bool> LogLevelEnabled { get; set; } = new()
        {
            [LogLevel.Information] = true
        };
    }
}
