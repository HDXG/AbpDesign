using Design.Application.Contracts.Extensions;
using Design.Application.Contracts.Services;
using Design.Application.Services;
using DesignSetup.Application.SysUsers.Dtos;
using DesignSetup.Application.SysUsers.InPuts;
using DesignSetup.Application.SysUsers.OutPuts;
using DesignSetup.Domain.SysRoles;
using DesignSetup.Domain.SysUserRoles;
using DesignSetup.Domain.SysUsers;
using Volo.Abp.Domain.Repositories;

namespace DesignSetup.Application.SysUsers
{
    public interface ISysUserAppService: IDedsiApplicationService
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> InsertUserAsync(InsertUserOutPut t);
        Task<bool> UpdateUserAsync(InsertUserOutPut t);
        Task<PagedResultOutPut<GetUserListDto>> GetPagedResultAsync(GetUserPageListInPut t);

        Task<bool> DeleteAsync(GetDto t);

        Task<GetUserOutPut> GetUserDto(GetDto t);
    }
    public class SysUserAppService(ISysUserRepository _sysUserRepository,
        ISysRoleRepository _roleRepository,
        ISysUserRoleRepository _userRolePepository) : DesignApplicationService, ISysUserAppService
    {
        public async Task<bool> DeleteAsync(GetDto t)
        {
            var SysUser = await _sysUserRepository.FirstOrDefaultAsync(x => x.Id == t.Id);
            SysUser.IsDelete = false;
            await _sysUserRepository.UpdateAsync(SysUser);
            await _userRolePepository.DeleteManyAsync(await _userRolePepository.GetListAsync(x => x.UserId == t.Id),true);
            return true;
        }

        public async Task<PagedResultOutPut<GetUserListDto>> GetPagedResultAsync(GetUserPageListInPut t)
        {
            var list = await _sysUserRepository.GetUserListAsync<GetUserListDto>(t.userName);
            return new PagedResultOutPut<GetUserListDto>(
                list.Count,
                list.Skip((t.PageIndex - 1) * t.PageSize).Take(t.PageSize).ToList());
        }

        public async Task<GetUserOutPut> GetUserDto(GetDto t)
        {
            var rolelist = await _userRolePepository.GetListAsync(x => x.UserId == t.Id);
            return new GetUserOutPut()
            {
                model = ObjectMapper.Map<SysUser, SysUserDto>(await _sysUserRepository.GetAsync(x => x.Id == t.Id)),
                roleIds= rolelist.Select(x => x.RoleId).ToList()
            };
        }

        public async Task<bool> InsertUserAsync(InsertUserOutPut t)
        {

            bool flag= await _sysUserRepository.InsertAsync(ObjectMapper.Map<SysUserDto, SysUser>(t.model)) != null;
            if (flag)
            {
                await InsertUserRole(t);
            }
            return flag;
        }

        private async Task InsertUserRole(InsertUserOutPut t)
        {
            List<SysUserRole> sysUserRoles = new List<SysUserRole>();
            var RoleList = await _roleRepository.GetListAsync(x => x.IsDefault && x.IsStatus);

            List<Guid> guids = new List<Guid>();
            t.guids.ForEach(c => { guids.Add(c); });
            RoleList.ForEach(c =>
            {
                if (guids.Count(x => x == c.Id) == 0)
                {
                    guids.Add(c.Id);
                }
            });
            guids.ForEach(c =>
            {
                sysUserRoles.Add(new SysUserRole(GuidGenerator.Create())
                {
                    CreateTime = DateTime.Now,
                    IsDelete = true,
                    RoleId = c,
                    UserId = t.model.Id,
                });
            });
            await _userRolePepository.InsertManyAsync(sysUserRoles, true);
        }

        public async Task<bool> UpdateUserAsync(InsertUserOutPut t)
        {
            bool flag = await _sysUserRepository.UpdateAsync(ObjectMapper.Map<SysUserDto, SysUser>(t.model)) != null;
            if (flag)
            {
                await _userRolePepository.DeleteManyAsync(await _userRolePepository.GetListAsync(x=>x.UserId==t.model.Id),true );
                await InsertUserRole(t);
            }
            return flag;
        }
    }
}
