using Design.Domain.Repositories;
using Design.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
namespace Design.EntityFrameworkCore.Repositories
{
    public abstract class DesignEfCoreRepository<TDbContext, TEntity, TKey>(IDbContextProvider<TDbContext> dbContextProvider)
    : EfCoreRepository<TDbContext, TEntity, TKey>(dbContextProvider),
       IDesignRepository<TEntity, TKey>
    where TDbContext : IDesignEfCoreContext
    where TEntity : class, IEntity<TKey>
    {
       

        public virtual async Task<List<TEntity>> Get()
        {
            return await (await GetQueryableAsync()).ToListAsync<TEntity>();
        }


    }

    

}
