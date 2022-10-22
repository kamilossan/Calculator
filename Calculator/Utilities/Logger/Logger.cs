using Calculator.Utilities.SQL;
using System.Runtime.ConstrainedExecution;

namespace Calculator.Utilities.Logger
{
    public class Logger : ILogger
    {
        private readonly string _loggerName;
        private readonly LoggerConfig _config;
        public const int SQL_EVENTID = 999;
        private readonly DataBaseContext _dataBase;
        public Logger(string name, LoggerConfig config, DataBaseContext dataBase)
        {
            _loggerName = name;
            _config = config;
            _dataBase = dataBase;
        }
        public IDisposable BeginScope<TState>(TState state) => default!;

        public bool IsEnabled(LogLevel logLevel)
        {
            return _config.LogLevelEnabled.ContainsKey(logLevel) && _config.LogLevelEnabled[logLevel];
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (IsEnabled(logLevel) && eventId.Id == SQL_EVENTID)
            {
                Console.WriteLine($"{_loggerName}:{state}:{logLevel}:{eventId}:{exception?.Message}"); 
            }
            return;
        }
    }
}
