using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattiasCibien.Extensions.Logging.Logcat
{
    public static class LogcatLoggerExtensions
    {
        public static ILoggingBuilder AddLogcat(this ILoggingBuilder builder)
        {
            //builder.AddConfiguration();

            builder.Services.TryAddEnumerable(
                ServiceDescriptor.Singleton<ILoggerProvider, LogcatLoggerProvider>());

            //LoggerProviderOptions.RegisterProviderOptions
            //    <ColorConsoleLoggerConfiguration, ColorConsoleLoggerProvider>(builder.Services);

            return builder;
        }

        //public static ILoggingBuilder AddLogcatLogger(
        //    this ILoggingBuilder builder,
        //    Action<ColorConsoleLoggerConfiguration> configure)
        //{
        //    builder.AddColorConsoleLogger();
        //    //builder.Services.Configure(configure);

        //    return builder;
        //}
    }
}
