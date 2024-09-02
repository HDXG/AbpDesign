using System.Security.Claims;
using Design.Application.Contracts.Services;
using Design.HttpApi.Extensions;
using DesignAspNetCore.JwtExtensions;
using DesignSetup.Application.SysUsers;
using DesignSetup.Application.SysUsers.Dtos;
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
    [Route("api/Setup/[controller]/[action]")]
    public class UsersController (IConfiguration services,
        ISysUserAppService _sysUserAppService) : DesignControllerBase
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<SysUser> InsertUserAsync(SysUserDto t)=> _sysUserAppService.InsertUserAsync(t);

        /// <summary>
        /// 返回用户集合内容
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Task<PagedResultOutPut<SysUserDto>> GetPagedResult() => _sysUserAppService.GetPagedResultAsync();

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
