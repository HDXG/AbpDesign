using Volo.Abp.AspNetCore;
using Volo.Abp.Modularity;

namespace Design.HttpApi
{
    [DependsOn(
         typeof(AbpAspNetCoreModule)
        )]
    public class DesignAspNetCoreModule:AbpModule
    {

    }
}
