using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Design.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpEntityFrameworkCoreModule)
        )]
    public class DesignEntityFrameworkCoreModule:AbpModule
    {

    }
}
