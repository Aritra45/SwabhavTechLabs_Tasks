using AutoMapper;
using BankingApp.Interfaces.IService;
using BankingApp.Mapper;
using BankingApp.Model.BankDto;
using BankingApp.Model.CompanyDto;
using BankingApp.Model.Entity;
using BankingApp.Model.TrasactionDto;
using BankingApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        ITransactionServices transactionServices;
        IMapper mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TransactionController(ITransactionServices transactionServices, IHttpContextAccessor httpContextAccessor)
        {
            this.transactionServices = transactionServices;
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            mapper = config.CreateMapper();
            this.mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("all-pending-transactions")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllPendingTransactions()
        {
            var allTransactions = transactionServices.GetAllPendingTransactions();
            return Ok(allTransactions);
        }

        [HttpPut("update-pending-transactions/{transactionID}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdatePendingTransaction(int transactionID, UpdatePendingTransactionDto updatePendingTransactionDto)
        {
            var transactionEntity = transactionServices.UpdatePendingTransaction(transactionID, updatePendingTransactionDto);
            return Ok("Transaction Successfull");
        }

        [HttpGet("all-transactions")]
        [Authorize(Roles = "Bank")]
        public IActionResult GetAllTransactions()
        {
            var allTransactions = transactionServices.GetAllTransactions();
            return Ok(allTransactions);
        }

        [HttpPost("add-new-transaction")]
        [Authorize(Roles = "Company")]
        public IActionResult AddTransactions([FromForm] AddTransactionDto addTransactionDto)
        {
            var emailClaim = _httpContextAccessor.HttpContext?.User?.Claims
                .FirstOrDefault(c => c.Type == "Id");

            var companyEmail = emailClaim?.Value;

            if (string.IsNullOrEmpty(companyEmail))
                return Unauthorized("Company email not found in token.");
            var transactions = mapper.Map<Transaction>(addTransactionDto);
            var newTransaction = transactionServices.AddTrasaction(transactions, companyEmail);
            return Ok("Transaction Added Successfully");
        }
    }
}
