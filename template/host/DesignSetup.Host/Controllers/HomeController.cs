using Design.HttpApi.Extensions;
using DesignSetup.Application.Users;
using DesignSetup.Application.Users.Dtos;
using DesignSetup.Domain;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
namespace DesignSetup.HttpApi.Controllers
{
    [ApiExplorerSettings(GroupName = "setup")]
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


        [HttpGet]
        public int GetUserDto()
        {
            return Convert.ToInt32("234fafa");
        }
    }
}
