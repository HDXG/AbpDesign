using Design.HttpApi;
using DesignSetup.HttpApi;
using DesignSetup.Infrastructure;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace DesignSetup.Host
{
    [DependsOn(
        typeof(DesignSetupHttpApiModule),

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

            // 跨域
            context.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]?
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray() ?? []
                        )
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

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
