using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DesignAspNetCore.JwtExtensions
{
    /// <summary>
    /// jwt添加至注册服务中
    /// </summary>
    public static class JwtAddService
    {
        /// <summary>
        /// 注册jwt服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigurationJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                //取出配置的私钥
                var SecretKeyDemo = Encoding.UTF8.GetBytes(configuration["AuthenticationDemo:SecretKeyDemo"] ?? "");
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    //验证发布者
                    ValidateIssuer = true,
                    ValidIssuer = configuration["AuthenticationDemo:IssuerDemo"],
                    //验证接收者
                    ValidateAudience = true,
                    ValidAudience = configuration["AuthenticationDemo:AudienceDemo"],
                    //验证是否过期
                    ValidateLifetime = true,
                    //验证私钥
                    IssuerSigningKey = new SymmetricSecurityKey(SecretKeyDemo)
                };
            });
        }
    }
}
