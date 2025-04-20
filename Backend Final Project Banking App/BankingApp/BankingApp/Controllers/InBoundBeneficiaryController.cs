using AutoMapper;
using BankingApp.Interfaces.IService;
using BankingApp.Mapper;
using BankingApp.Model.BeneficiaryDto;
using BankingApp.Model.Entity;
using BankingApp.Model.UserDtos;
using BankingApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InBoundBeneficiaryController : ControllerBase
    {
        IBeneficiaryServices beneficiaryServices;
        IMapper mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public InBoundBeneficiaryController(IBeneficiaryServices beneficiaryServices, IHttpContextAccessor httpContextAccessor)
        {
            this.beneficiaryServices = beneficiaryServices;
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            mapper = config.CreateMapper();
            this.mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("all-inbound-beneficiaries")]
        [Authorize(Roles = "Company")]
        public IActionResult GetAllInboundBeneficiaries()
        {
            var allBeneficiaries = beneficiaryServices.GetAllInboundBeneficiaries();
            var getBeneficiaries = mapper.Map<List<GetAllbeneficiariesDto>>(allBeneficiaries);
            return Ok(getBeneficiaries);
        }

        [HttpPost("add-inbound-beneficiaries")]
        [Authorize(Roles = "Company")]
        public IActionResult AddInboundBeneficiaries([FromForm] AddBeneficiaryDto addBeneficiaryDto)
        {
            var emailClaim = _httpContextAccessor.HttpContext?.User?.Claims
                .FirstOrDefault(c => c.Type == "Id");

            var companyEmail = emailClaim?.Value;

            if (string.IsNullOrEmpty(companyEmail))
                return Unauthorized("Company email not found in token.");
            var beneficiaries = mapper.Map<Beneficiary>(addBeneficiaryDto);
            var newbeneficiaries = beneficiaryServices.AddInbouBeneficiaries(beneficiaries, companyEmail);
            return Ok("beneficiary Added Successfully");
        }
    }
}
