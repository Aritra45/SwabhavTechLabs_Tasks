using System.Collections.Generic;
using BankingApp.Database;
using BankingApp.Exception;
using BankingApp.Interfaces.IRepository;
using BankingApp.Interfaces.IService;
using BankingApp.Model.BankDto;
using BankingApp.Model.BeneficiaryDto;
using BankingApp.Model.CompanyDto;
using BankingApp.Model.EmployeeDto;
using BankingApp.Model.Entity;
using BankingApp.Model.TrasactionDto;

namespace BankingApp.Service
{
    public class UserServices : IUserServices
    {
        private readonly IGenericRepository<User> repository;
        private readonly IGenericRepository<Bank> bank_repository;
        private readonly IGenericRepository<Company> _companyRepo;
        private readonly IGenericRepository<Transaction> trans_repository;
        private readonly IGenericRepository<Beneficiary> out_repository;
        private readonly IGenericRepository<SalaryDisburesement> salary_repository;
        MyContext context;
        private readonly IServiceProvider serviceProvider;

        public UserServices(IGenericRepository<User> userRepository, MyContext context, IServiceProvider serviceProvider, IGenericRepository<Bank> bank_repository, IGenericRepository<Company> companyRepo, IGenericRepository<Transaction> trans_repository, IGenericRepository<Beneficiary> out_repository, IGenericRepository<SalaryDisburesement> salary_repository)
        {
            this.context = context;
            this.repository = userRepository;
            this.serviceProvider = serviceProvider;
            this.bank_repository = bank_repository;
            _companyRepo = companyRepo;
            this.trans_repository = trans_repository;
            this.out_repository = out_repository;
            this.salary_repository = salary_repository;
        }
        public async Task<User> AddUser(User user, string superAdminEmail)
        {
            var userEntity = new User
            {
                UserEmail = user.UserEmail,
                UserName = user.UserName,
                UserPassword = user.UserPassword,
                IsActive = true,
                RoleId = 1,
                SuperAdminEmail = superAdminEmail
            };
            var bankService = serviceProvider.GetRequiredService<IUserServices>();
            var bankEntity = bankService.GetAllsBanks();

            bool isValidForAdmin = bankEntity
                .Any(b => b.BankEmail == user.UserEmail);

            var companyService = serviceProvider.GetRequiredService<ICompanyService>();
            var companyEntity = companyService.GetAllCompanies();
            bool isValidForCompany = companyEntity
                .Any(c => c.CompanyEmail == user.UserEmail);

            if (!isValidForAdmin && !isValidForCompany)
            {
                await repository.AddAsync(userEntity);
                return userEntity;
            }
            else
            {
                throw new System.Exception("Email Already Used");
            } 
        }

        public async Task<User> AddSuperAdmin(User user)
        {
            var userEntity = new User
            {
                UserEmail = user.UserEmail,
                UserName = user.UserName,
                UserPassword = user.UserPassword,
                IsActive = true,
                RoleId = 4,
                SuperAdminEmail = ""
            };
            var bankService = serviceProvider.GetRequiredService<IUserServices>();
            var bankEntity = bankService.GetAllsBanks();

            bool isValidForAdmin = bankEntity
                .Any(b => b.BankEmail == user.UserEmail);

            var companyService = serviceProvider.GetRequiredService<ICompanyService>();
            var companyEntity = companyService.GetAllCompanies();
            bool isValidForCompany = companyEntity
                .Any(c => c.CompanyEmail == user.UserEmail);

            if (!isValidForAdmin && !isValidForCompany)
            {
                await repository.AddAsync(userEntity);
                return userEntity;
            }
            else
            {
                throw new System.Exception("Email Already Used");
            }
        }

