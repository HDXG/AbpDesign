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
using Volo.Abp.Application.Dtos;

namespace DesignSetup.Application.Users
{
    public interface IUserAppService : IDedsiApplicationService
    {
       public Task<List<UserDto>> GetUsers();
       public Task<PagedResultOutPut<UserDto>> GetPagedResultAsync();
    }
    public class UserAppService(IUserRepository userRepository) : DesignApplicationService, IUserAppService
    {
        public async Task<PagedResultOutPut<UserDto>> GetPagedResultAsync()
        {
            var data = await userRepository.GetPagedListAsync(x => x.UserName.Contains(""),a=>a.CreateTime);
            List<UserDto> list=ObjectMapper.Map<List<User>, List<UserDto>>(data.Item2);
            return new PagedResultOutPut<UserDto>(data.Item1, ObjectMapper.Map<List<User>, List<UserDto>>(data.Item2));
        }

        public async Task<List<UserDto>> GetUsers()
        {
            return ObjectMapper.Map<List<User>, List<UserDto>>(await userRepository.GetListAsync());
        }
    }
}
