using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace AbpDesign.Application.Contracts
{
    [DependsOn(
        typeof(AbpDddApplicationContractsModule)
        )]
    public class DesignApplicationContractsModule:AbpModule
    {

    }
}
