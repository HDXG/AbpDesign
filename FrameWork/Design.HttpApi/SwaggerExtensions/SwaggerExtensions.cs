using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace DesignAspNetCore.SwaggerExtensions
{
    public static class SwaggerExtensions
    {
        #region swagger配置中心

        public static void ConfigurationSwagger(this IServiceCollection services, SwaggerExtensionsOptions swaggerExtensionsOptions)
        {
            services.AddSwaggerGen(
                options =>
                {
                    foreach (var item in swaggerExtensionsOptions.swaggerInfo)
                    {
                        options.SwaggerDoc(item.ServiceName,item.openApiInfos);
                    }
                    options.CustomSchemaIds(type => type.FullName);

                    var directoryInfo = new DirectoryInfo(AppContext.BaseDirectory);
                    var fileInfos = directoryInfo.GetFileSystemInfos()
                        .Where(a => a.Extension == ".xml")
                        .Where(a => a.Name.EndsWith("Application.xml"));

                    foreach (var info in fileInfos)
                    {
                        var xmlPath = Path.Combine(AppContext.BaseDirectory, info.Name);
                        options.IncludeXmlComments(xmlPath, true);
                    }
                    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, swaggerExtensionsOptions.apiServiceName + ".xml"), true);
                    options.DocInclusionPredicate((doc, api) => true);

                    options.DocInclusionPredicate((docName, description) =>
                    {
                        if (!description.TryGetMethodInfo(out MethodInfo method))
                        {
                            return false;
                        }
                        var version = method.DeclaringType.GetCustomAttributes(true).OfType<ApiExplorerSettingsAttribute>().Select(m => m.GroupName);
                        if (version.Any())
                        {
                            return version.Any(v => v == docName);
                        }
                        //获取action的特性
                        var actionVersion = method.GetCustomAttributes(true).OfType<ApiExplorerSettingsAttribute>().Select(m => m.GroupName);
                        if (actionVersion.Any())
                        {
                            return actionVersion.Any(v => v == docName);
                        }

                        return false;
                    });
                    options.AddSecurityDefinition("BearerToken", new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                        Description = "请输入Token!"
                    });

                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference { Type =       ReferenceType.SecurityScheme, Id = "BearerToken" }
                            },
                            new string[] {}
                        }
                    });
                });
        }

        public static void UseSwagger(this IApplicationBuilder app, SwaggerExtensionsOptions swaggerExtensionsOptions)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var item in swaggerExtensionsOptions.swaggerInfo)
                {
                    options.SwaggerEndpoint($"/swagger/{item.ServiceName}/swagger.json", $"{item.openApiInfos.Title}");
                }
                options.DocExpansion(DocExpansion.None);
                options.DefaultModelsExpandDepth(-1);
                options.RoutePrefix = string.Empty;  // url 中不显示swagger
            });
        }
        #endregion
    }
}
