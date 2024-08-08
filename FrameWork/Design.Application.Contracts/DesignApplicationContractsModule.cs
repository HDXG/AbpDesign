using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Design.Application.Contracts
{
    [DependsOn(
        typeof(AbpDddApplicationContractsModule)
        )]
    public class DesignApplicationContractsModule:AbpModule
    {

    }
}
