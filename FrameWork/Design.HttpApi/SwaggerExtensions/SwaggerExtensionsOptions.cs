using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace DesignAspNetCore.SwaggerExtensions
{
    public   class SwaggerExtensionsOptions
    {
       public string apiServiceName { get; set; }
       public List<SwaggerOptions> swaggerInfo { get; set; }
    }

    public class SwaggerOptions
    {
        /// <summary>
        /// /swgger/xxx/swagger.json
        /// </summary>
        public string ServiceName { get; set;}

        /// <summary>
        /// 配置swagger信息
        /// Title 标题/分组标题
        /// Version 版本号
        /// Description 详细信息
        /// </summary>
        public OpenApiInfo openApiInfos { get; set;}
    }
}
