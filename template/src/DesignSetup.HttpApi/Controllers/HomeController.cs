using Design.HttpApi.Extensions;
using Microsoft.AspNetCore.Mvc;
namespace DesignSetup.HttpApi.Controllers
{
    [ApiController]
    [Route("api/Setup/[controller]/[action]")]
    public class HomeController : DesignControllerBase
    {
        [HttpGet]
        public string Index() => GetDemo();
    }
}
