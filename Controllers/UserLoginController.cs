using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WareHouseManagment.Data;
using WareHouseManagment.Dto;
using WareHouseManagment.Models;

namespace WareHouseManagment.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public class UserLoginController:ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public UserLoginController (DataContext dataContext, IConfiguration configuration)
        {
            _context = dataContext;
            _configuration = configuration;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var user = _context.Users
                .Where(u => u.Username == loginDto.Username)
                .FirstOrDefault();

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Fassword, user.Fassword))
            {
                return Unauthorized("Sai tài khoản hoặc mật khẩu");
            }

            var roles = _context.UserRoles
                .Where(ur => ur.UserId == user.Id)
                .Select(ur => ur.Role.Name)
                .ToList();

            var token = GenerateJwtToken(user.Username, roles);

            return Ok(new
            {
                token,
                username = user.Username,
                roles
            });
        }
        private string GenerateJwtToken(string username, List<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, string.Join(",", roles)) 
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
