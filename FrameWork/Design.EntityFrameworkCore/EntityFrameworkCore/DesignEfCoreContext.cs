using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Design.EntityFrameworkCore.EntityFrameworkCore
{
    public abstract class DesignEfCoreContext<TDbContext>(DbContextOptions<TDbContext> options)
        :AbpDbContext<TDbContext>(options), IDesignEfCoreContext
        where TDbContext : DbContext,IDesignEfCoreContext
    {

    }
}
