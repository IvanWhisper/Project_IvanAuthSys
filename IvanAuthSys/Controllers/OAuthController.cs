using Autofac;
using DbEntities;
using IdentityModel;
using IvanAuthSys.Data;
using IvanAuthSys.Dev;
using IvanAuthSys.Interface;
using IvanAuthSys.Interface.IBusinessService;
using IvanAuthSys.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace IvanAuthSys.Controllers
{
    [Route("api/[controller]")]
    public class OAuthController : Controller
    {
        ILifetimeScope _rootScope;
        ILogger _log;
        IOAuthService _oauthService;
        public OAuthController(ILifetimeScope rootScope,ILogger log,IOAuthService oauthService)
        {
            _rootScope = rootScope;
            _log = log;
            _oauthService = oauthService;
        }
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]LoginModel loginModel)
        {
            User user=null;
            using (var scope=_rootScope.BeginLifetimeScope())
            {
                user=_oauthService.VerifyUser(loginModel, scope.Resolve<IQuery>());
            }
            if(user==null)
                return Unauthorized();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Consts.Secret);
            var authTime = DateTime.UtcNow;
            var expiresAt = authTime.AddMinutes(1);//AddDays(7);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtClaimTypes.Audience,"api"),
                    new Claim(JwtClaimTypes.Issuer,"http://localhost:44338"),
                    new Claim(JwtClaimTypes.Id, user.UserID),
                }),
                Expires = expiresAt,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new
            {
                access_token = tokenString,
                token_type = "Bearer",
                profile = new
                {
                    sid = user.UserID,
                    auth_time = new DateTimeOffset(authTime).ToUnixTimeSeconds(),
                    expires_at = new DateTimeOffset(expiresAt).ToUnixTimeSeconds()
                }
            });
        }

    }
}