using Design.Application.Contracts.Services;
using Design.Application.Services;
using DesignSetup.Application.SysUsers.Dtos;
using DesignSetup.Domain.SysUsers;

namespace DesignSetup.Application.SysUsers
{
    public interface ISysUserAppService: IDedsiApplicationService
    {
        Task<PagedResultOutPut<SysUserDto>> InsertUserAsync(SysUserDto t);
        Task<PagedResultOutPut<SysUserDto>> UpdateGetPagedResultAsync(SysUserDto t);
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

        public async Task<PagedResultOutPut<SysUserDto>> InsertUserAsync(SysUserDto t)
        {
            t.Id=Guid.NewGuid();
            await _sysUserRepository.InsertAsync(ObjectMapper.Map<SysUserDto, SysUser>(t));
            return await GetPagedResultAsync();
        }

        public async Task<PagedResultOutPut<SysUserDto>> UpdateGetPagedResultAsync(SysUserDto t)
        {
            await _sysUserRepository.UpdateAsync(ObjectMapper.Map<SysUserDto,SysUser>(t));
            return await GetPagedResultAsync();
        }
    }
}
