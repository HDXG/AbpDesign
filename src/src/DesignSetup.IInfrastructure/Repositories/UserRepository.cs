using Design.EntityFrameworkCore.Repositories;
using DesignSetup.Domain.Users;
using DesignSetup.Infrastructure.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DesignSetup.Infrastructure.Repositories
{

    public class UserRepository(IDbContextProvider<DesignSetupDbContext> dbContextProvider) : DesignEfCoreRepository<DesignSetupDbContext, User, Guid>(dbContextProvider), IUserRepository
    {

    }
}
