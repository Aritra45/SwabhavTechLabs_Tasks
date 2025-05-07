using BankingApp.Database;
using BankingApp.Model.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BankingApp.Model.AuthControllerDto;
using BankingApp.Model.AuthDto;
using BankingApp.Repository;
using BankingApp.Interfaces.IRepository;

namespace BankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly MyContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGenericRepository<User> user_repos;
        private readonly IGenericRepository<Bank> bank_repos;
        private readonly IGenericRepository<Company> company_repos;

        public AuthController(IConfiguration configuration, MyContext context, IHttpContextAccessor httpContextAccessor, IGenericRepository<User> user_repos, IGenericRepository<Bank> bank_repos, IGenericRepository<Company> company_repos)
        {
            _configuration = configuration;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            this.user_repos = user_repos;
            this.bank_repos = bank_repos;
            this.company_repos = company_repos;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UnifiedLoginDto loginDto)
        {
            var userEntity = _context.Users.SingleOrDefault(u => u.UserEmail == loginDto.UserEmail);
            var bankEntity = _context.Banks.SingleOrDefault(u => u.BankEmail == loginDto.UserEmail);
            var companyEntity = _context.Companies.SingleOrDefault(u => u.CompanyEmail == loginDto.UserEmail);
            if (userEntity != null)
            {
                if (BCrypt.Net.BCrypt.EnhancedVerify(loginDto.Password, userEntity.UserPassword))
                {
                    var users = new User();
                    string email = loginDto.UserEmail;
                    var userDetails = user_repos.GetByEmail(email);
                    if(userDetails.IsActive == true)
                    {
                        return await GenerateTokenForAdmin(userEntity, _configuration);
                    }
                    else
                    {
                        await LogFailed(loginDto.UserEmail);
                        return Unauthorized("You Are Banned");
                    }
                    
                }
                else
                {
                    await LogFailed(loginDto.UserEmail);
                    return Unauthorized("Invalid Admin Email or Password.");
                }
            }
            else if (bankEntity != null)
            {
                if (BCrypt.Net.BCrypt.EnhancedVerify(loginDto.Password, bankEntity.BankPassword))
                {
                    var bank = new Bank();
                    string email = loginDto.UserEmail;
                    var bankDetails = bank_repos.GetByEmail(email);
                    if(bankDetails.IsActive == true)
                    {
                        return await GenerateTokenForBank(bankEntity, _configuration);
                    }
                    else
                    {
                        await LogFailed(loginDto.UserEmail);
                        return Unauthorized("Bank is Banned");
                    }

                }
                else
                {
                    await LogFailed(loginDto.UserEmail);
                    return Unauthorized("Invalid Bank Email or Password.");
                }
            }
            else if (companyEntity != null)
            {
                if (BCrypt.Net.BCrypt.EnhancedVerify(loginDto.Password, companyEntity.Password))
                {
                    var company = new Company();
                    string email = loginDto.UserEmail;
                    var companyDetails = company_repos.GetByEmail(email);
                    if (companyDetails.IsActive == true)
                    {
                        return await GenerateTokenForCompany(companyEntity, _configuration);
                    }
                    else
                    {
                        await LogFailed(email);
                        return Unauthorized("You Are Banned");
                    }
                }
                else
                {
                    await LogFailed(loginDto.UserEmail);
                    return Unauthorized("Invalid Company Email or Password.");
                }
            }
            else
            {
                return Unauthorized("Invalid Staff ID or Password.");
            }
            
        }

        [HttpPost("logout")]
        public async Task<IActionResult> LogOut([FromBody] LogoutDto logoutDto)
        {
            _context.AuditLogs.Add(new AuditLog
            {
                UserId = logoutDto.Email,
                Description = $"LogOut Successfull.",
                Time = DateTime.Now
            });

            await _context.SaveChangesAsync();
            return Ok("LogOut Successfull.");
        }

        private async Task<IActionResult> LogFailed(string email)
        {
            _context.AuditLogs.Add(new AuditLog
            {
                UserId = email,
                Description = $"Failed login attempt.",
                Time = DateTime.Now
            });

            await _context.SaveChangesAsync();
            return Unauthorized("Invalid credentials.");
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private async Task<IActionResult> GenerateTokenForAdmin(User loggeduser, IConfiguration configuration)
        {
            Role role = _context.Roles.Find(loggeduser.RoleId);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim("Id", loggeduser.UserEmail),
                new Claim(ClaimTypes.Role, role?.RoleName ?? "Unknown")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(10),
                signingCredentials: signIn
            );

            _context.AuditLogs.Add(new AuditLog
            {
                UserId = loggeduser.UserEmail,
                Description = "User logged in successfully.",
                Time = DateTime.Now
            });
            await _context.SaveChangesAsync();

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private async Task<IActionResult> GenerateTokenForBank(Bank loggeduser, IConfiguration configuration)
        {
            Role role = _context.Roles.Find(loggeduser.RoleId);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim("Id", loggeduser.BankEmail),
                new Claim(ClaimTypes.Role, role?.RoleName ?? "Unknown")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(10),
                signingCredentials: signIn
            );

            _context.AuditLogs.Add(new AuditLog
            {
                UserId = loggeduser.BankEmail,
                Description = "User logged in successfully.",
                Time = DateTime.Now
            });
            await _context.SaveChangesAsync();

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private async Task<IActionResult> GenerateTokenForCompany(Company loggeduser, IConfiguration configuration)
        {
            Role role = _context.Roles.Find(loggeduser.RoleId);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim("Id", loggeduser.CompanyEmail),
                new Claim(ClaimTypes.Role, role?.RoleName ?? "Unknown")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(10),
                signingCredentials: signIn
            );

            _context.AuditLogs.Add(new AuditLog
            {
                UserId = loggeduser.CompanyEmail,
                Description = "User logged in successfully.",
                Time = DateTime.Now
            });
            await _context.SaveChangesAsync();

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}
