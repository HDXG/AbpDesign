using Volo.Abp.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Mvc;
namespace Design.HttpApi.Extensions
{
    /// <summary>
    /// Base控制器 通用方法
    /// </summary>
    public  class DesignControllerBase: AbpControllerBase
    {
        protected FileContentResult FileByExcel(byte[] bytes, string fileName)
        {
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

    }
}
