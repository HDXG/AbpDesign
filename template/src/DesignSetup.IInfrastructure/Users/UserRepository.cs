using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.Domain.Repositories;
using Design.EntityFrameworkCore.Repositories;
using DesignSetup.Domain.Users;
using DesignSetup.Infrastructure.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DesignSetup.Infrastructure.Users
{
    public interface IUserRepository : IDesignRepository<User, Guid>;
    public class UserRepository(IDbContextProvider<DesignSetupDbContext> dbContextProvider) : DesignEfCoreRepository<DesignSetupDbContext, User, Guid>(dbContextProvider), IUserRepository
    {

    }
}
