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
        /// <summary>
        /// 返回角色列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Task<PagedResultOutPut<SysRoleDto>> PagedResult()=> _RoleService.PagedResultAsync();

        /// <summary>
        /// 添加角色内容
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<PagedResultOutPut<SysRoleDto>> InsertRole(SysRoleDto t)=>_RoleService.InsertRoleAsync(t);

    }
}
