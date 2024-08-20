using Design.Application;
using Design.Application.Contracts;
using DesignSetup.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace DesignSetup.Application
{
    [DependsOn(
         typeof(DesignApplicationModule),
         typeof(DesignApplicationContractsModule),
         typeof(DesignSetupInfrastructureModule)

        )]
    public class DesignSetupApplicationModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<DesignSetupApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<DesignSetupApplicationModule>(validate: true);
            });
        }
    }
}
