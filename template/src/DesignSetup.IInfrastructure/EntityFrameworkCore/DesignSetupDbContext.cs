using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.EntityFrameworkCore.EntityFrameworkCore;
using DesignSetup.Domain;
using DesignSetup.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;

namespace DesignSetup.Infrastructure.EntityFrameworkCore
{
    [ConnectionStringName(DesignSetupDomainOptions.ConnectionStringName)]
    public  class DesignSetupDbContext(DbContextOptions<DesignSetupDbContext> dbContextOptions):DesignEfCoreContext<DesignSetupDbContext>(dbContextOptions)
    {
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigureProjectName();
        }

    }
}
