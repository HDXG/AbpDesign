using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Design.Domain.Repositories;

namespace DesignSetup.Domain.Users
{
    public interface IUserRepository : IDesignRepository<User, Guid>
    {
    }
}
