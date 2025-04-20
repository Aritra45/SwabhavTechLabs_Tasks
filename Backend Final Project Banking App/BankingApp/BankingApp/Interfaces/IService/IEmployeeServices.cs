using BankingApp.Model.Entity;

namespace BankingApp.Interfaces.IService
{
    public interface IEmployeeServices
    {
        public List<Employee> GetAllEmployees();
        public Task<String> AddEmployeesByCSV(IFormFile csvFile, string companyEmail);
        //public Task<Employee> AddEmployeesTransactionSalary(Employee employee);
        public Task<string> DisburseSalaryToAllEmployees(string companyEmail);

    }
}
