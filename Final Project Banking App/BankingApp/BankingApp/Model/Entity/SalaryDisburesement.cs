using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.Entity
{
    public class SalaryDisburesement
    {
        [Key]
        public int TransactionId { get; set; }
        [NotNull]
        public string EmployeeEmail { get; set; }
        [NotNull]
        public decimal Amount { get; set; }
        [NotNull]
        public DateTime TransactionDate { get; set; }
        [NotNull]
        public string CompanyEmail { get; set; }
    }
}
