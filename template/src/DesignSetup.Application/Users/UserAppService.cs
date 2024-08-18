using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
using Design.Application.Contracts.Services;
using Design.Application.Services;
using DesignSetup.Application.Users.Dtos;
using DesignSetup.Domain.Users;
using DesignSetup.Infrastructure.Repositories;

namespace DesignSetup.Application.Users
{
    public interface IUserAppService : IDedsiApplicationService
    {
        Task<List<UserDto>> GetUsers();
    }
    public class UserAppService(IUserRepository userRepository) : DesignApplicationService, IUserAppService
    {
        public async Task<List<UserDto>> GetUsers()
        {
            return ObjectMapper.Map<List<User>, List<UserDto>>(await userRepository.GetListAsync());
        }
    }
}
