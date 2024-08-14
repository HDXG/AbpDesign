using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Design.EntityFrameworkCore.EntityFrameworkCore
{
    public abstract class DesignEfCoreContext<TDbContext>(DbContextOptions<TDbContext> options)
        :AbpDbContext<TDbContext>(options), IAbpEfCoreDbContext
        where TDbContext : DbContext,IDesignEfCoreContext
    {

    }
}
