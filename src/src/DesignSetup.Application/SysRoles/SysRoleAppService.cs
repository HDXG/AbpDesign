using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design.Application.Contracts.Extensions;
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
        Task<PagedResultOutPut<SysRoleDto>> PagedResultAsync(GetPageRoleDto t);

        Task<bool> InsertRoleAsync(SysRoleDto t);

        Task<bool> UpdateRoleAsync(SysRoleDto t);

        Task<SysRoleDto> GetRoleAsync(GetDto Id);

        Task<bool> DeletePageAsync(GetDto t);
    }
    public class SysRoleAppService(ISysRoleRepository _roleRepository) : DesignApplicationService, ISysRoleAppService
    {
        public async Task<bool> DeletePageAsync(GetDto t)
        {
            await _roleRepository.DeleteAsync(x => x.Id == t.Id);
            return true;
        }

        public Task<SysRoleDto> GetRoleAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<SysRoleDto> GetRoleAsync(GetDto t) => ObjectMapper.Map<SysRole,SysRoleDto>(await _roleRepository.GetAsync(x => x.Id == t.Id));

        public async Task<bool> InsertRoleAsync(SysRoleDto t) =>await _roleRepository.InsertAsync(ObjectMapper.Map<SysRoleDto, SysRole>(t)) != null;

        public async Task<PagedResultOutPut<SysRoleDto>> PagedResultAsync(GetPageRoleDto t)
        {
            var data = await _roleRepository.GetPagedListAsync(x=>x.RoleName.EndsWith(t.RoleName) && x.IsDelete,x=>x.Order,false,t.PageIndex,t.PageSize
                );
            return new PagedResultOutPut<SysRoleDto>(data.Item1,ObjectMapper.Map<List<SysRole>,List<SysRoleDto>>(data.Item2));
        }

        public async Task<bool> UpdateRoleAsync(SysRoleDto t) => await _roleRepository.UpdateAsync(ObjectMapper.Map<SysRoleDto,SysRole>(t)) != null;
    }
}
