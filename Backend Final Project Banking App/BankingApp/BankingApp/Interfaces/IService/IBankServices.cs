using BankingApp.Model.BankDto;
using BankingApp.Model.Entity;

namespace BankingApp.Interfaces.IService
{
    public interface IBankServices
    {
        public List<Bank> GetAllBanks();
        public List<Bank> GetAllsBanks();
        public Task<Bank> AddBank(Bank bank);
        public Bank UpdateBankPassword(string bankEmail, UpdateBankPasswordDto updateBankPasswordDto);
        public Bank GetByEmail(string bankEmail);
        public Task DeleteBank(string bankEmail);
    }
}
