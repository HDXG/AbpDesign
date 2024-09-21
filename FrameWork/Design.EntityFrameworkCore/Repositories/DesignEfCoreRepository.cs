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
    public abstract class DesignEfCoreRepository<TDbContext, TEntity, TKey>(IDbContextProvider<TDbContext> dbContextProvider): EfCoreRepository<TDbContext, TEntity, TKey>(dbContextProvider),IDesignRepository<TEntity, TKey> where TDbContext : IDesignEfCoreContext where TEntity : class, IEntity<TKey>
    {
       
        public  async Task<(int, List<TEntity>)> GetPagedListAsync<Key>(int skipCount, int taskCount, Expression<Func<TEntity, bool>> wherePredicate, Func<TEntity, Key> orderPredicate,bool isReverse=true)
        {
            List<TEntity> Queryable =await (await GetQueryableAsync()).Where(wherePredicate).ToListAsync();
            var count =  Queryable.Count();
            var  Queryable2 =(isReverse ? Queryable.OrderByDescending(orderPredicate) : Queryable.OrderBy(orderPredicate));
            return (count, Queryable2.Skip(skipCount).Take(taskCount).ToList());
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
        public virtual Task<(int, List<TEntity>)> GetPagedListAsync<Key>(Expression<Func<TEntity, bool>> wherePredicate, Func<TEntity, Key> orderPredicate, bool isReverse = true, int pageIndex = 1, int pageSize = 10)
        {
            return GetPagedListAsync((pageIndex - 1) * pageSize, pageSize, wherePredicate, orderPredicate, isReverse);
        }
    }

    

}
