using Design.Domain.Repositories;

namespace DesignSetup.Domain.Users
{
    public interface IUserRepository:IDesignRepository<User, Guid>
    {

    }
}
