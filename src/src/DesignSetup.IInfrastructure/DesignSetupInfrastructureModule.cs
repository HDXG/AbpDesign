using System.Configuration;
using Design.EntityFrameworkCore;
using DesignSetup.Domain;
using DesignSetup.Infrastructure.EntityFrameworkCore;
using DesignSetup.Infrastructure.SqlSugar;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using Volo.Abp.Modularity;

namespace DesignSetup.Infrastructure
{
    [DependsOn(
         typeof(DesignEntityFrameworkCoreModule),
         typeof(DesignSetupDomainModule)
        )]
    public class DesignSetupInfrastructureModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DesignSetupDbContext>(options =>
            {
                options.AddDefaultRepositories(true);
            });

            var configuration = context.Services.GetConfiguration();

            var connectionConfig = new ConnectionConfig
            {
                DbType = DbType.SqlServer,
                ConnectionString = configuration.GetConnectionString(DesignSetupDomainOptions.ConnectionStringName),
                IsAutoCloseConnection = true,
                ConfigureExternalServices = SqlSugarConfigureExternalServices.Get()
            };
            context.Services.AddScoped<ISqlSugarClient>(s => new SqlSugarClient(connectionConfig));

            //context.Services.AddSingleton<IRabbitMQService, RabbitMQService>();
        }
    }
}
