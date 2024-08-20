using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.Domain;
using Volo.Abp.Modularity;

namespace DesignSetup.Domain
{
    [DependsOn(
        typeof(DesignDomainModule)
        )]
    public class DesignSetupDomainModule:AbpModule
    {
    }
}
