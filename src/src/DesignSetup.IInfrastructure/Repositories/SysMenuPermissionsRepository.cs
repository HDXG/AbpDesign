﻿using Design.EntityFrameworkCore.Repositories;
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
            using (var db=await dbContextProvider.GetDbContextAsync())
            {
                string sql = $@"select  distinct p.Identification
                             from SysUserRole as u inner join SysRole as ro on(u.RoleId=ro.Id)
                             inner join SysRoleMenu as r on(r.RoleId=ro.Id)
                             inner join SysMenuPermissions as p on(r.MenuId=p.Id)
                             where ro.IsDelete=1 and ro.IsStatus=1 and p.IsDelete=1 and p.IsStatus=1
                             and p.MenuType=0 and u.UserId=@UserId";
                return await db.Database.SqlQueryRaw<string>(sql, new SqlParameter("@UserId", Id)).ToListAsync();
            }
        }

        public async Task<List<SysMenuPermissions>> GetUserRoleIdMenuList(Guid Id)
        {
            using (var db=await dbContextProvider.GetDbContextAsync())
            {
                string sql = $@"select distinct p.*
                        from SysUserRole as u inner join SysRole as ro on(u.RoleId=ro.Id)
                        inner join SysRoleMenu as r on(r.MenuId=ro.Id)
                        inner join SysMenuPermissions as p on(r.MenuId=p.Id)
                        where ro.IsDelete=1 and ro.IsStatus=1 and p.IsDelete=1 and p.IsStatus=1
                        and p.MenuType=1 and u.UserId=@UserId order by p.CreateTime asc";
                return await db.Database.SqlQueryRaw<SysMenuPermissions>(sql, new SqlParameter("@UserId", Id)).ToListAsync();
            }
                
        }
    }
}
