using Design.Application.Contracts;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Design.Application
{
    [DependsOn(
        typeof(AbpDddApplicationModule),
        typeof(DesignApplicationContractsModule)
    )]
    public class DesignApplicationModule:AbpModule
    {

    }
}
