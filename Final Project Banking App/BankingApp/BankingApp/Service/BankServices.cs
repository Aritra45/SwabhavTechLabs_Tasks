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
        private readonly IGenericRepository<Transaction> trans_repository;
        MyContext context;
        private readonly IServiceProvider serviceProvider;
        public BankServices(IGenericRepository<Bank> bankRepository, MyContext context, IServiceProvider serviceProvider, IGenericRepository<Transaction> trans_repository)
        {
            this.context = context;
            this.repository = bankRepository;
            this.serviceProvider = serviceProvider;
            this.trans_repository = trans_repository;
        }

        public List<Transaction> GetAllTransactions()
        {

            var transactions = trans_repository.GetAllAsync();
            return transactions.ToList();
        }
    }
}

