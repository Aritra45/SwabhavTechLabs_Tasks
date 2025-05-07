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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly MyContext _context;
        public UserController(IUserServices userServices, MyContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.userServices = userServices;
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            mapper = config.CreateMapper();
            this.mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("all-admins")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult GetAllUsers()
        {
            var allUsers = userServices.GetAllUsers();
            var getUsers = mapper.Map<List<GetAllUsersDto>>(allUsers);
            return Ok(getUsers);
        }

        [HttpPost("add-admin")]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult AddUsers([FromBody] AddUserDto addUserDto, string superAdminEmail)
        {
            //var users = mapper.Map<User>(addUserDto);
            //var newUser = userServices.AddUser(users);
            string passwd = BCrypt.Net.BCrypt.EnhancedHashPassword(addUserDto.UserPassword);
            addUserDto.UserPassword = passwd;
            var user = mapper.Map<User>(addUserDto);
            var userEntity = userServices.AddUser(user, superAdminEmail);
            if (userEntity.Status.ToString() != "Faulted")
            {
                return Ok("Admin Added Successfully");
            }
            else
            {
                return UnprocessableEntity("Email Already Used");
            }
        }

        [HttpPost("add-super-admin")]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult AddSuperAdmin([FromBody] AddUserDto addUserDto)
        {
            //var users = mapper.Map<User>(addUserDto);
            //var newUser = userServices.AddUser(users);
            var emailClaim = _httpContextAccessor.HttpContext?.User?.Claims
            .FirstOrDefault(c => c.Type == "Id");

            string superAdminEmail = emailClaim?.Value;
            string passwd = BCrypt.Net.BCrypt.EnhancedHashPassword(addUserDto.UserPassword);
            addUserDto.UserPassword = passwd;
            var user = mapper.Map<User>(addUserDto);
            var userEntity = userServices.AddSuperAdmin(user, superAdminEmail);
            if (userEntity.Status.ToString() != "Faulted")
            {
                return Ok("Super Admin Added Successfully");
            }
            else
            {
                return UnprocessableEntity("Email Already Used");
            }
        }

        [HttpDelete("remove-admin-access/{UserEmail}")]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult DeleteEmployees(string UserEmail)
        {
            userServices.DeleteUsers(UserEmail);
            return Ok(new { message = "User deleted successfully" });
        }

        [HttpGet("all-banks")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult GetAllBanks()
        {
            var allBanks = userServices.GetAllBanks();
            var getBanks = mapper.Map<List<GetAllBankDto>>(allBanks);
            return Ok(getBanks);
        }

        [HttpPost("add-new-bank")]
        [Authorize(Roles = "SuperAdmin, Admin")]
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
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult DeleteBanks(string bankEmail)
        {
            userServices.DeleteBank(bankEmail);
            return Ok("Bank Deleted Successfully");
        }

        [HttpPut("update-bank-password/{bankEmail}")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult UpdateBankPassword(string bankEmail, [FromBody] UpdateBankPasswordDto updateBankPasswordDto)
        {
            var bankEntity = userServices.UpdateBankPassword(bankEmail, updateBankPasswordDto);
            return Ok("Password Updated Successfully");
        }

        [HttpGet("get-by-bank-email/{bankEmail}")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult GetByEmail(string bankEmail)
        {
            var bank = userServices.GetByEmail(bankEmail);
            var getBank = mapper.Map<GetAllBankDto>(bank);
            return Ok(getBank);
        }

        [HttpGet("all-pending-companies")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult GetAllNotApprovedCompanies()
        {
            var allCompanies = userServices.GetAllNotAprovedCompanies();
            var getCompanies = mapper.Map<List<GetAllNotApprovedCompanies>>(allCompanies);
            return Ok(getCompanies);
        }

        [HttpPut("update-pending-companies/{companyEmail}")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult UpdateBankPassword(string companyEmail, [FromBody] UpdateNotApprovedDto UpdateNotApprovedDto)
        {
            var bankEntity = userServices.UpdateNotAprovedCompanies(companyEmail, UpdateNotApprovedDto);
            return Ok("Company Updated Successfully");
        }

        [HttpGet("all-pending-transactions")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult GetAllPendingTransactions()
        {
            var allTransactions = userServices.GetAllPendingTransactions();
            return Ok(allTransactions);
        }

        [HttpPut("update-pending-transactions/{transactionID}")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult UpdatePendingTransaction(int transactionID, UpdatePendingTransactionDto updatePendingTransactionDto)
        {
            var transactionEntity = userServices.UpdatePendingTransaction(transactionID, updatePendingTransactionDto);
            return Ok("Transaction Successfull");
        }

        [HttpGet("all-oubound-pending-beneficiaries")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult GetAllOutboundNotApprovedBeneficiaries()
        {
            var allbeneficiaries = userServices.GetAllOutboundNotApprovedBeneficiaries();
            var getbeneficiaries = mapper.Map<List<GetAllOutboundNotApprovedBeneficiariesDto>>(allbeneficiaries);
            return Ok(getbeneficiaries);
        }

        [HttpPut("update-pending-beneficiaries/{beneficiaryEmail}")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult UpdateOutboundNotApprovedBeneficiaries(string beneficiaryEmail, UpdateNotApprovedBeneficiaryDto updateNotApprovedBeneficiaryDto)
        {
            var beneficiaryEntity = userServices.UpdateOutboundNotApprovedBeneficiaries(beneficiaryEmail, updateNotApprovedBeneficiaryDto);
            return Ok("Beneficiary Updated Successfully");
        }

        [HttpGet("all-logs")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> GetAllLogs(int pageNumber = 1, int pageSize = 5, string? search = "")
        {
            var query = _context.AuditLogs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(log =>
                    log.UserId.Contains(search) ||
                    log.Description.Contains(search)
                );
            }

            var totalLogs = await query.CountAsync();
            var logs = await query
                .OrderByDescending(log => log.AuditId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(new
            {
                totalItems = totalLogs,
                pageNumber,
                pageSize,
                logs
            });
        }


        [HttpGet("by-user/{userId}")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> GetLogsByUser(string userId)
        {
            var logs = await _context.AuditLogs
                .Where(log => log.UserId == userId)
                .OrderByDescending(log => log.Time)
                .ToListAsync();

            return Ok(logs);
        }

        [HttpGet("by-date")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> GetLogsByDate([FromQuery] DateTime date)
        {
            var logs = await _context.AuditLogs
                .Where(log => log.Time.Date == date.Date)
                .OrderByDescending(log => log.Time)
                .ToListAsync();

            return Ok(logs);
        }

        [HttpGet("all-pending-salary")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult GetAllPendingSalary()
        {
            var allsalary = userServices.GetAllPendingSalary();
            var getsalaries = mapper.Map<List<GetAllPendingSalaryDto>>(allsalary);
            return Ok(getsalaries);
        }

        [HttpPut("update-pending-salary/{transactionID}")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult UpdatePendingSalary(int transactionID, UpdatePendingSalaryDto updatePendingSalaryDto)
        {
            var transactionEntity = userServices.UpdatePendingSalary(transactionID, updatePendingSalaryDto);
            return Ok("Transaction Updated Successfully");
        }
    }
}
