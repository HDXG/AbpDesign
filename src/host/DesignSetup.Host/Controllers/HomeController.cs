using Design.HttpApi.Extensions;
using DesignSetup.Domain;
using Microsoft.AspNetCore.Mvc;
namespace DesignSetup.Host.Controllers
{
    [ApiExplorerSettings(GroupName = "setup")]
    [ApiController]
    [Area(DesignSetupDomainOptions.ApplicationName)]
    [Route("api/Setup/[controller]/[action]")]
    public  class HomeController: DesignControllerBase
    {

    }
}
