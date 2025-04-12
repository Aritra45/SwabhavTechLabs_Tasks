using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.Entity
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [NotNull]
        public decimal TransactionAmount { get; set; }
        [NotNull]
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        [NotNull]
        public string CompanyEmail { get; set; }
        [NotNull]
        public Company Company { get; set; }

        public int BeneficiaryId { get; set; }
        public Beneficiary Beneficiary { get; set; }
    }
}
