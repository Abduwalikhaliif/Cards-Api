using Cards.Business.Entity.UserEntity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Business.Service.DBAccess
{
    public class createToken
    {
        private IConfiguration _configuration;
        public createToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GeneratetokenString(LoginUserBE loginUserBE, String role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, loginUserBE.Email),
                new Claim(ClaimTypes.Role, role),
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSetting:Key").Value));
            SigningCredentials signingCred = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature);
            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: _configuration.GetSection("JwtSetting:Issuer").Value,
                audience: _configuration.GetSection("JwtSetting:Audience").Value,
                signingCredentials: signingCred);
            var tokenstring = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenstring;
        }
    }
}
