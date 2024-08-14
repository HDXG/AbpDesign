using Volo.Abp.AspNetCore.Mvc;

namespace Design.HttpApi.Extensions
{
    /// <summary>
    /// Base控制器 通用方法
    /// </summary>
    public  class DesignControllerBase: AbpControllerBase
    {
        protected string GetDemo()
        {
            return "123";
        }
    }
}
