using Design.Application;
using Design.EntityFrameworkCore;
using DesignSetup.Domain;
using DesignSetup.Infrastructure.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace DesignSetup.Infrastructure
{
    [DependsOn(
         typeof(DesignSetupDomainModule),
         typeof(DesignApplicationModule),
         typeof(DesignEntityFrameworkCoreModule)
       
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
