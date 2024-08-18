using Design.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Design.Application
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(AbpDddApplicationModule),
        typeof(DesignApplicationContractsModule)
    )]
    public class DesignApplicationModule:AbpModule
    {
       
    }
}
