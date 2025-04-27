using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.EmployeeDto
{
    public class GetAllPendingSalaryDto
    {
        public int TransactionId { get; set; }

        public string EmployeeEmail { get; set; }

        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
    }
}
