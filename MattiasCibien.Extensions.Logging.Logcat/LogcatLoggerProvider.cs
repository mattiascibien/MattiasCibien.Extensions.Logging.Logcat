using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace MattiasCibien.Extensions.Logging.Logcat
{
    [UnsupportedOSPlatform("windows")]
    [UnsupportedOSPlatform("browser")]
    [UnsupportedOSPlatform("ios")]
    [ProviderAlias("ColorConsole")]
    internal class LogcatLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, LogcatLogger> _loggers = new(StringComparer.OrdinalIgnoreCase);


        public ILogger CreateLogger(string categoryName) =>
            _loggers.GetOrAdd(categoryName, name => new LogcatLogger(name));

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
