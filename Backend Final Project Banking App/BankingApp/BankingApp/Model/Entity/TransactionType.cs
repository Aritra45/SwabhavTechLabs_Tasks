using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.Entity
{
    public class TransactionType
    {
        [Key]
        public int TransactionTypeId { get; set; }
        [NotNull]
        public string TransactionTypeName { get; set; }
    }
}
