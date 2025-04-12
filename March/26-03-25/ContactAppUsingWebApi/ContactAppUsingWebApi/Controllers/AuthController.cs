using ContactAppUsingWebApi.Data;
using ContactAppUsingWebApi.Model.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ContactAppUsingWebApi.Model.UserDto;

namespace ContactAppUsingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IConfiguration _configuration;
        MyContext userDbContext;
        public AuthController(IConfiguration configuration, MyContext companyDbContext)
        {
            _configuration = configuration;
            userDbContext = companyDbContext;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var userEntity = userDbContext.Users.SingleOrDefault(u => u.UserId == userLoginDto.UserId);
            if (userEntity == null || !BCrypt.Net.BCrypt.EnhancedVerify(userLoginDto.Password, userEntity.Password))
            {
                return Unauthorized("Invalid Staff ID or Password.");
            }

            // Pass userEntity to token generator
            return await GenerateToken(userEntity, _configuration);
        }



        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> GenerateToken(User loggeduser, IConfiguration configuration)
        {
            Role role = userDbContext.Roles.Find(loggeduser.RoleId);
            var claims = new List<Claim> {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim("Id", loggeduser.UserId.ToString()),
                        new Claim(ClaimTypes.Role, role.Rolename)
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(10),
                signingCredentials: signIn
                );
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}
