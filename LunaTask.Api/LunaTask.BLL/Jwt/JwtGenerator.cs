using LunaTask.BLL.Dtos.User;
using LunaTask.BLL.Jwt.Interfaces;
using LunaTask.DAL.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace LunaTask.BLL.Jwt
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly IConfiguration _configuration;

        public JwtGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.Username)
            };

            var key = new SymmetricSecurityKey(
                 Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var sign = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: sign,
                expires: DateTime.UtcNow.AddDays(1)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }



    }
}
