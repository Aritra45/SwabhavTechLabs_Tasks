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
        public string Status {  get; set; }
        [NotNull]
        public DateTime PaymentDate { get; set; }
        [NotNull]
        public string TransferFromCompanyEmail { get; set; }
        [NotNull]
        public string TransferToCompanyEmail { get; set; }
        
    }
}
