using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignSetup.Domain;
using DesignSetup.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DesignSetup.Infrastructure.EntityFrameworkCore
{
    
    public static class DesignSetupDbContextCreatingExtensions
    {
        public static void ConfigureProjectName(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<User>(b =>
            {
                b.ToTable("User", DesignSetupDomainOptions.DbTablePrefix);
                b.HasKey(a => a.Id);
            });

        }
    }
}
