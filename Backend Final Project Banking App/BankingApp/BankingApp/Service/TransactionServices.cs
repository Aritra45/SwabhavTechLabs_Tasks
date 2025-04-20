using BankingApp.Database;
using BankingApp.Interfaces.IRepository;
using BankingApp.Interfaces.IService;
using BankingApp.Model.CompanyDto;
using BankingApp.Model.Entity;
using BankingApp.Model.TrasactionDto;


namespace BankingApp.Service
{
    public class TransactionServices : ITransactionServices
    {
        private readonly IGenericRepository<Transaction> repository;
        MyContext context;
        IBeneficiaryServices beneficiaryServices;
        public TransactionServices(IGenericRepository<Transaction> transactionRepository, MyContext context, IBeneficiaryServices beneficiaryServices)
        {
            this.context = context;
            this.repository = transactionRepository;
            this.beneficiaryServices = beneficiaryServices;
        }

        public async Task<Transaction> AddTrasaction(Transaction transaction)
        {
            var transactionEntity = new Transaction
            {
                TransferFromCompanyEmail = transaction.TransferFromCompanyEmail,
                TransferToCompanyEmail = transaction.TransferToCompanyEmail,
                TransactionAmount = transaction.TransactionAmount,
                PaymentDate = DateTime.Now,
                Status = "Pending"
            };

            var beneficiaries = beneficiaryServices.GetAllBeneficiaries();

            bool isValidBeneficiary = beneficiaries
                .Any(b => b.BeneficiaryCompanyEmail == transaction.TransferToCompanyEmail &&
                b.CompanyEmail == transaction.TransferFromCompanyEmail);

            if (isValidBeneficiary)
            {
                await repository.AddAsync(transactionEntity);
                return transactionEntity;
            }
            else
            {
                throw new NullReferenceException();
            }
        }


        public List<Transaction> GetAllTransactions()
        {
            var transactions = repository.GetAllAsync();
            return transactions.ToList();
        }

        public List<Transaction> GetAllPendingTransactions()
        {
            var transactions = repository.GetAllAsync();
            return transactions.Where(transaction => transaction.Status == "Pending").ToList();
        }

        public Transaction UpdatePendingTransaction(int transactionId, UpdatePendingTransactionDto updatePendingTransactionDto)
        {
            var transactionEntity = repository.GetByID(transactionId);
            if (transactionEntity != null)
            {
                transactionEntity.Status = updatePendingTransactionDto.Status;
                repository.Update(transactionEntity);
                return transactionEntity;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        
    }
}
