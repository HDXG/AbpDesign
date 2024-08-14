using Design.HttpApi.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DesignSetup.Host.Controllers
{
    [ApiController]
    [Area("Setup")]
    [Route("api/Setup/[controller]/[action]")]
    public  class HomeController : DesignControllerBase
    {
        [HttpGet]
        public string Index() => GetDemo();
    }
}
