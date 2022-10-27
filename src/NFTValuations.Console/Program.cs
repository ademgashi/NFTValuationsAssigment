using Lamar.Microsoft.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NFTValuations.Console;


using IHost host = CreateHostBuilder(args).ConfigureAppConfiguration(cfg =>
    {
        cfg.AddJsonFile("appsettings.json");
    })
    .Build();
using var scope = host.Services.CreateScope();

var logger = host.Services.GetRequiredService<ILogger<Program>>();
logger.LogDebug("Host created.");

var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<App>().Run(args);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

static IHostBuilder CreateHostBuilder(string[] args) =>

    Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
            IHostEnvironment env = hostingContext.HostingEnvironment;

            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            //config.AddJsonFile("secrets/appsettings.secrets.json", optional: true);

            config.AddEnvironmentVariables();

            if (args != null)
            {
                config.AddCommandLine(args);
            }
        })
        .ConfigureServices((ctx, svc) => Startup.ConfigureServices(svc, ctx.Configuration))
        .UseLamar((ctx, svc) => Startup.ConfigureContainer(svc, ctx.Configuration));
