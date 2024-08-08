using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Design.Domain
{
    [DependsOn(
        typeof(AbpDddDomainModule)
        )]
    public class DesignDomainModule:AbpModule
    {
    }
}
