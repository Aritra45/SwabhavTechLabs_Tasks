using BankingApp.Model.BankDto;
using BankingApp.Model.BeneficiaryDto;
using BankingApp.Model.Entity;

namespace BankingApp.Interfaces.IService
{
    public interface IBeneficiaryServices
    {
        public List<Beneficiary> GetAllBeneficiaries();
        public List<Beneficiary> GetAllInboundBeneficiaries();
        public List<Beneficiary> GetAllOutboundBeneficiaries();
        public List<Beneficiary> GetAllOutboundNotApprovedBeneficiaries();
        public Task<Beneficiary> AddInbouBeneficiaries(Beneficiary beneficiary, string companyEmail);
        public Task<Beneficiary> AddOutbouBeneficiaries(Beneficiary beneficiary, string companyEmail);
        public Beneficiary UpdateOutboundNotApprovedBeneficiaries(string beneficiaryEmail, UpdateNotApprovedBeneficiaryDto updateNotApprovedBeneficiaryDto);
        //public Beneficiary UpdateBeneficiariesIFSCNumber(int beneficiaryId, UpdateBankPasswordDto updateBankPasswordDto);
        //public Beneficiary GetByID(int beneficiaryId);
        //public Task DeleteBeneficiaries(string beneficiaryEmail);
    }
}
