using Design.Application.Contracts.Extensions;
using Design.Application.Contracts.Services;
using Design.HttpApi.Extensions;
using DesignSetup.Application.SysRoles;
using DesignSetup.Application.SysRoles.Dtos;
using DesignSetup.Domain;
using Microsoft.AspNetCore.Http;
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
    public class RoleController(ISysRoleAppService _RoleService) : DesignControllerBase
    {
        [HttpPost]
        public Task<PagedResultOutPut<SysRoleDto>> PagedResult(GetPageRoleDto t) => _RoleService.PagedResultAsync(t);
        [HttpPost]
        public Task<bool> InsertRole(SysRoleDto t)=>_RoleService.InsertRoleAsync(t);
        [HttpPost]
        public Task<bool> UpdateRole(SysRoleDto t) => _RoleService.UpdateRoleAsync(t);
        [HttpPost]
        public Task<SysRoleDto> GetRole(GetDto t)=>_RoleService.GetRoleAsync(t);
        
        [HttpPost]
        public Task<bool> DeletePage(GetDto t) => _RoleService.DeletePageAsync(t);

        [HttpPost]
        public Task<List<RoleListDto>> RoleList() => _RoleService.RoleList();

    }
}
