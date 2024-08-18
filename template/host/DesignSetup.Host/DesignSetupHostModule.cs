using System.Reflection;
using Design.HttpApi;
using DesignAspNetCore.Extensions;
using DesignAspNetCore.SwaggerExtensions;
using DesignSetup.Application;
using DesignSetup.Domain;
using DesignSetup.HttpApi;
using DesignSetup.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace DesignSetup.Host
{
    [DependsOn(
        typeof(DesignSetupApplicationModule),
        typeof(DesignAspNetCoreModule),
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
            var hostEnvironment = context.Services.GetAbpHostEnvironment();
            var configuration = context.Services.GetConfiguration();
            //注册数据库内容
            Configure<AbpDbContextOptions>(options =>
            {
                options.Configure(dbConfigContext =>
                {// 本地研发环境 - 输出到控制台
                    if (hostEnvironment.EnvironmentName == "Development")
                    {
                        dbConfigContext.DbContextOptions.LogTo(Serilog.Log.Information, new[] { DbLoggerCategory.Database.Command.Name }).EnableSensitiveDataLogging();
                    }
                    dbConfigContext.UseSqlServer();
                });
            });


            Configure<AbpAuditingOptions>(options =>
            {
                options.ApplicationName = DesignSetupDomainOptions.ApplicationName;
                options.IsEnabledForGetRequests = true;
            });

            context.Services.ConfigurationFilters();
            // 跨域
            context.Services.ConfigurationUseCore(configuration);
            context.Services.ConfigurationSwagger(swaggerConfiguration());
           
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
                app.UseDeveloperExceptionPage();
            }else
                app.UseHsts();
            app.UseHttpsRedirection();
            app.UseCorrelationId();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();

            app.UseSwagger(swaggerConfiguration());
            app.UseAuditing();
            app.UseConfiguredEndpoints(option =>
            {

            });
        }


        public SwaggerExtensionsOptions swaggerConfiguration()
        {
            return new SwaggerExtensionsOptions()
            {
                apiServiceName = "DesignSetup",
                swaggerInfo = new List<SwaggerOptions>() {
                    new SwaggerOptions() {ServiceName="setup",
                    openApiInfos=new OpenApiInfo(){Title="DesignSetup",Description="DesignSetup详情",Version="1.0" } } }
            };
        }
    }
}
