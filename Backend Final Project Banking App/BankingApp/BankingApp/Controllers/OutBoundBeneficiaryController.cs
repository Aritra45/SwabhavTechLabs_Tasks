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
        public OutBoundBeneficiaryController(IBeneficiaryServices beneficiaryServices)
        {
            this.beneficiaryServices = beneficiaryServices;
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            mapper = config.CreateMapper();
            this.mapper = mapper;
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
            var beneficiaries = mapper.Map<Beneficiary>(addBeneficiaryDto);
            var newbeneficiaries = beneficiaryServices.AddOutbouBeneficiaries(beneficiaries);
            return Ok("beneficiary Added Successfully");
        }


    }
}
