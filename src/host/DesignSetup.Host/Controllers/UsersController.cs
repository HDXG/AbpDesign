using System.Security.Claims;
using Design.Application.Contracts.Extensions;
using Design.Application.Contracts.Services;
using Design.HttpApi.Extensions;
using DesignAspNetCore.JwtExtensions;
using DesignSetup.Application.SysUsers;
using DesignSetup.Application.SysUsers.Dtos;
using DesignSetup.Application.SysUsers.InPuts;
using DesignSetup.Application.SysUsers.OutPuts;
using DesignSetup.Domain;
using DesignSetup.Domain.SysUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesignSetup.Host.Controllers
{
    //[Authorize]
    [ApiExplorerSettings(GroupName = "setup")]
    [ApiController]
    [Area(DesignSetupDomainOptions.ApplicationName)]
    [Route("api/[controller]/[action]")]
    public class UsersController (IConfiguration services,
        ISysUserAppService _sysUserAppService) : DesignControllerBase
    {
        [HttpPost]
        public Task<bool> InsertUser(InsertUserOutPut t)=> _sysUserAppService.InsertUserAsync(t);

        [HttpPost]
        public Task<bool> UpdateUser(InsertUserOutPut t)=>_sysUserAppService.UpdateUserAsync(t);

        [HttpPost]
        public Task<PagedResultOutPut<GetUserListDto>> GetPagedResult(GetUserPageListInPut t) => _sysUserAppService.GetPagedResultAsync(t);

        [HttpPost]
        public Task<bool> Delete(GetDto t)=>_sysUserAppService.DeleteAsync(t);

        [HttpPost]
        public Task<GetUserOutPut> GetUser(GetDto t) => _sysUserAppService.GetUserDto(t);


        [HttpPost]
        public Task<GetLogInOutPut> GetLoginUser(LoginUserInPut t) => _sysUserAppService.GetLogIn(t);

        [HttpPost]
        public Task<List<loginUserMenuOutPut>> GetByUserIdMenu(GetDto t) =>
            _sysUserAppService.GetByUserIdMenu(t.Id);

        /// <summary>
        /// 创建token内容
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public string CreateToken()
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("UserName", "admin"));
            claims.Add(new Claim("UserId", "123"));
            claims.Add(new Claim("Role", "管理员"));
            return JwtHelper.CreateTokenClaim(services, claims);
        }
        /// <summary>
        /// 解析
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Dictionary<string, object> ClaimString()
        {
            string jwtStr = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            Dictionary<string, object> keys = new Dictionary<string, object>() 
            {
                {"UserName","" },
                { "UserId",""},
                { "Role",""}
            };
            return JwtHelper.SerializeJwt(jwtStr,keys);
        }
    }
}
