using Design.EntityFrameworkCore.Repositories;
using DesignSetup.Domain.SysMenuPermissiones;
using DesignSetup.Infrastructure.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DesignSetup.Infrastructure.Repositories
{
    public class SysMenuPermissionsRepository(IDbContextProvider<DesignSetupDbContext> dbContextProvider) : DesignEfCoreRepository<DesignSetupDbContext, SysMenuPermissions, Guid>(dbContextProvider), ISysMenuPermissionsRepository
    {
    }
}
