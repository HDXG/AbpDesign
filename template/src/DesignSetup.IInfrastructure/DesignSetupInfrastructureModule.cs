using Design.Application;
using Design.EntityFrameworkCore;
using DesignSetup.Domain;
using DesignSetup.Infrastructure.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace DesignSetup.Infrastructure
{
    [DependsOn(
         typeof(DesignApplicationModule),
         typeof(DesignEntityFrameworkCoreModule),
         typeof(DesignSetupDomainModule)
        )]
    public class DesignSetupInfrastructureModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<DesignSetupInfrastructureModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<DesignSetupInfrastructureModule>(validate: true);
            });
            context.Services.AddAbpDbContext<DesignSetupDbContext>(options =>
            {
                options.AddDefaultRepositories(true);
            });
        }


       
    }
}
