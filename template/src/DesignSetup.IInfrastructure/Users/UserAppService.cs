using Design.Application.Contracts.Services;
using Design.Application.Services;
using DesignSetup.Domain.Users;
using DesignSetup.Infrastructure.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EntityFrameworkCore;

namespace DesignSetup.Infrastructure.Users
{
    public  interface IUserAppService : IDedsiApplicationService
    {
        Task<List<User>> GetUsers();
    }
    public class UserAppService(IUserRepository userRepository) : DesignApplicationService,IUserAppService
    {
        public async Task<List<User>> GetUsers()
        {
           return await userRepository.GetListAsync();
        }
    }
}
