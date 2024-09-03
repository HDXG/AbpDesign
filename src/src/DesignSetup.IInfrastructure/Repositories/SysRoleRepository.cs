using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.EntityFrameworkCore.Repositories;
using DesignSetup.Domain.SysRoles;
using DesignSetup.Infrastructure.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DesignSetup.Infrastructure.Repositories
{
    public class SysRoleRepository(IDbContextProvider<DesignSetupDbContext> dbContextProvider): DesignEfCoreRepository<DesignSetupDbContext,SysRole,Guid>(dbContextProvider), ISysRoleRepository
    {
    }
}
