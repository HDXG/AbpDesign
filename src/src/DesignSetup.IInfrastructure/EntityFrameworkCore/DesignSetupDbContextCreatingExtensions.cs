using DesignSetup.Domain;
using DesignSetup.Domain.Serilogs;
using DesignSetup.Domain.SysMenuPermissiones;
using DesignSetup.Domain.SysRoleMenus;
using DesignSetup.Domain.SysRoles;
using DesignSetup.Domain.SysUserRoles;
using DesignSetup.Domain.SysUsers;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace DesignSetup.Infrastructure.EntityFrameworkCore
{

    public static class DesignSetupDbContextCreatingExtensions
    {
        public static void ConfigureProjectName(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<SysUser>(b =>
            {
                b.ToTable("SysUser", DesignSetupDomainOptions.DbTablePrefix);
                b.HasKey(a => a.Id);
            });

            builder.Entity<SysMenuPermissions>(b =>
            {
                b.ToTable("SysMenuPermissions", DesignSetupDomainOptions.DbTablePrefix);
                b.HasKey(a => a.Id);
            });

            builder.Entity<SysRoleMenu>(b =>
            {
                b.ToTable("SysRoleMenu", DesignSetupDomainOptions.DbTablePrefix);
                b.HasKey(a => a.Id);
            });

            builder.Entity<SysRole>(b =>
            {
                b.ToTable("SysRole", DesignSetupDomainOptions.DbTablePrefix);
                b.HasKey(a => a.Id);
            });
            builder.Entity<SysUserRole>(b =>
            {
                b.ToTable("SysUserRole", DesignSetupDomainOptions.DbTablePrefix);
                b.HasKey(a => a.Id);
            });

            builder.Entity<Serilog>(b =>
            {
                b.ToTable("Serilog", "dbo");
                b.HasKey(a => a.Id);
            });
        }
    }
}
