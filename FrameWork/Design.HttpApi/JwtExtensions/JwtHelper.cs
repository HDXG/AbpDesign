using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Dynamic.Core;
using Newtonsoft.Json;

namespace DesignAspNetCore.JwtExtensions
{
    public static class JwtHelper
    {
        /// <summary>
        /// 创建Token内容
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="Listclaims"></param>
        /// <returns></returns>
        public static string CreateTokenClaim(IConfiguration configuration, List<Claim> Listclaims)
        {
            var signingAlogorithm = SecurityAlgorithms.HmacSha256;
            //取出私钥并以utf8编码字节输出
            var secretByte = Encoding.UTF8.GetBytes(configuration["AuthenticationDemo:SecretKeyDemo"]);
            //使用非对称算法对私钥进行加密
            var signingKey = new SymmetricSecurityKey(secretByte);
            //使用HmacSha256来验证加密后的私钥生成数字签名
            var signingCredentials = new SigningCredentials(signingKey, signingAlogorithm);
            //生成Token
            var Token = new JwtSecurityToken(
                    issuer: configuration["AuthenticationDemo:IssuerDemo"],        //发布者
                    audience: configuration["AuthenticationDemo:AudienceDemo"],    //接收者
                    claims: Listclaims,                                         //存放的用户信息
                    notBefore: DateTime.UtcNow,                             //发布时间
                    expires: DateTime.UtcNow.AddHours(2),                      //有效期设置为2小时
                    signingCredentials                                      //数字签名
                );
            //生成字符串token
            var TokenStr = new JwtSecurityTokenHandler().WriteToken(Token);
            return TokenStr;
        }


        /// <summary>
        /// 解析Jwt内容
        /// </summary>
        /// <param name="jwtStr"></param>
        /// <returns></returns>
        public static Dictionary<string, object> SerializeJwt(string jwtStr,Dictionary<string,object> keys)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(jwtStr);
            for (int i = 0; i < keys.Count; i++)
            {
                var item = keys.ElementAt(i);
                object? value = null;
                jwtToken.Payload.TryGetValue(item.Key,out value);
                keys[item.Key] = value;
            }
           return keys;
        }
    }
}
