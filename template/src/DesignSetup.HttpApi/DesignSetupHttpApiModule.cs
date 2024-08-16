using Design.HttpApi;
using DesignSetup.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore;
using Volo.Abp.Modularity;

namespace DesignSetup.HttpApi
{
    [DependsOn(
        typeof(AbpAspNetCoreModule),
        typeof(DesignHttpApiModule),
        typeof(DesignSetupDomainModule)
        )]
    public class DesignSetupHttpApiModule: AbpModule
    {
        //执行预配置逻辑  
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(DesignSetupHttpApiModule).Assembly);
            });
        }
    }
}
