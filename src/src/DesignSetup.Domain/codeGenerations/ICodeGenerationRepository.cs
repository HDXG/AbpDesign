using Design.Domain.Repositories;
using Volo.Abp.Domain.Repositories;

namespace DesignSetup.Domain.codeGenerations
{
    public interface ICodeGenerationRepository: IRepository
    {
        /// <summary>
        /// 获得表描述 等信息
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public Task<List<TEntity>> GetTableSchemasDescribe<TEntity>();
    }
}
