using DesignSetup.Domain;
using DesignSetup.Domain.SysMenuPermissiones;
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

        }
    }
}
