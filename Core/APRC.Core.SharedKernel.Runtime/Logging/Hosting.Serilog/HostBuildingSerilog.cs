using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace APRC.Core.SharedKernel.GlobalServices.Logging.Hosting.Serilog
{
    public static class HostBuildingSerilog
    {
        public static IHostBuilder CreateHostBuilderSerilog(this IHostBuilder hostBuilder)//,
                                                                                          //Func<LogEvent, bool> exclusionpredicate = null,
                                                                                          //Func<LogEvent, bool> inclusionpredicate = null,
                                                                                          //params ILogEventFilter[] filters)
        {
            return hostBuilder
                .ConfigureLogging((loggingconfig) => loggingconfig.ClearProviders())
                .UseSerilog((context, services, Configuration) => Configuration
                    .ReadFrom.Services(services)
                    .MinimumLevel.Verbose()
                    //.Filter.ByIncludingOnly(inclusionpredicate)
                    //.Filter.ByExcluding(exclusionpredicate)
                    //.Filter.With(filters)
                    ////.Enrich.FromLogContext()
                    .Enrich.FromGlobalLogContext()
                    .Enrich.WithProcessId()
                    .Enrich.WithProcessName()
                    .Enrich.WithThreadId()
                    .Enrich.WithThreadName()
                    .WriteTo.Console()
                    .WriteTo.Seq("http://localhost:5341/"));
        }
    }
}
