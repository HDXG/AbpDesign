using Design.Application.Contracts.Services;
using Design.Application.Services;
using DesignSetup.Application.SysMenuPermissiones.Dtos;
using DesignSetup.Domain.SysMenuPermissiones;

namespace DesignSetup.Application.SysMenuPermissiones
{
    public interface ISysMenuPermissionsAppService
    {
        /// <summary>
        /// 分页返回菜单列表
        /// </summary>
        /// <returns></returns>
        Task<PagedResultOutPut<SysMenuPermissionsDto>> PagedResultAsync();

        /// <summary>
        /// 添加菜单/按钮权限  返回列表
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<PagedResultOutPut<SysMenuPermissionsDto>> InsertPagedReusltAsync(SysMenuPermissionsDto t);

        Task<PagedResultOutPut<SysMenuPermissionsDto>> UpdatePagedReusltAsync(SysMenuPermissionsDto t);

    }
    public class SysMenuPermissionsAppService(ISysMenuPermissionsRepository _sysMenuRepository) : DesignApplicationService, ISysMenuPermissionsAppService
    {
        public async Task<PagedResultOutPut<SysMenuPermissionsDto>> InsertPagedReusltAsync(SysMenuPermissionsDto t)
        {
            t.Id = Guid.NewGuid();
            await _sysMenuRepository.InsertAsync(ObjectMapper.Map<SysMenuPermissionsDto, SysMenuPermissions>(t));
            return await PagedResultAsync();
        }

        public async Task<PagedResultOutPut<SysMenuPermissionsDto>> PagedResultAsync()
        {
            var data = await _sysMenuRepository.GetPagedListAsync(x => x.MenuName.StartsWith(""), a => a.CreateTime);
            List<SysMenuPermissionsDto> list = ObjectMapper.Map<List<SysMenuPermissions>, List<SysMenuPermissionsDto>>(data.Item2);
            return new PagedResultOutPut<SysMenuPermissionsDto>(data.Item1, list);
        }

        public async Task<PagedResultOutPut<SysMenuPermissionsDto>> UpdatePagedReusltAsync(SysMenuPermissionsDto t)
        {
            await _sysMenuRepository.UpdateAsync(ObjectMapper.Map<SysMenuPermissionsDto,SysMenuPermissions>(t));
            return await PagedResultAsync();
        }
    }
}
