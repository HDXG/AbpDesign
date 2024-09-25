using Design.Application.Contracts.Extensions;
using Design.Application.Contracts.Services;
using Design.HttpApi.Extensions;
using DesignSetup.Application.Serilogs;
using DesignSetup.Application.Serilogs.Dtos;
using DesignSetup.Application.Serilogs.InPut;
using DesignSetup.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesignSetup.Host.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "setup")]
    [ApiController]
    [Area(DesignSetupDomainOptions.ApplicationName)]
    public class SerilogController(ISerilogAppService serilogAppService) : DesignControllerBase
    {
        [HttpPost]
        public Task<PagedResultOutPut<SerilogDto>> GetSerilogList(SerilogInPut t) =>
            serilogAppService.GetSerilogList(t);

        [HttpPost]
        public Task<SerilogGetDto> GetSerilog(GetIntDto t) => serilogAppService.GetSerilog(t);
    }
}
