using Design.EntityFrameworkCore.Repositories;
using DesignSetup.Domain.SysRoleMenus;
using DesignSetup.Infrastructure.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DesignSetup.Infrastructure.Repositories
{
    public class SysRoleMenuRepository(IDbContextProvider<DesignSetupDbContext> dbContextProvider): DesignEfCoreRepository<DesignSetupDbContext,SysRoleMenu,Guid>(dbContextProvider),ISysRoleMenuRepository
    {

    }
}
