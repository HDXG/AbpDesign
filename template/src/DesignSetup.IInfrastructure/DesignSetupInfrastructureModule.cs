using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.Domain;
using Design.EntityFrameworkCore;
using DesignSetup.Domain;
using Volo.Abp.Modularity;

namespace DesignSetup.Infrastructure
{
    [DependsOn(
        typeof(DesignEntityFrameworkCoreModule),
        typeof(DesignSetupDomainModule)
        )]
    public class DesignSetupInfrastructureModule:AbpModule
    {
    }
}
