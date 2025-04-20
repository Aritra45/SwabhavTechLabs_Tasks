using BankingApp.Database;
using BankingApp.Interfaces.IRepository;
using BankingApp.Interfaces.IService;
using BankingApp.Model.BankDto;
using BankingApp.Model.Entity;

namespace BankingApp.Service
{
    public class BankServices : IBankServices
    {
        private readonly IGenericRepository<Bank> repository;
        MyContext context;
        private readonly IServiceProvider serviceProvider;
        public BankServices(IGenericRepository<Bank> bankRepository, MyContext context, IServiceProvider serviceProvider)
        {
            this.context = context;
            this.repository = bankRepository;
            this.serviceProvider = serviceProvider;
        }

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
                .Any(a=> a.UserEmail == bank.BankEmail);

            var companyService = serviceProvider.GetRequiredService<ICompanyService>();
            var companyEntity = companyService.GetAllCompanies();
            bool isValidForCompany = companyEntity
                .Any(c => c.CompanyEmail == bank.BankEmail);

            if (!isValidForAdmin && !isValidForCompany)
            {
                await repository.AddAsync(bankEntity);
                return bankEntity;
            }
            else
            {
                throw new System.Exception("Email Already Used");
            }
        }

        public async Task DeleteBank(string bankEmail)
        {
            var bank = repository.GetByEmail(bankEmail);
            if (bank != null)
            {
                bank.IsActive = false;
                repository.Delete(bank);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public List<Bank> GetAllBanks()
        {
            var banks = repository.GetAllAsync();
            return banks.Where(bank => bank.IsActive == true).ToList();
        }

        public List<Bank> GetAllsBanks()
        {
            var banks = repository.GetAllAsync();
            return banks.ToList();
        }

        public Bank GetByEmail(string bankEmail)
        {
            var bank = repository.GetByEmail(bankEmail);
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
            var bankEntity = repository.GetByEmail(bankEmail);
            if (bankEntity != null)
            {
                if (updateBankPasswordDto.CurrentPassword == bankEntity.BankPassword)
                {
                    bankEntity.BankPassword = updateBankPasswordDto.NewPassword;
                    if(updateBankPasswordDto.ConfirmPassword == updateBankPasswordDto.NewPassword)
                    {
                        repository.Update(bankEntity);
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
    }
}

