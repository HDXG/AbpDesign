using System.Text.Json;
using System.Text.Json.Serialization;
using DesignAspNetCore.Filter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesignAspNetCore.Extensions
{
    public static class AspNetCoreExtensions
    {
        #region 跨域

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
    //进行返回时间格式化
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
