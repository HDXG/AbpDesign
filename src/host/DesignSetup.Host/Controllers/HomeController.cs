using Design.Application.Contracts.Services;
using Design.HttpApi.Extensions;
using DesignSetup.Application.Users;
using DesignSetup.Application.Users.Dtos;
using DesignSetup.Domain;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
namespace DesignSetup.Host.Controllers
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
        public Task<List<UserDto>> GetUserListDto() =>  userAppService.GetUsers();


        [HttpPost]
        public Task<PagedResultOutPut<UserDto>> GetPagedResultAsync()=> userAppService.GetPagedResultAsync();
    }
}
