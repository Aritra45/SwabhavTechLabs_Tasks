using BankingApp.Interfaces.IRepository;
using BankingApp.Model.BankDto;
using BankingApp.Model.CompanyDto;
using BankingApp.Model.Entity;
using System.Net;
using System.Net.Mail;

public interface ICompanyService
{
    Task<string> RegisterAsync(CompanyRegisterDto dto);
    Task<bool> VerifyOtpAsync(OtpVerificationDto dto);
    public Task<string> ResendOtpAsync(string companyEmail);


    public List<Company> GetAprovedCompanies();
    public List<Company> GetAllCompanies();

    public List<Beneficiary> GetAllInboundBeneficiaries();
    public Task<Beneficiary> AddInbouBeneficiaries(Beneficiary beneficiary, string companyEmail);

    public List<Beneficiary> GetAllBeneficiaries();

    public List<Beneficiary> GetAllOutboundBeneficiaries();


    public Task<Beneficiary> AddOutbouBeneficiaries(Beneficiary beneficiary, string companyEmail);

    public Task<Transaction> AddTrasaction(Transaction transaction, string companyEmail);
    public List<Transaction> GetAllCompanyTransaction(string companyEmail);

    public List<Employee> GetAllEmployees();
    public Task<String> AddEmployeesByCSV(IFormFile csvFile, string companyEmail);
    public Task<string> DisburseSalaryToAllEmployees(string companyEmail, List<SalaryDisburesement> employees);

    

}
