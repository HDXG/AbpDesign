using Design.EntityFrameworkCore.Repositories;
using DesignSetup.Domain.Serilogs;
using DesignSetup.Infrastructure.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DesignSetup.Infrastructure.Repositories
{
    public class SerilogRepository(IDbContextProvider<DesignSetupDbContext> provider):DesignEfCoreRepository<DesignSetupDbContext, Serilog, int>(provider),ISerilogRepository
    {

    }
}
