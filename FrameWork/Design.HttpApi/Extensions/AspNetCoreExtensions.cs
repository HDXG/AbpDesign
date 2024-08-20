using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DesignAspNetCore.Filter;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DesignAspNetCore.Extensions
{
    public static class AspNetCoreExtensions
    {
        #region 跨域内容

        /// <summary>
        /// 服务注册----跨域
        /// </summary>
        /// <param name="Services"></param>
        /// <param name="configuration"></param>
        public static void ConfigurationUseCore(this IServiceCollection Services, IConfiguration configuration)
        {
            Services.AddCors(options =>
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
        }

        #endregion
        #region 添加过滤器

        /// <summary>
        /// 统一返回格式过滤器
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigurationFilters(this IServiceCollection services)
        {
            services.AddControllers(option =>
            {
                option.Filters.Add<HttpResponseExceptionFilter>();
                option.Filters.Add<HttpResponseSuccessFilter>();
            });
        }

        #endregion
    }
}
