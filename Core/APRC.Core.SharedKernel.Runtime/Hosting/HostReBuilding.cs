using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace APRC.Core.SharedKernel.Runtime.Hosting;

public static class HostReBuilding
{
    public static IHostBuilder CreateHostBuilder(string[] args, IConfigurationRoot config)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureHostConfiguration((hostconfig) => hostconfig
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("hostsettings.json", optional: true)
                .AddEnvironmentVariables(prefix: "NET_")
                .AddCommandLine(args)
                )
            .ConfigureAppConfiguration((hostingcontext, appconfig) =>
                {
                    appconfig
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddEnvironmentVariables(prefix: "NET_")
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{hostingcontext.HostingEnvironment.EnvironmentName}.json", true, true)
                        .AddCommandLine(args);

                    config = appconfig.Build();
                    Environment = hostingcontext.HostingEnvironment;
                })
            //.ConfigureServices((_, services) => services.AddHostedService<AppLifetimeHostedService>())
            .ConfigureLogging((loggingconfig) => loggingconfig.ClearProviders())
                .UseSerilog((context, services, Configuration) => Configuration
                    .ReadFrom.Services(services)
                    .MinimumLevel.Verbose()
                    //.Enrich.FromLogContext()
                    .Enrich.FromGlobalLogContext()
                    .Enrich.WithProcessId()
                    .Enrich.WithProcessName()
                    .Enrich.WithThreadId()
                    .Enrich.WithThreadName()
                    .WriteTo.Console()
                    .WriteTo.Seq("http://localhost:5341/")
                )
                ;
    }
}
