using BankingApp.Model.BankDto;
using BankingApp.Model.BeneficiaryDto;
using BankingApp.Model.CompanyDto;
using BankingApp.Model.EmployeeDto;
using BankingApp.Model.Entity;
using BankingApp.Model.TrasactionDto;

namespace BankingApp.Interfaces.IService
{
    public interface IUserServices
    {
        public List<User> GetAllUsers();
        public List<User> GetAllsUsers();
        public Task<User> AddUser(User user, string superAdminEmail);
        public Task<User> AddSuperAdmin(User user, string superAdminEmail);
        public Task DeleteUsers(string UserEmail);


        //bank
        public List<Bank> GetAllBanks();
        public List<Bank> GetAllsBanks();
        public Task<Bank> AddBank(Bank bank);
        public Bank UpdateBankPassword(string bankEmail, UpdateBankPasswordDto updateBankPasswordDto);
        public Bank GetByEmail(string bankEmail);
        public Task DeleteBank(string bankEmail);

        //company
        public List<Company> GetAllNotAprovedCompanies();
        public Company UpdateNotAprovedCompanies(string company, UpdateNotApprovedDto updateNotApprovedDto);

        //transaction
        public List<Transaction> GetAllPendingTransactions();
        public Transaction UpdatePendingTransaction(int transactionId, UpdatePendingTransactionDto updatePendingTransactionDto);

        //outbound
        public List<Beneficiary> GetAllOutboundNotApprovedBeneficiaries();
        public Beneficiary UpdateOutboundNotApprovedBeneficiaries(string beneficiaryEmail, UpdateNotApprovedBeneficiaryDto updateNotApprovedBeneficiaryDto);

        //employee
        public List<SalaryDisburesement> GetAllPendingSalary();
        public SalaryDisburesement UpdatePendingSalary(int transactionId, UpdatePendingSalaryDto updatePendingSalaryDto);
    }
}
