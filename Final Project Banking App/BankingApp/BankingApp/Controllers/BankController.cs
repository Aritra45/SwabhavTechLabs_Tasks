using AutoMapper;
using BankingApp.Exception;
using BankingApp.Interfaces.IService;
using BankingApp.Mapper;
using BankingApp.Model.BankDto;
using BankingApp.Model.Entity;
using BankingApp.Model.UserDtos;
using BankingApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        IBankServices bankServices;
        IMapper mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BankController(IBankServices bankServices, IHttpContextAccessor httpContextAccessor)
        {
            this.bankServices = bankServices;
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            mapper = config.CreateMapper();
            this.mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("all-banks")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllBanks()
        {
            var allBanks = bankServices.GetAllBanks();
            var getBanks = mapper.Map<List<GetAllBankDto>>(allBanks);
            return Ok(getBanks);
        }

        [HttpPost("add-new-bank")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddBanks([FromBody]  AddBankDto addBankDto)
        {            
            //var banks = mapper.Map<Bank>(addBankDto);
            //var newUser = bankServices.AddBank(banks);
            string passwd = BCrypt.Net.BCrypt.EnhancedHashPassword(addBankDto.BankPassword);
            addBankDto.BankPassword = passwd;
            var bank = mapper.Map<Bank>(addBankDto);
            var bankEntity = bankServices.AddBank(bank);
            if(bankEntity.Status.ToString() != "Faulted")
            {
                return Ok("Bank Added Successfully");
            }
            else
            {
                return UnprocessableEntity("Email Already Used");
            }
            
        }

        [HttpDelete("remove-bank-access/{bankEmail}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteBanks(string bankEmail)
        {
            bankServices.DeleteBank(bankEmail);
            return Ok("Bank Deleted Successfully");
        }

        [HttpPut("update-bank-password/{bankEmail}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateBankPassword(string bankEmail, [FromBody] UpdateBankPasswordDto updateBankPasswordDto)
        {
            var bankEntity = bankServices.UpdateBankPassword(bankEmail, updateBankPasswordDto);
            return Ok("Password Updated Successfully");
        }

        [HttpGet("get-by-bank-email/{bankEmail}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetByEmail(string bankEmail)
        {
            var bank = bankServices.GetByEmail(bankEmail);
            var getBank = mapper.Map<GetAllBankDto>(bank);
            return Ok(getBank);
        }
    }
}
