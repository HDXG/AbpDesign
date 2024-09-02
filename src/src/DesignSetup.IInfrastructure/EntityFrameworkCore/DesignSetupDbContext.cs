using Design.EntityFrameworkCore.EntityFrameworkCore;
using DesignSetup.Domain;
using DesignSetup.Domain.SysMenuPermissiones;
using DesignSetup.Domain.SysUsers;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;

namespace DesignSetup.Infrastructure.EntityFrameworkCore
{
    [ConnectionStringName(DesignSetupDomainOptions.ConnectionStringName)]
    public  class DesignSetupDbContext(DbContextOptions<DesignSetupDbContext> dbContextOptions):DesignEfCoreContext<DesignSetupDbContext>(dbContextOptions)
    {
        public DbSet<SysUser> sysUsers { get; set; } 
        public DbSet<SysMenuPermissions> SysMenuPermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigureProjectName();
        }

    }
}
