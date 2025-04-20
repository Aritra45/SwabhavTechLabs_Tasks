using AutoMapper;
using BankingApp.Interfaces.IService;
using BankingApp.Mapper;
using BankingApp.Model.BankDto;
using BankingApp.Model.BeneficiaryDto;
using BankingApp.Model.CompanyDto;
using BankingApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutBoundBeneficiaryController : ControllerBase
    {
        IBeneficiaryServices beneficiaryServices;
        IMapper mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OutBoundBeneficiaryController(IBeneficiaryServices beneficiaryServices, IHttpContextAccessor httpContextAccessor)
        {
            this.beneficiaryServices = beneficiaryServices;
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            mapper = config.CreateMapper();
            this.mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("all-oubound-pending-beneficiaries")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllOutboundNotApprovedBeneficiaries()
        {
            var allbeneficiaries = beneficiaryServices.GetAllOutboundNotApprovedBeneficiaries();
            var getbeneficiaries = mapper.Map<List<GetAllOutboundNotApprovedBeneficiariesDto>>(allbeneficiaries);
            return Ok(getbeneficiaries);
        }

        [HttpPut("update-pending-beneficiaries/{beneficiaryEmail}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateOutboundNotApprovedBeneficiaries(string beneficiaryEmail, UpdateNotApprovedBeneficiaryDto updateNotApprovedBeneficiaryDto)
        {
            var beneficiaryEntity = beneficiaryServices.UpdateOutboundNotApprovedBeneficiaries(beneficiaryEmail, updateNotApprovedBeneficiaryDto);
            return Ok("Beneficiary Updated Successfully");
        }
        

        [HttpGet("all-oubound-beneficiaries")]
        [Authorize(Roles = "Company")]
        public IActionResult GetOutboundBeneficiaries()
        {
            var allBeneficiaries = beneficiaryServices.GetAllOutboundBeneficiaries();
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
            var newbeneficiaries = beneficiaryServices.AddOutbouBeneficiaries(beneficiaries, companyEmail);
            return Ok("beneficiary Added Successfully");
        }


    }
}
