using System.Linq.Expressions;
using Design.Domain.Repositories;
using Design.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace Design.EntityFrameworkCore.Repositories
{
    public abstract class DesignEfCoreRepository<TDbContext, TEntity, TKey>(IDbContextProvider<TDbContext> dbContextProvider)
    : EfCoreRepository<TDbContext, TEntity, TKey>(dbContextProvider),
       IDesignRepository<TEntity, TKey>
    where TDbContext : IDesignEfCoreContext
    where TEntity : class, IEntity<TKey>
    {
       
        public  async Task<(int, List<TEntity>)> GetPagedListAsync<Key>(int skipCount, int taskCount, Expression<Func<TEntity, bool>> wherePredicate, Func<TEntity, Key> orderPredicate,bool isReverse=true)
        {
            IQueryable<TEntity> Queryable = (await GetQueryableAsync()).Where(wherePredicate);
            var count = await Queryable.CountAsync();
            Queryable =(isReverse ? Queryable.OrderByDescending(orderPredicate) : Queryable.OrderBy(orderPredicate)).AsQueryable();
            return (count, await Queryable.Skip(skipCount).Take(taskCount).ToListAsync());
        }

        /// <summary>
        /// 默认分页内容
        /// </summary>
        /// <typeparam name="Key"></typeparam>
        /// <param name="wherePredicate"></param>
        /// <param name="orderPredicate"></param>
        /// <param name="pageIndex">默认第一页</param>
        /// <param name="pageSize">页数</param>
        /// <param name="isReverse">true 倒叙</param>
        /// <returns></returns>
        public virtual Task<(int, List<TEntity>)> GetPagedListAsync<Key>(Expression<Func<TEntity, bool>> wherePredicate, Func<TEntity, Key> orderPredicate, int pageIndex = 1, int pageSize = 10, bool isReverse = true)
        {
            return GetPagedListAsync((pageIndex - 1) * pageSize, pageSize, wherePredicate, orderPredicate, isReverse);
        }
    }

    

}
