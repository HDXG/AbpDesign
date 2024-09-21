using Design.EntityFrameworkCore.Repositories;
using DesignSetup.Domain.SysMenuPermissiones;
using DesignSetup.Infrastructure.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DesignSetup.Infrastructure.Repositories
{
    public class SysMenuPermissionsRepository(IDbContextProvider<DesignSetupDbContext> dbContextProvider) : DesignEfCoreRepository<DesignSetupDbContext, SysMenuPermissions, Guid>(dbContextProvider), ISysMenuPermissionsRepository
    {
        public async Task<List<string>> GetUserRoleIdBtnList(Guid Id)
        {
            var db = await GetDbContextAsync();
            string sql = $@"select  distinct p.Identification
                             from SysUserRole as u inner join SysRole as ro on(u.RoleId=ro.Id)
                             inner join SysRoleMenu as r on(r.RoleId=ro.Id)
                             inner join SysMenuPermissions as p on(r.MenuId=p.Id)
                             where ro.IsDelete=1 and ro.IsStatus=1 and p.IsDelete=1 and p.IsStatus=1
                             and p.MenuType=2 and u.UserId=@UserId";
                return await db.Database.SqlQueryRaw<string>(sql, new SqlParameter("@UserId", Id)).ToListAsync();
        }

        public async Task<List<SysMenuPermissions>> GetUserRoleIdMenuList(Guid Id)
        {
            var db = await GetDbContextAsync();
            string sql = $@"select distinct me.* from SysMenuPermissions as me right join SysRoleMenu as rme on(me.Id=rme.MenuId) right join SysUserRole as ur on(rme.RoleId=ur.RoleId)  left join SysUser as u on(u.Id=ur.UserId) where me.IsDelete=1 and me.IsStatus=1 and u.IsDelete=1 and u.IsDelete=1 and me.MenuType!=2  and u.Id=@UserId order by me.[Order] asc";
                return await db.Database.SqlQueryRaw<SysMenuPermissions>(sql, new SqlParameter("@UserId", Id)).ToListAsync();
        }
    }
}