        public async Task DeleteUsers(string UserEmail)
        {
            var user = repository.GetByEmail(UserEmail);
            if (user != null)
            {
                user.IsActive = false;
                repository.Update(user);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public List<User> GetAllUsers()
        {
            var users = repository.GetAllAsync();
            return users.Where(user => user.IsActive == true && user.RoleId == 1).ToList();
        }

        public List<User> GetAllsUsers()
        {
            var users = repository.GetAllAsync();
            return users.ToList();
        }

        //bank
        public async Task<Bank> AddBank(Bank bank)
        {
            var bankEntity = new Bank
            {
                BankEmail = bank.BankEmail,
                BankName = bank.BankName,
                BranchCode = bank.BranchCode,
                BankPassword = bank.BankPassword,
                BankAddress = bank.BankAddress,
                IsActive = true,
                RoleId = 2
            };

            var userService = serviceProvider.GetRequiredService<IUserServices>();
            var userEntity = userService.GetAllsUsers();
            bool isValidForAdmin = userEntity
                .Any(a => a.UserEmail == bank.BankEmail);

            var companyService = serviceProvider.GetRequiredService<ICompanyService>();
            var companyEntity = companyService.GetAllCompanies();
            bool isValidForCompany = companyEntity
                .Any(c => c.CompanyEmail == bank.BankEmail);

            if (!isValidForAdmin && !isValidForCompany)
            {
                await bank_repository.AddAsync(bankEntity);
                return bankEntity;
            }
            else
            {
                throw new System.Exception("Email Already Used");
            }
        }

        public async Task DeleteBank(string bankEmail)
        {
            var bank = bank_repository.GetByEmail(bankEmail);
            if (bank != null)
            {
                bank.IsActive = false;
                bank_repository.Update(bank);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public List<Bank> GetAllBanks()
        {
            var banks = bank_repository.GetAllAsync();
            return banks.Where(bank => bank.IsActive == true).ToList();
        }

        public List<Bank> GetAllsBanks()
        {
            var banks = bank_repository.GetAllAsync();
            return banks.ToList();
        }

        public Bank GetByEmail(string bankEmail)
        {
            var bank = bank_repository.GetByEmail(bankEmail);
            if (bank != null)
            {
                return bank;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public Bank UpdateBankPassword(string bankEmail, UpdateBankPasswordDto updateBankPasswordDto)
        {
            var bankEntity = bank_repository.GetByEmail(bankEmail);
            if (bankEntity != null)
            {
                if (BCrypt.Net.BCrypt.EnhancedVerify(updateBankPasswordDto.CurrentPassword, bankEntity.BankPassword))
                {

                    if (updateBankPasswordDto.ConfirmPassword == updateBankPasswordDto.NewPassword)
                    {
                        bankEntity.BankPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(updateBankPasswordDto.NewPassword);
                        bank_repository.Update(bankEntity);
                        return bankEntity;
                    }
                    else
                    {
                        throw new NullReferenceException();
                    }

                }
                else
                {
                    throw new NullReferenceException();
                }

            }
            else
            {
                throw new NullReferenceException();
            }


        }

        //company
        public List<Company> GetAllNotAprovedCompanies()
        {
            var companies = _companyRepo.GetAllAsync();
            return companies.Where(company => company.IsAproved == false && company.Remark == "").ToList();
        }

        public Company UpdateNotAprovedCompanies(string company, UpdateNotApprovedDto updateNotApprovedDto)
        {
            var companyEntity = _companyRepo.GetByEmail(company);
            if (companyEntity != null)
            {
                companyEntity.IsAproved = updateNotApprovedDto.IsAproved;
                companyEntity.Remark = updateNotApprovedDto.Remark;
                _companyRepo.Update(companyEntity);
                return companyEntity;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        //transaction
        public List<Transaction> GetAllPendingTransactions()
        {
            var transactions = trans_repository.GetAllAsync();
            return transactions.Where(transaction => transaction.Status == "Pending").ToList();
        }

        public Transaction UpdatePendingTransaction(int transactionId, UpdatePendingTransactionDto updatePendingTransactionDto)
        {
            var transactionEntity = trans_repository.GetByID(transactionId);
            if (transactionEntity != null)
            {
                transactionEntity.Status = updatePendingTransactionDto.Status;
                trans_repository.Update(transactionEntity);
                return transactionEntity;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        //outbound
        public List<Beneficiary> GetAllOutboundNotApprovedBeneficiaries()
        {
            var beneficiaries = out_repository.GetAllAsync();
            return beneficiaries.Where(beneficiary => beneficiary.BeneficiaryType == "Outbound" &&
            beneficiary.IsApproved == false).ToList();
        }

        public Beneficiary UpdateOutboundNotApprovedBeneficiaries(string beneficiaryEmail, UpdateNotApprovedBeneficiaryDto updateNotApprovedBeneficiary)
        {
            var beneficiaryEntity = out_repository.GetByEmail(beneficiaryEmail);
            if (beneficiaryEntity != null)
            {
                beneficiaryEntity.IsApproved = updateNotApprovedBeneficiary.IsApproved;
                out_repository.Update(beneficiaryEntity);
                return beneficiaryEntity;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public List<SalaryDisburesement> GetAllPendingSalary()
        {
            var salaries = salary_repository.GetAllAsync();
            return salaries.Where(salary => salary.Status == "Pending").ToList();
        }

        public SalaryDisburesement UpdatePendingSalary(int transactionId, UpdatePendingSalaryDto updatePendingSalaryDto)
        {
            var salaryEntity = salary_repository.GetByID(transactionId);
            if (salaryEntity != null)
            {
                salaryEntity.Status = updatePendingSalaryDto.Status;
                salary_repository.Update(salaryEntity);
                return salaryEntity;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
