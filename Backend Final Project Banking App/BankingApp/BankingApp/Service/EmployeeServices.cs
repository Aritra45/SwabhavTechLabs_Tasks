using System.Formats.Asn1;
using System.Globalization;
using BankingApp.Database;
using BankingApp.Interfaces.IRepository;
using BankingApp.Interfaces.IService;
using BankingApp.Model.Entity;
using CsvHelper;
using CsvHelper.Configuration;

namespace BankingApp.Service
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IGenericRepository<Employee> repository;
        MyContext context;
        //private readonly IServiceProvider serviceProvider;
        public EmployeeServices(IGenericRepository<Employee> employeeRepository, MyContext context)
        {
            this.context = context;
            this.repository = employeeRepository;
            //this.serviceProvider = serviceProvider;
        }

        public async Task<string> AddEmployeesByCSV(IFormFile csvFile, string companyEmail)
        {
            if (csvFile == null || csvFile.Length == 0)
                return "CSV file is empty.";

            var employees = new List<Employee>();
            var existingEmails = context.Employees.Select(e => e.EmployeeEmail).ToHashSet(); // Fast lookup

            using (var stream = new StreamReader(csvFile.OpenReadStream()))
            using (var csvReader = new CsvReader(stream, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null
            }))
            {
                var csvRecords = csvReader.GetRecords<dynamic>();

                foreach (var record in csvRecords)
                {
                    try
                    {
                        string email = Convert.ToString(record.EmployeeEmail);
                        if (existingEmails.Contains(email)) 
                            continue;
                        
                        var employee = new Employee
                        {
                            EmployeeEmail = email,
                            EmployeeFullName = Convert.ToString(record.EmployeeFullName),
                            EmployeeBankAccountNumber = Convert.ToString(record.EmployeeBankAccountNumber),
                            EmployeeIFSCNumber = Convert.ToString(record.EmployeeIFSCNumber),
                            EmployeeSalaryAmount = Convert.ToDecimal(record.EmployeeSalaryAmount),
                            IsActive = Convert.ToBoolean(record.IsActive),
                            CompanyEmail = Convert.ToString(record.CompanyEmail)
                        };

                        employees.Add(employee);
                    }
                    catch (System.Exception ex)
                    {
                        throw new System.Exception("Check CSV File: " + ex.Message);
                    }
                }
            }

            await context.Employees.AddRangeAsync(employees);
            await context.SaveChangesAsync();

            return $"{employees.Count} new employees successfully uploaded (duplicates skipped).";
        }



        public Task<Employee> AddEmployeesTransactionSalary(Employee employee)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = repository.GetAllAsync();
            return employees.Where(employee => employee.IsActive == true).ToList();
        }

        public async Task<string> DisburseSalaryToAllEmployees(string companyEmail)
        {
            var employees = context.Employees
                .Where(e => e.IsActive && e.CompanyEmail == companyEmail)
                .ToList();

            if (!employees.Any())
                return "No active employees found for this company.";

            int successfulDisbursements = 0;
            var disbursementRecords = new List<SalaryDisburesement>();

            foreach (var emp in employees)
            {
                try
                {
                    
                    Console.WriteLine($"Transferring {emp.EmployeeSalaryAmount:C} to {emp.EmployeeFullName} ({emp.EmployeeBankAccountNumber})");

                    
                    var disbursement = new SalaryDisburesement
                    {
                        EmployeeEmail = emp.EmployeeEmail,
                        Amount = emp.EmployeeSalaryAmount,
                        TransactionDate = DateTime.UtcNow,
                        CompanyEmail = companyEmail
                    };

                    disbursementRecords.Add(disbursement);
                    successfulDisbursements++;
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine($"Failed to disburse salary to {emp.EmployeeEmail}: {ex.Message}");
                    
                }
            }

           
            if (disbursementRecords.Any())
            {
                await context.SalaryDisburesements.AddRangeAsync(disbursementRecords);
                await context.SaveChangesAsync();
            }

            return $"Salary disbursed to {successfulDisbursements} out of {employees.Count} employees.";
        }


    }
}
