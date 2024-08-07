using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;


namespace AbpDesign.Domain.Repositories
{
    public interface  IDesignRepository<TEntity,TKey>: IRepository<TEntity,TKey> where TEntity : class,IEntity<TKey>
    {

    }
}
