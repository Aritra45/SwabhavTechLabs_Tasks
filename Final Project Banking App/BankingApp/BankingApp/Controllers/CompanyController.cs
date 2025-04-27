using AutoMapper;
using BankingApp.Interfaces.IService;
using BankingApp.Mapper;
using BankingApp.Model.BankDto;
using BankingApp.Model.BeneficiaryDto;
using BankingApp.Model.CompanyDto;
using BankingApp.Model.EmployeeDto;
using BankingApp.Model.Entity;
using BankingApp.Model.TrasactionDto;
using BankingApp.Model.UserDtos;
using BankingApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    ICompanyService companyServices;
    IMapper mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CompanyController(ICompanyService companyServices, IHttpContextAccessor httpContextAccessor)
    {
        this.companyServices = companyServices;
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        mapper = config.CreateMapper();
        this.mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    

    [HttpGet("all-companies")]
    [Authorize(Roles = "Company")]
    public IActionResult GetAllCompany()
    {
        var allCompanies = companyServices.GetAllCompanies();
        var getCompanies = mapper.Map<List<GetAllCompanyDto>>(allCompanies);
        return Ok(getCompanies);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromForm] CompanyRegisterDto dto)
    {
        string passwd = BCrypt.Net.BCrypt.EnhancedHashPassword(dto.Password);
        dto.Password = passwd;
        var result = await companyServices.RegisterAsync(dto);
        
        if (result == "Email Already Used")
        {
            return UnprocessableEntity("Email Already Used");
        }
        else
        {
            return Ok(new { message = result });
        }
    }

    [HttpPost("verify-otp")]
    public async Task<IActionResult> VerifyOtp([FromBody] OtpVerificationDto dto)
    {
        var isValid = await companyServices.VerifyOtpAsync(dto);
        return isValid ? Ok("Company verified successfully.") : BadRequest("Invalid OTP.");
    }

    [HttpGet("all-inbound-beneficiaries")]
    [Authorize(Roles = "Company")]
    public IActionResult GetAllInboundBeneficiaries()
    {
        var allBeneficiaries = companyServices.GetAllInboundBeneficiaries();
        var getBeneficiaries = mapper.Map<List<GetAllbeneficiariesDto>>(allBeneficiaries);
        return Ok(getBeneficiaries);
    }

    [HttpPost("add-inbound-beneficiaries")]
    [Authorize(Roles = "Company")]
    public IActionResult AddInboundBeneficiaries([FromBody] AddBeneficiaryDto addBeneficiaryDto)
    {
        var emailClaim = _httpContextAccessor.HttpContext?.User?.Claims
            .FirstOrDefault(c => c.Type == "Id");

        var companyEmail = emailClaim?.Value;

        if (string.IsNullOrEmpty(companyEmail))
            return Unauthorized("Company email not found in token.");
        var beneficiaries = mapper.Map<Beneficiary>(addBeneficiaryDto);
        var newbeneficiaries = companyServices.AddInbouBeneficiaries(beneficiaries, companyEmail);
        return Ok("beneficiary Added Successfully");
    }

    [HttpGet("all-oubound-beneficiaries")]
    [Authorize(Roles = "Company")]
    public IActionResult GetOutboundBeneficiaries()
    {
        var allBeneficiaries = companyServices.GetAllOutboundBeneficiaries();
        var getBeneficiaries = mapper.Map<List<GetAllbeneficiariesDto>>(allBeneficiaries);
        return Ok(getBeneficiaries);
    }

    [HttpPost("add-outbound-beneficiaries")]
    [Authorize(Roles = "Company")]
    public IActionResult AddOutboundBeneficiaries([FromForm] AddBeneficiaryDto addBeneficiaryDto)
    {
        var emailClaim = _httpContextAccessor.HttpContext?.User?.Claims
            .FirstOrDefault(c => c.Type == "Id");

        var companyEmail = emailClaim?.Value;

        if (string.IsNullOrEmpty(companyEmail))
            return Unauthorized("Company email not found in token.");
        var beneficiaries = mapper.Map<Beneficiary>(addBeneficiaryDto);
        var newbeneficiaries = companyServices.AddOutbouBeneficiaries(beneficiaries, companyEmail);
        return Ok("beneficiary Added Successfully");
    }

    [HttpPost("add-new-transaction")]
    [Authorize(Roles = "Company")]
    public IActionResult AddTransactions([FromBody] AddTransactionDto addTransactionDto)
    {
        var emailClaim = _httpContextAccessor.HttpContext?.User?.Claims
            .FirstOrDefault(c => c.Type == "Id");

        var companyEmail = emailClaim?.Value;

        if (string.IsNullOrEmpty(companyEmail))
            return Unauthorized("Company email not found in token.");
        var transactions = mapper.Map<Transaction>(addTransactionDto);
        var newTransaction = companyServices.AddTrasaction(transactions, companyEmail);
        return Ok("Transaction Added Successfully");
    }

    [HttpGet("all-employees")]
    [Authorize(Roles = "Company")]
    public IActionResult GetAllEmployees()
    {
        var allEmployees = companyServices.GetAllEmployees();
        var getEmployees = mapper.Map<List<GetAllEmployeesDto>>(allEmployees);
        return Ok(getEmployees);
    }

    [HttpPost("upload-csv")]
    [Authorize(Roles = "Company")]
    public async Task<IActionResult> UploadEmployeesFromCsv(IFormFile file)
    {
        var emailClaim = _httpContextAccessor.HttpContext?.User?.Claims
            .FirstOrDefault(c => c.Type == "Id");

        var companyEmail = emailClaim?.Value;

        if (string.IsNullOrEmpty(companyEmail))
            return Unauthorized("Company email not found in token.");
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        var result = await companyServices.AddEmployeesByCSV(file, companyEmail);
        return Ok(new { message = result });
    }

    [HttpPost("bulk-salary-disbursement")]
    [Authorize(Roles = "Company")]
    public async Task<IActionResult> DisburseSalaryToSelectedEmployees([FromBody] List<SalaryDisburesement> employees)
    {
        var emailClaim = _httpContextAccessor.HttpContext?.User?.Claims
            .FirstOrDefault(c => c.Type == "Id");

        var companyEmail = emailClaim?.Value;

        if (string.IsNullOrEmpty(companyEmail))
            return Unauthorized("Company email not found in token.");

        var result = await companyServices.DisburseSalaryToAllEmployees(companyEmail, employees);
        return Ok(new { message = result });
    }

    
}