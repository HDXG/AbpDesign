
namespace DesignSetup.Host
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            await builder.AddApplicationAsync<DesignSetupHostModule>();
            var app=builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            return 0;
        }
    }
}
