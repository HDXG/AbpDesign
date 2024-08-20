using Design.HttpApi.Extensions;
using DesignSetup.Domain;
using Microsoft.AspNetCore.Mvc;
using DesignAspNetCore.JwtExtensions;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using YamlDotNet.Core.Tokens;

namespace DesignSetup.Host.Controllers
{
    [Authorize]
    [ApiExplorerSettings(GroupName = "setup")]
    [ApiController]
    [Area(DesignSetupDomainOptions.ApplicationName)]
    [Route("api/Setup/[controller]/[action]")]
    public class UsersController (IConfiguration services) : DesignControllerBase
    {

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
