using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using JWTImplementation.Data;
using JWTImplementation.Interfaces.IService;
using JWTImplementation.Model.Entity;
using JWTImplementation.Model.StaffDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace JWTImplementation.Controllers
{
    public class AuthController : Controller
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
            var userEntity = userDbContext.Staffs.SingleOrDefault(u => u.StaffId == userLoginDto.StaffId);
            if (userEntity == null || !BCrypt.Net.BCrypt.EnhancedVerify(userLoginDto.Password, userEntity.Password))
            {
                return Unauthorized("Invalid Staff ID or Password.");
            }

            // Pass userEntity to token generator
            return await GenerateToken(userEntity, _configuration);
        }



        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> GenerateToken(Staff loggeduser, IConfiguration configuration)
        {
            Role role = userDbContext.Roles.Find(loggeduser.RoleId);
            var claims = new List<Claim> {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim("Id", loggeduser.StaffId.ToString()),
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

