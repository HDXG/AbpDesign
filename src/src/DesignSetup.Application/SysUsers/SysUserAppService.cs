using Design.Application.Contracts.Services;
using Design.Application.Services;
using DesignSetup.Application.SysUsers.Dtos;
using DesignSetup.Domain.SysUsers;

namespace DesignSetup.Application.SysUsers
{
    public interface ISysUserAppService: IDedsiApplicationService
    {
        Task<SysUser> InsertUserAsync(SysUserDto t);
        Task<PagedResultOutPut<SysUserDto>> GetPagedResultAsync();
    }
    public class SysUserAppService(ISysUserRepository _sysUserRepository) : DesignApplicationService, ISysUserAppService
    {
        public async Task<PagedResultOutPut<SysUserDto>> GetPagedResultAsync()
        {
            var data = await _sysUserRepository.GetPagedListAsync(x => x.UserName.Contains(""), a => a.CreateTime);
            List<SysUserDto> list = ObjectMapper.Map<List<SysUser>, List<SysUserDto>>(data.Item2);
            return new PagedResultOutPut<SysUserDto>(data.Item1, list);
        }

        public async Task<SysUser> InsertUserAsync(SysUserDto t)
        {
            t.Id=Guid.NewGuid();
            return await _sysUserRepository.InsertAsync(ObjectMapper.Map<SysUserDto, SysUser>(t));
        }
    }
}
