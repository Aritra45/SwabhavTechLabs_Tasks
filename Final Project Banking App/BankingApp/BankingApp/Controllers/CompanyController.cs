using AutoMapper;
using BankingApp.Interfaces.IService;
using BankingApp.Mapper;
using BankingApp.Model.BankDto;
using BankingApp.Model.BeneficiaryDto;
using BankingApp.Model.CompanyDto;
using BankingApp.Model.Entity;
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
    public CompanyController(ICompanyService companyServices)
    {
        this.companyServices = companyServices;
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        mapper = config.CreateMapper();
        this.mapper = mapper;
    }

    [HttpGet("all-pending-companies")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAllNotApprovedCompanies()
    {
        var allCompanies = companyServices.GetAllNotAprovedCompanies();
        var getCompanies = mapper.Map<List<GetAllNotApprovedCompanies>>(allCompanies);
        return Ok(getCompanies);
    }

    [HttpPut("update-pending-companies/{companyEmail}")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateBankPassword(string companyEmail, [FromBody] UpdateNotApprovedDto UpdateNotApprovedDto)
    {
        var bankEntity = companyServices.UpdateNotAprovedCompanies(companyEmail, UpdateNotApprovedDto);
        return Ok("Company Updated Successfully");
    }

    [HttpGet("all-companies")]
    [Authorize(Roles = "Company")]
    public IActionResult GetAllInboundBeneficiaries()
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
}