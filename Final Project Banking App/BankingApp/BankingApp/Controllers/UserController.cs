using AutoMapper;
using BankingApp.Database;
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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserServices userServices;
        IMapper mapper;
        private readonly MyContext _context;
        public UserController(IUserServices userServices, MyContext context)
        {
            this.userServices = userServices;
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            mapper = config.CreateMapper();
            this.mapper = mapper;
            _context = context;
        }

        [HttpGet("all-admins")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllUsers()
        {
            var allUsers = userServices.GetAllUsers();
            var getUsers = mapper.Map<List<GetAllUsersDto>>(allUsers);
            return Ok(getUsers);
        }

        [HttpPost("add-admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddUsers([FromBody] AddUserDto addUserDto)
        {
            //var users = mapper.Map<User>(addUserDto);
            //var newUser = userServices.AddUser(users);
            string passwd = BCrypt.Net.BCrypt.EnhancedHashPassword(addUserDto.UserPassword);
            addUserDto.UserPassword = passwd;
            var user = mapper.Map<User>(addUserDto);
            var userEntity = userServices.AddUser(user);
            if (userEntity.Status.ToString() != "Faulted")
            {
                return Ok("User Added Successfully");
            }
            else
            {
                return UnprocessableEntity("Email Already Used");
            }
        }

        [HttpDelete("remove-admin-access/{UserEmail}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteEmployees(string UserEmail)
        {
            userServices.DeleteUsers(UserEmail);
            return Ok(new { message = "User deleted successfully" });
        }

        [HttpGet("all-banks")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllBanks()
        {
            var allBanks = userServices.GetAllBanks();
            var getBanks = mapper.Map<List<GetAllBankDto>>(allBanks);
            return Ok(getBanks);
        }

        [HttpPost("add-new-bank")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddBanks([FromBody] AddBankDto addBankDto)
        {
            //var banks = mapper.Map<Bank>(addBankDto);
            //var newUser = bankServices.AddBank(banks);
            string passwd = BCrypt.Net.BCrypt.EnhancedHashPassword(addBankDto.BankPassword);
            addBankDto.BankPassword = passwd;
            var bank = mapper.Map<Bank>(addBankDto);
            var bankEntity = userServices.AddBank(bank);
            if (bankEntity.Status.ToString() != "Faulted")
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
            userServices.DeleteBank(bankEmail);
            return Ok("Bank Deleted Successfully");
        }

        [HttpPut("update-bank-password/{bankEmail}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateBankPassword(string bankEmail, [FromBody] UpdateBankPasswordDto updateBankPasswordDto)
        {
            var bankEntity = userServices.UpdateBankPassword(bankEmail, updateBankPasswordDto);
            return Ok("Password Updated Successfully");
        }

        [HttpGet("get-by-bank-email/{bankEmail}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetByEmail(string bankEmail)
        {
            var bank = userServices.GetByEmail(bankEmail);
            var getBank = mapper.Map<GetAllBankDto>(bank);
            return Ok(getBank);
        }

        [HttpGet("all-pending-companies")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllNotApprovedCompanies()
        {
            var allCompanies = userServices.GetAllNotAprovedCompanies();
            var getCompanies = mapper.Map<List<GetAllNotApprovedCompanies>>(allCompanies);
            return Ok(getCompanies);
        }

        [HttpPut("update-pending-companies/{companyEmail}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateBankPassword(string companyEmail, [FromBody] UpdateNotApprovedDto UpdateNotApprovedDto)
        {
            var bankEntity = userServices.UpdateNotAprovedCompanies(companyEmail, UpdateNotApprovedDto);
            return Ok("Company Updated Successfully");
        }

        [HttpGet("all-pending-transactions")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllPendingTransactions()
        {
            var allTransactions = userServices.GetAllPendingTransactions();
            return Ok(allTransactions);
        }

        [HttpPut("update-pending-transactions/{transactionID}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdatePendingTransaction(int transactionID, UpdatePendingTransactionDto updatePendingTransactionDto)
        {
            var transactionEntity = userServices.UpdatePendingTransaction(transactionID, updatePendingTransactionDto);
            return Ok("Transaction Successfull");
        }

        [HttpGet("all-oubound-pending-beneficiaries")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllOutboundNotApprovedBeneficiaries()
        {
            var allbeneficiaries = userServices.GetAllOutboundNotApprovedBeneficiaries();
            var getbeneficiaries = mapper.Map<List<GetAllOutboundNotApprovedBeneficiariesDto>>(allbeneficiaries);
            return Ok(getbeneficiaries);
        }

        [HttpPut("update-pending-beneficiaries/{beneficiaryEmail}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateOutboundNotApprovedBeneficiaries(string beneficiaryEmail, UpdateNotApprovedBeneficiaryDto updateNotApprovedBeneficiaryDto)
        {
            var beneficiaryEntity = userServices.UpdateOutboundNotApprovedBeneficiaries(beneficiaryEmail, updateNotApprovedBeneficiaryDto);
            return Ok("Beneficiary Updated Successfully");
        }

        [HttpGet("all-logs")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllLogs()
        {
            var logs = await _context.AuditLogs
                .OrderByDescending(log => log.Time)
                .ToListAsync();

            return Ok(logs);
        }

        [HttpGet("by-user/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetLogsByUser(string userId)
        {
            var logs = await _context.AuditLogs
                .Where(log => log.UserId == userId)
                .OrderByDescending(log => log.Time)
                .ToListAsync();

            return Ok(logs);
        }

        [HttpGet("by-date")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetLogsByDate([FromQuery] DateTime date)
        {
            var logs = await _context.AuditLogs
                .Where(log => log.Time.Date == date.Date)
                .OrderByDescending(log => log.Time)
                .ToListAsync();

            return Ok(logs);
        }

        [HttpGet("all-pending-salary")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllPendingSalary()
        {
            var allsalary = userServices.GetAllPendingSalary();
            var getsalaries = mapper.Map<List<GetAllPendingSalaryDto>>(allsalary);
            return Ok(getsalaries);
        }

        [HttpPut("update-pending-salary/{transactionID}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdatePendingSalary(int transactionID, UpdatePendingSalaryDto updatePendingSalaryDto)
        {
            var transactionEntity = userServices.UpdatePendingSalary(transactionID, updatePendingSalaryDto);
            return Ok("Transaction Updated Successfully");
        }
    }
}
