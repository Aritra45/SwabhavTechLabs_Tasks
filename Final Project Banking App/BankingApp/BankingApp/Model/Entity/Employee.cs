using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.Entity
{
    public class Employee
    {
        [Key]
        public string EmployeeEmail { get; set; }
        [NotNull]
        public string EmployeeFullName { get; set; }
        [NotNull]
        public string EmployeeBankAccountNumber { get; set; }
        [NotNull]
        public string EmployeeIFSCNumber { get; set; }
        [NotNull]
        public decimal EmployeeSalaryAmount { get; set; }
        [NotNull]
        public bool IsActive { get; set; }
        [NotNull]
        public string CompanyEmail { get; set; }
    }
}
