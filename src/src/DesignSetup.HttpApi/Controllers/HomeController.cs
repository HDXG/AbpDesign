using Design.HttpApi.Extensions;
using DesignSetup.Domain;
using DesignSetup.Infrastructure.Users;
using DesignSetup.Infrastructure.Users.Dtos;
using Microsoft.AspNetCore.Mvc;
namespace DesignSetup.HttpApi.Controllers
{
    [ApiController]
    [Area(DesignSetupDomainOptions.ApplicationName)]
    [Route("api/Setup/[controller]/[action]")]
    public  class HomeController(IUserAppService userAppService) : DesignControllerBase
    {

        /// <summary>
        /// Get内容
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetUserList()=>await userAppService.GetUsers() ;


        /// <summary>
        /// post请求内容
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<UserDto>> GetUserListDto() => await userAppService.GetUsers();
    }
}
