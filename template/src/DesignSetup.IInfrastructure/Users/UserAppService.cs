using Design.Application.Contracts.Services;
using Design.Application.Services;
using DesignSetup.Domain.Users;
using DesignSetup.Infrastructure.EntityFrameworkCore;
using DesignSetup.Infrastructure.Users.Dtos;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EntityFrameworkCore;

namespace DesignSetup.Infrastructure.Users
{
    public  interface IUserAppService : IDedsiApplicationService
    {
        Task<List<UserDto>> GetUsers();
    }
    public class UserAppService(IUserRepository userRepository) : DesignApplicationService,IUserAppService
    {
        public async Task<List<UserDto>> GetUsers()
        {
           return ObjectMapper.Map<List<User>,List<UserDto>>(await userRepository.GetListAsync());
        }
    }
}
