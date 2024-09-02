using Design.Application.Contracts.Services;
using Design.Application.Services;
using DesignSetup.Application.SysMenuPermissiones.Dtos;
using DesignSetup.Domain.SysMenuPermissiones;
using Volo.Abp.Application.Dtos;

namespace DesignSetup.Application.SysMenuPermissiones
{
    public interface ISysMenuPermissionsAppService
    {
        Task<PagedResultOutPut<SysMenuPermissionsDto>> PagedResultAsync();
    }
    public class SysMenuPermissionsAppService(ISysMenuPermissionsRepository _sysMenuRepository) : DesignApplicationService, ISysMenuPermissionsAppService
    {
        public async Task<PagedResultOutPut<SysMenuPermissionsDto>> PagedResultAsync()
        {
            var data = await _sysMenuRepository.GetPagedListAsync(x => x.MenuName.StartsWith(""), a => a.CreateTime);
            List<SysMenuPermissionsDto> list = ObjectMapper.Map<List<SysMenuPermissions>, List<SysMenuPermissionsDto>>(data.Item2);
            return new PagedResultOutPut<SysMenuPermissionsDto>(data.Item1, list);
        }
    }
}
