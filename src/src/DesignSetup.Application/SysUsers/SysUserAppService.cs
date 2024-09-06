using Design.Application.Contracts.Extensions;
using Design.Application.Contracts.Services;
using Design.Application.Services;
using DesignSetup.Application.SysUserRoles.Dtos;
using DesignSetup.Application.SysUsers.Dtos;
using DesignSetup.Application.SysUsers.InPuts;
using DesignSetup.Domain.SysRoles;
using DesignSetup.Domain.SysUserRoles;
using DesignSetup.Domain.SysUsers;
using Volo.Abp.ObjectMapping;

namespace DesignSetup.Application.SysUsers
{
    public interface ISysUserAppService: IDedsiApplicationService
    {
        Task<bool> InsertUserAsync(SysUserDto t);
        Task<bool> UpdateGetPagedResultAsync(SysUserDto t);
        Task<PagedResultOutPut<SysUserDto>> GetPagedResultAsync(GetUserPageListInPut t);

        Task<bool> DeleteAsync(GetDto t);

        Task<SysUserDto> GetUserDto(GetDto t);
    }
    public class SysUserAppService(ISysUserRepository _sysUserRepository,
        ISysRoleRepository _roleRepository,ISysUserRoleRepository _userRolePepository) : DesignApplicationService, ISysUserAppService
    {
        public async Task<bool> DeleteAsync(GetDto t)
        {
            await _sysUserRepository.DeleteAsync(x=>x.Id==t.Id);
            return true;
        }

        public async Task<PagedResultOutPut<SysUserDto>> GetPagedResultAsync(GetUserPageListInPut t)
        {
            var data = await _sysUserRepository.GetPagedListAsync(x => x.UserName.EndsWith(t.userName) && x.IsDelete, a => a.CreateTime,true,t.PageIndex,t.PageSize);
            List<SysUserDto> list = ObjectMapper.Map<List<SysUser>, List<SysUserDto>>(data.Item2);
            return new PagedResultOutPut<SysUserDto>(data.Item1, list);
        }

        public async Task<SysUserDto> GetUserDto(GetDto t) => ObjectMapper.Map<SysUser,SysUserDto>(await _sysUserRepository.GetAsync(x => x.Id == t.Id));

        public async Task<bool> InsertUserAsync(SysUserDto t)
        {

            bool flag= await _sysUserRepository.InsertAsync(ObjectMapper.Map<SysUserDto, SysUser>(t)) != null;
            if (flag)
            {
                List<SysUserRole> sysUserRoles = new List<SysUserRole>();
                var RoleList=await _roleRepository.GetListAsync(x => x.IsDefault && x.IsStatus);
                RoleList.ForEach(c =>
                {
                    new SysUserRole()
                    {
                        CreateTime = DateTime.Now,
                        IsDelete = true,
                        RoleId = c.Id,
                        UserId = t.Id,
                    };
                });
                await _userRolePepository.InsertManyAsync(sysUserRoles);
            }
            return flag;
        }

        public async Task<bool> UpdateGetPagedResultAsync(SysUserDto t) => await _sysUserRepository.UpdateAsync(ObjectMapper.Map<SysUserDto, SysUser>(t))!=null;
    }
}
