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
        public InBoundBeneficiaryController(IBeneficiaryServices beneficiaryServices)
        {
            this.beneficiaryServices = beneficiaryServices;
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            mapper = config.CreateMapper();
            this.mapper = mapper;
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
            var beneficiaries = mapper.Map<Beneficiary>(addBeneficiaryDto);
            var newbeneficiaries = beneficiaryServices.AddInbouBeneficiaries(beneficiaries);
            return Ok("beneficiary Added Successfully");
        }
    }
}
