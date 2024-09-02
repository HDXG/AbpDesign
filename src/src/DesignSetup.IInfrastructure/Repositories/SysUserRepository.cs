using Design.EntityFrameworkCore.Repositories;
using DesignSetup.Domain.SysUsers;
using DesignSetup.Infrastructure.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DesignSetup.Infrastructure.Repositories
{
    public class SysUserRepository(IDbContextProvider<DesignSetupDbContext> dbContextProvider) : DesignEfCoreRepository<DesignSetupDbContext, SysUser, Guid>(dbContextProvider), ISysUserRepository
    {
    }
}
