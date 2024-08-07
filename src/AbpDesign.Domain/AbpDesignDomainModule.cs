using Volo.Abp.Modularity;
using Volo.Abp.Domain;

namespace AbpDesign.Domain
{
    [DependsOn(
        typeof(AbpDddDomainModule)    
    )]
    public class AbpDesignDomainModule:AbpModule
    {

    }
}
