using Design.Domain.Repositories;
using Design.EntityFrameworkCore.Repositories;
using DesignSetup.Domain.codeGenerations;
using DesignSetup.Infrastructure.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DesignSetup.Infrastructure.Repositories
{
    public class CodeGenerationRepository(IDbContextProvider<DesignSetupDbContext> provider) : ICodeGenerationRepository
    {
        public bool? IsChangeTrackingEnabled => throw new NotImplementedException();

        public async Task<List<TEntity>> GetTableSchemasDescribe<TEntity>()
        {
            var db = await provider.GetDbContextAsync();
            string sql = $@" select st.name as tableName,st.create_date,st.modify_date,sep.value as describe,
                shm.name as schemasName from sys.tables  st 
                left join sys.extended_properties  sep  on(st.object_id=sep.major_id)
                left join sys.schemas shm on(st.schema_id=shm.schema_id)
                where minor_id=0 order by create_date desc ";
            return await db.Database.SqlQueryRaw<TEntity>(sql).ToListAsync();
        }
    }
}
