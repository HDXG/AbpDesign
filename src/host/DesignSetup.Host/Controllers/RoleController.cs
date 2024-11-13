using Design.Application.Contracts.Extensions;
using Design.Application.Contracts.Services;
using Design.HttpApi.Extensions;
using DesignSetup.Application.SysMenuPermissiones;
using DesignSetup.Application.SysMenuPermissiones.OutPuts;
using DesignSetup.Application.SysRoles;
using DesignSetup.Application.SysRoles.Dtos;
using DesignSetup.Application.SysRoles.InPuts;
using DesignSetup.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DesignSetup.Host.Controllers
{
    /// <summary>
    /// 角色内容
    /// </summary>
    [ApiExplorerSettings(GroupName = "setup")]
    [ApiController]
    [Area(DesignSetupDomainOptions.ApplicationName)]
    [Route("api/[controller]/[action]")]
    public class RoleController(ISysRoleAppService roleAppService,
        ISysMenuPermissionsAppService _menu) : DesignControllerBase
    {
        [HttpPost]
        public Task<PagedResultOutPut<SysRoleDto>> PagedResult(GetPageRoleDto t) => roleAppService.PagedResultAsync(t);
        
        [HttpPost]
        public Task<bool> InsertRole(SysRoleDto t) => roleAppService.InsertRoleAsync(t);

        [HttpPost]
        public Task<bool> UpdateRole(SysRoleDto t) => roleAppService.UpdateRoleAsync(t);

        [HttpPost]
        public Task<SysRoleDto> GetRole(GetDto t) => roleAppService.GetRoleAsync(t);

        [HttpPost]
        public Task<bool> DeletePage(GetDto t) => roleAppService.DeletePageAsync(t);

        [HttpPost]
        public Task<List<RoleListDto>> RoleList() => roleAppService.RoleList();

        [HttpPost]
        public Task<TreePermissionsOutPut> TreePermissionsAsync(GetDto t)=> roleAppService.TreePermissionsAsync(t);

        [HttpPost]
        public Task<bool> InsertRoleMenuAsync(InsertRoleMenuInPut t) => roleAppService.InsertRoleMenuAsync(t);
    }
}
