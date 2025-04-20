using BankingApp.Model.BankDto;
using BankingApp.Model.CompanyDto;
using BankingApp.Model.Entity;
using BankingApp.Model.TrasactionDto;

namespace BankingApp.Interfaces.IService
{
    public interface ITransactionServices
    {
        public List <Transaction> GetAllTransactions();
        public List<Transaction> GetAllPendingTransactions();

        public Task <Transaction> AddTrasaction(Transaction transaction, string companyEmail);
        public Transaction UpdatePendingTransaction(int transactionId, UpdatePendingTransactionDto updatePendingTransactionDto);
    }
}
