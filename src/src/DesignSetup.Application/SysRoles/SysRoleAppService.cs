using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.Application.Contracts.Services;
using Design.Application.Services;
using DesignSetup.Application.SysRoles.Dtos;
using DesignSetup.Domain.SysRoles;

namespace DesignSetup.Application.SysRoles
{
    public interface ISysRoleAppService
    {
        /// <summary>
        /// 返回角色列表内容
        /// </summary>
        /// <returns></returns>
        Task<PagedResultOutPut<SysRoleDto>> PagedResultAsync();

        Task<PagedResultOutPut<SysRoleDto>> InsertRoleAsync(SysRoleDto t);
    }
    public class SysRoleAppService(ISysRoleRepository _roleRepository) : DesignApplicationService, ISysRoleAppService
    {
        public async Task<PagedResultOutPut<SysRoleDto>> InsertRoleAsync(SysRoleDto t)
        {
            await _roleRepository.InsertAsync(ObjectMapper.Map<SysRoleDto, SysRole>(t));
            return await PagedResultAsync();
        }

        public async Task<PagedResultOutPut<SysRoleDto>> PagedResultAsync()
        {
            var data = await _roleRepository.GetPagedListAsync(x=>x.RoleName.StartsWith(""),x=>x.CreateTime);
            return new PagedResultOutPut<SysRoleDto>(data.Item1,ObjectMapper.Map<List<SysRole>,List<SysRoleDto>>(data.Item2));
        }
    }
}
