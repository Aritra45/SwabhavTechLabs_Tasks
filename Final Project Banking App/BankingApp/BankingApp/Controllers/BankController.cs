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

        [HttpGet("all-transactions")]
        [Authorize(Roles = "Bank")]
        public IActionResult GetAllTransactions()
        {
            var allTransactions = bankServices.GetAllTransactions().OrderByDescending(t => t.TransactionId); ;
            return Ok(allTransactions);
        }
    }
}
