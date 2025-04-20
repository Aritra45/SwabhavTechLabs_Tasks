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
        public TransactionController(ITransactionServices transactionServices)
        {
            this.transactionServices = transactionServices;
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            mapper = config.CreateMapper();
            this.mapper = mapper;
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
            var transactions = mapper.Map<Transaction>(addTransactionDto);
            var newTransaction = transactionServices.AddTrasaction(transactions);
            return Ok("Transaction Added Successfully");
        }
    }
}
