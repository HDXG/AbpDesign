using Design.EntityFrameworkCore.Repositories;
using DesignSetup.Domain.SysUsers;
using DesignSetup.Infrastructure.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;

namespace DesignSetup.Infrastructure.Repositories
{
    public class SysUserRepository(IDbContextProvider<DesignSetupDbContext> dbContextProvider) : DesignEfCoreRepository<DesignSetupDbContext, SysUser, Guid>(dbContextProvider), ISysUserRepository
    {
        public async Task<List<TEntity>> GetUserListAsync<TEntity>(string UserName)
        {
            var db = await GetDbContextAsync();
            string sql = $@"select uu.*,isnull(stuff((select  ','+r.RoleName from SysUserRole as u inner join SysRole as r on(u.RoleId=r.Id)
                    where r.IsStatus=1 and r.IsDelete=1 and u.UserId=uu.Id
                    for xml path('')),1,1,''),'') as RoleName from SysUser as uu 
                    where uu.IsDelete=1 and 
                    uu.UserName like @UserName 
                    order by uu.CreateTime desc";
            return await db.Database.SqlQueryRaw<TEntity>(sql, new SqlParameter("@UserName", "%" + UserName + "%")).ToListAsync();
        }


    }
}
