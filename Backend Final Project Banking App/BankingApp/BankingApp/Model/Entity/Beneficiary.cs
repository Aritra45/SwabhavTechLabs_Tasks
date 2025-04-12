using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.Entity
{
    public class Beneficiary
    {
        [Key]
        public int BeneficiaryId { get; set; }
        [NotNull]
        public string BeneficiaryCompanyName { get; set; }
        [NotNull]
        public string BankAccountNumber { get; set; }
        [NotNull]
        public string BankName { get; set; }
        [NotNull]
        public string CompanyEmail { get; set; }
        public Company Company { get; set; }
    }
}
