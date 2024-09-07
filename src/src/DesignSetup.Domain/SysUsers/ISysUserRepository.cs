using Design.Domain.Repositories;

namespace DesignSetup.Domain.SysUsers
{
    public interface ISysUserRepository: IDesignRepository<SysUser,Guid>
    {

        public Task<List<TEntity>> GetUserListAsync<TEntity>(string UserName);

    }
}
