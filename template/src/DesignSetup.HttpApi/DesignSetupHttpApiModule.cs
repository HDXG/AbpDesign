using Design.HttpApi;
using DesignSetup.Domain;
using DesignSetup.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.AspNetCore;
using Volo.Abp.Modularity;


namespace DesignSetup.HttpApi
{
    [DependsOn(

        typeof(DesignSetupInfrastructureModule),
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

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
           
          
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            context.GetApplicationBuilder().UseSwaggerUI();
        }
    }

   

}
