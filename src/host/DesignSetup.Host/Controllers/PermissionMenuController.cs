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
    public class PermissionMenuController(ISysMenuPermissionsAppService menuAppService):DesignControllerBase
    {

        [HttpPost]
        public Task<bool> InsertMenuAsync(SysMenuPermissionsDto t) => menuAppService.InsertMenuAsync(t);

        [HttpPost]
        public Task<bool> UpdateMenuAsync(SysMenuPermissionsDto t) => menuAppService.UpdateMenuAsync(t);

        [HttpPost]
        public Task<SysMenuPermissionsDto> GetMenuAsync(GetDto t) => menuAppService.GetMenuAsync(t);

        [HttpPost]
        public Task<List<TreeSelectOutPut>> TreeSelectAsync() => menuAppService.TreeSelectAsync();

        [HttpPost]
        public  Task<PopedTableOutPut> PagedResultAsync(PagedResultInPut t) => menuAppService.PagedResultAsync(t);

        [HttpPost]
        public Task<bool> DeleteMenuAsync(GetDto t) => menuAppService.DeleteMenuAsync(t);
    }
}
