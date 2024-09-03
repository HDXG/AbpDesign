using Design.EntityFrameworkCore.Repositories;
using DesignSetup.Domain.SysUserRoles;
using DesignSetup.Infrastructure.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DesignSetup.Infrastructure.Repositories
{
    public class SysUserRoleRepository(IDbContextProvider<DesignSetupDbContext> dbContextProvider):DesignEfCoreRepository<DesignSetupDbContext,SysUserRole,Guid>(dbContextProvider),ISysUserRoleRepository
    {

    }
}
