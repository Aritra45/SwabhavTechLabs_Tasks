using System.Collections.Generic;
using BankingApp.Database;
using BankingApp.Exception;
using BankingApp.Interfaces.IRepository;
using BankingApp.Interfaces.IService;
using BankingApp.Model.Entity;

namespace BankingApp.Service
{
    public class UserServices : IUserServices
    {
        private readonly IGenericRepository<User> repository;
        MyContext context;
        private readonly IServiceProvider serviceProvider;

        public UserServices(IGenericRepository<User> userRepository, MyContext context, IServiceProvider serviceProvider)
        {
            this.context = context;
            this.repository = userRepository;
            this.serviceProvider = serviceProvider;
        }
        public async Task<User> AddUser(User user)
        {
            var userEntity = new User
            {
                UserEmail = user.UserEmail,
                UserName = user.UserName,
                UserPassword = user.UserPassword,
                IsActive = true,
                RoleId = 1,
            };
            var bankService = serviceProvider.GetRequiredService<IBankServices>();
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
                repository.Delete(user);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public List<User> GetAllUsers()
        {
            var users = repository.GetAllAsync();
            return users.Where(user => user.IsActive == true).ToList();
        }

        public List<User> GetAllsUsers()
        {
            var users = repository.GetAllAsync();
            return users.ToList();
        }
    }
}
