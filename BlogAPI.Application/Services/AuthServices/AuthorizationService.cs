using BlogAPI.Application.Services.UserServices;
using BlogAPI.Domain.Entities.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application.Services.AuthServices
{
    public class AuthorizationService:IAuthorizationService
    {

        private readonly IConfiguration _conf;
        private readonly IUserService _userService;

        public AuthorizationService(IConfiguration conf, IUserService userService)
        {
            _conf = conf;
            _userService = userService;
        }

        public async Task<string> GenerateToken(LoginDTO user)
        {
            if (user == null)
            {
                return "User Not Found";
            }

            if (await UserExist(user))
            {
                var result = await _userService.GetUserByLogin(user.Login);

                List<Claim> claims = new List<Claim>()
                {
                    new Claim("Login", user.Login),
                    new Claim("UserID", result.Id.ToString()),
                    new Claim("CreatedDate", DateTime.UtcNow.ToString()),
                };

                return await GenerateToken(claims);
            }

            return "Un Authorize";
        }

        public async Task<string> GenerateToken(IEnumerable<Claim> additionalClaims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var exDate = Convert.ToInt32(_conf["JWT:ExpireDate"] ?? "10");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64)
            };

            if (additionalClaims?.Any() == true)
                claims.AddRange(additionalClaims);


            var token = new JwtSecurityToken(
                issuer: _conf["JWT:ValidIssuer"],
                audience: _conf["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(exDate),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public async Task<bool> UserExist(LoginDTO user)
        {
            var result = await _userService.GetUserByLogin(user.Login);

            if (user.Login == result.Login && user.Password == result.PasswordHash)
            {
                return true;
            }
            return false;
        }
    }
}
