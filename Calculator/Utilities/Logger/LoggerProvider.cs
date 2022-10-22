using Microsoft.Extensions.Options;
using System.Collections.Concurrent;

namespace Calculator.Utilities.Logger
{
    [ProviderAlias("SQLLogger")]
    public class LoggerProvider : ILoggerProvider
    {
        private readonly IDisposable _disposeToken;
        private LoggerConfig _config;
        private readonly ConcurrentDictionary<string, ILogger> _loggers = new(StringComparer.OrdinalIgnoreCase);  

        //turns out injecting flat config will make builder not resolve it at runtime from app settings
        public LoggerProvider(IOptionsMonitor<LoggerConfig> config)
        {
            _config = config.CurrentValue;
            _disposeToken = config.OnChange(conf => _config = conf);
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, new Logger(categoryName, _config));
        }

        public void Dispose()
        {
            _loggers.Clear();
            _disposeToken?.Dispose();
        }
    }
}
