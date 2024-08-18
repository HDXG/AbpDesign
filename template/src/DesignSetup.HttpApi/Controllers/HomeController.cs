using Design.HttpApi.Extensions;
using DesignSetup.Infrastructure.Users;
using Microsoft.AspNetCore.Mvc;
namespace DesignSetup.HttpApi.Controllers
{
    [ApiController]
    [Route("api/Setup/[controller]/[action]")]
    public class HomeController(IUserAppService userAppService) : DesignControllerBase
    {
        [HttpGet]
        public async Task<object> GetUserList()=>await userAppService.GetUsers() ;
    }
}
