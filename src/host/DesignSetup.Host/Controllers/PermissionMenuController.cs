using Design.Application.Contracts.Extensions;
using Design.Application.Contracts.Services;
using Design.HttpApi.Extensions;
using DesignSetup.Application.SysMenuPermissiones;
using DesignSetup.Application.SysMenuPermissiones.Dtos;
using DesignSetup.Application.SysMenuPermissiones.InPuts;
using DesignSetup.Application.SysMenuPermissiones.OutPuts;
using DesignSetup.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesignSetup.Host.Controllers
{
    [ApiExplorerSettings(GroupName = "setup")]
    [ApiController]
    [Area(DesignSetupDomainOptions.ApplicationName)]
    [Route("api/[controller]/[action]")]
    public class PermissionMenuController(ISysMenuPermissionsAppService _menPermission) :DesignControllerBase
    {

        [HttpPost]
        public Task<bool> InsertMenuAsync(SysMenuPermissionsDto t) => _menPermission.InsertMenuAsync(t);

        [HttpPost]
        public Task<bool> UpdateMenuAsync(SysMenuPermissionsDto t) => _menPermission.UpdateMenuAsync(t);

        [HttpPost]
        public Task<SysMenuPermissionsDto> GetMenuAsync(GetDto t) => _menPermission.GetMenuAsync(t);

        [HttpPost]
        public Task<List<TreeSelectOutPut>> TreeSelectAsync() => _menPermission.TreeSelectAsync();

        [HttpPost]
        public  Task<PopedTableOutPut> PagedResultAsync(PagedResultInPut t) => _menPermission.PagedResultAsync(t);
    }
}
