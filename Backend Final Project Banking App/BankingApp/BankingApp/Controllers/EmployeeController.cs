using System.Security.Claims;
using AutoMapper;
using BankingApp.Interfaces.IService;
using BankingApp.Mapper;
using BankingApp.Model.BankDto;
using BankingApp.Model.UserDtos;
using BankingApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeServices employeeServices;
        IMapper mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EmployeeController(IEmployeeServices employeeServices, IHttpContextAccessor httpContextAccessor)
        {
            this.employeeServices = employeeServices;
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            mapper = config.CreateMapper();
            this.mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("all-employees")]
        [Authorize(Roles = "Company")]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = employeeServices.GetAllEmployees();
            var getEmployees = mapper.Map<List<GetAllEmployeesDto>>(allEmployees);
            return Ok(getEmployees);
        }

        [HttpPost("upload-csv")]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> UploadEmployeesFromCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var result = await employeeServices.AddEmployeesByCSV(file, User.Identity.Name);
            return Ok(new { message = result });
        }

        [HttpPost("bulk-salary-disbursement")]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> DisburseSalaryToAllEmployees()
        {
            var emailClaim = _httpContextAccessor.HttpContext?.User?.Claims
                .FirstOrDefault(c => c.Type == "Id");

            var companyEmail = emailClaim?.Value;

            if (string.IsNullOrEmpty(companyEmail))
                return Unauthorized("Company email not found in token.");

            var result = await employeeServices.DisburseSalaryToAllEmployees(companyEmail);
            return Ok(new { message = result });
        }



    }
}
