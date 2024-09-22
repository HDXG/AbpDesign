using Design.EntityFrameworkCore;
using DesignSetup.Domain;
using DesignSetup.Infrastructure.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
        }
    }
}
