using Design.HttpApi;
using DesignSetup.HttpApi;
using DesignSetup.Infrastructure;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace DesignSetup.Host
{
    [DependsOn(
        typeof(DesignSetupHttpApiModule),
        typeof(DesignSetupInfrastructureModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule)
        )]
    public class DesignSetupHostModule:AbpModule
    {
        /// <summary>
        /// 注册服务内容
        /// </summary>
        /// <param name="context"></param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSwaggerGen();
        }

        /// <summary>
        /// 配置中间件 以及启动内容
        /// </summary>
        /// <param name="context"></param>
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
               
            }
            app.UseHttpsRedirection();
            app.UseCorrelationId();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseRouting();
            app.UseCors();
            app.UseConfiguredEndpoints(option =>
            {

            });
        }
    }
}
