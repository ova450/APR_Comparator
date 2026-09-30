using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace APRC.Core.SharedKernel.Runtime.Hosting;

public static class HostBuilding
{
    public static IConfiguration Config { get; set; }
    public static IHostEnvironment Environ { get; set; }

    public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
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

                Config = appconfig.Build();
                Environ = hostingcontext.HostingEnvironment;
            });
}
