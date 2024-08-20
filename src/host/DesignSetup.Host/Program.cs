
using Serilog;
using Serilog.Events;

namespace DesignSetup.Host
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            await builder.AddApplicationAsync<DesignSetupHostModule>();
            builder.Host
             .AddAppSettingsSecretsJson()
             .UseAutofac()
             .UseSerilog((context, services, loggerConfiguration) =>
             {
                 loggerConfiguration
                     .MinimumLevel.Information()
                     .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                     .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                     .Enrich.FromLogContext()
                     .WriteTo.Async(c => c.File(path: "Logs/logs.txt", rollingInterval: RollingInterval.Hour, retainedFileCountLimit: null))
                     .WriteTo.Async(c => c.Console());
             });
            var app=builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            return 0;
        }
    }
}
