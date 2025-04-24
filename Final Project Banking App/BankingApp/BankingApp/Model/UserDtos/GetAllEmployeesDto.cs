using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.UserDtos
{
    public class GetAllEmployeesDto
    {
        public string EmployeeEmail { get; set; }

        public string EmployeeFullName { get; set; }

        public string EmployeeBankAccountNumber { get; set; }
        public string EmployeeIFSCNumber { get; set; }

        public string EmployeeSalaryAmount { get; set; }
    }
}
