using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    //.WithAbpExposedHeaders()
                    //.AllowAnyHeader()
                    //.AllowAnyMethod()
                    //.AllowCredentials();
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
            }).AddJsonOptions(options => {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                //空字段不响应Response
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                //时间格式化响应
                options.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter("yyyy-MM-dd HH:mm:ss"));
            });
        }

        #endregion
    }
    public class DateTimeJsonConverter : JsonConverter<DateTime>
    {
        private readonly string Format;
        public DateTimeJsonConverter(string format)
        {
            Format = format;
        }
        public override void Write(Utf8JsonWriter writer, DateTime date, JsonSerializerOptions options)
        {
            writer.WriteStringValue(date.ToString(Format));
        }
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString(), Format, null);
        }
    }
}
