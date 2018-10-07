using IdentityModel;
using IvanAuthSys.Data;
using IvanAuthSys.Dev;
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

        public OAuthController()
        {
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]LoginModel loginModel)
        {
            var user = UserStore.loginmodels.Where(c => c.UserName==loginModel.UserName).SingleOrDefault();
            if (user == null&&user.Password==loginModel.Password) return Unauthorized();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Consts.Secret);
            var authTime = DateTime.UtcNow;
            var expiresAt = authTime.AddDays(7);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtClaimTypes.Audience,"api"),
                    new Claim(JwtClaimTypes.Issuer,"http://localhost:44338"),
                    new Claim(JwtClaimTypes.Name, user.UserName),
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
                    sid = user.UserName,
                    auth_time = new DateTimeOffset(authTime).ToUnixTimeSeconds(),
                    expires_at = new DateTimeOffset(expiresAt).ToUnixTimeSeconds()
                }
            });
        }

    }
}