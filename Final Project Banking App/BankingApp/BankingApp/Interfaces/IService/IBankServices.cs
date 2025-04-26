using BankingApp.Model.BankDto;
using BankingApp.Model.Entity;

namespace BankingApp.Interfaces.IService
{
    public interface IBankServices
    {
        public List<Transaction> GetAllTransactions();
    }
}
