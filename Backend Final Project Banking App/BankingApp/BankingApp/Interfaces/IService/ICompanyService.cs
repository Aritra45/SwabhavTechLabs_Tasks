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
    public List<Company> GetAllNotAprovedCompanies();
    public List<Company> GetAprovedCompanies();
    public List<Company> GetAllCompanies();
    public Company UpdateNotAprovedCompanies(string company, UpdateNotApprovedDto updateNotApprovedDto);
}
