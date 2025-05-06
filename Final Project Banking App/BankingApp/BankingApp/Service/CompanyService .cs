using BankingApp.Model.Entity;
using BankingApp.Interfaces.IRepository;
using Microsoft.Extensions.Caching.Memory;
using BankingApp.Model.CompanyDto;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using BankingApp.Helper;
using BankingApp.Model.BankDto;
using BankingApp.Service;
using BankingApp.Interfaces.IService;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using BankingApp.Database;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

public class CompanyService : ICompanyService
{
    private readonly IGenericRepository<Company> _companyRepo;
    private readonly IGenericRepository<Beneficiary> repository;
    private readonly IGenericRepository<Transaction> trans_repository;
    private readonly IGenericRepository<Employee> emp_repository;
    private readonly IMemoryCache _cache;
    private readonly SmtpSettings _smtpSettings;
    private readonly Cloudinary _cloudinary;
    private readonly IPhotoService _photoService;
    private readonly IServiceProvider serviceProvider;
    private readonly IHttpContextAccessor _httpContextAccessor;
    MyContext context;

    public CompanyService(
        IGenericRepository<Company> companyRepo,
        IMemoryCache cache,
        IOptions<SmtpSettings> smtpOptions,
        IOptions<CloudinarySettings> cloudinaryOptions,
        IPhotoService photoService,
        IServiceProvider serviceProvider,
        IGenericRepository<Beneficiary> repository,
        IHttpContextAccessor httpContextAccessor,
        IGenericRepository<Transaction> trans_repository,
        IGenericRepository<Employee> emp_repository,
        MyContext context)
        
    {
        _companyRepo = companyRepo;
        _cache = cache;
        _smtpSettings = smtpOptions.Value;

        var acc = new Account(
            cloudinaryOptions.Value.CloudName,
            cloudinaryOptions.Value.ApiKey,
            cloudinaryOptions.Value.ApiSecret);
        _photoService = photoService;
        _cloudinary = new Cloudinary(acc);
        this.serviceProvider = serviceProvider;
        this.repository = repository;
        _httpContextAccessor = httpContextAccessor;
        this.trans_repository = trans_repository;
        this.emp_repository = emp_repository;
        this.context = context;
    }

    public async Task<string> RegisterAsync(CompanyRegisterDto dto)
    {
        //var (fileUrl, fileName) = await UploadDocumentAsync(dto.File);
        var uploadAadharFile = await _photoService.AddPhotoAsync(dto.AadharFile);
        var uploadPanFile = await _photoService.AddPhotoAsync(dto.PanFile);

        var company = new Company
        {
            CompanyEmail = dto.CompanyEmail,
            CompanyName = dto.CompanyName,
            CompanyContactNumber = dto.CompanyContactNumber,
            CompanyAddress = dto.CompanyAddress,
            CompanyAccountNumber = dto.CompanyAccountNumber,
            IFSCNumber = dto.IFSCNumber,
            Password = dto.Password,
            AadharFilePath = uploadAadharFile.SecureUrl.AbsoluteUri,
            PanFilePath = uploadPanFile.SecureUrl.AbsoluteUri,
            IsActive = true,
            IsVerified = false,
            IsAproved = false,
            CreatedAt = DateTime.Now,
            Remark = "",
            RoleId = 3
        };

        var bankService = serviceProvider.GetRequiredService<IUserServices>();
        var bankEntity = bankService.GetAllsBanks();
        bool isValidForAdmin = bankEntity
            .Any(b => b.BankEmail == dto.CompanyEmail);

        var userService = serviceProvider.GetRequiredService<IUserServices>();
        var userEntity = userService.GetAllsUsers();
        bool isValidForUser = userEntity
            .Any(a => a.UserEmail == dto.CompanyEmail);

        if (!isValidForAdmin && !isValidForUser)
        {
            var existing = _companyRepo.GetByEmail(dto.CompanyEmail);
            if (existing != null) return "Company already exists.";

            await _companyRepo.AddAsync(company);

            var otp = new Random().Next(100000, 999999).ToString();
            _cache.Set(dto.CompanyEmail, otp, TimeSpan.FromMinutes(5));

            await SendOtpEmailAsync(dto.CompanyEmail, otp);
            return "OTP sent to your email.";
        }
        else
        {
            return "Email Already Used";
        }

        
    }

    public async Task<bool> VerifyOtpAsync(OtpVerificationDto dto)
    {
        if (_cache.TryGetValue(dto.CompanyEmail, out string cachedOtp) && cachedOtp == dto.Otp)
        {
            var company = _companyRepo.GetByEmail(dto.CompanyEmail);
            if (company != null)
            {
                company.IsVerified = true;
                _companyRepo.Update(company);
                _cache.Remove(dto.CompanyEmail);
                return true;
            }
        }
        return false;
    }

    public async Task<string> ResendOtpAsync(string companyEmail)
    {
        var company = _companyRepo.GetByEmail(companyEmail);
        if (company == null) return "Company not found.";

        var otp = new Random().Next(100000, 999999).ToString();
        _cache.Set(companyEmail, otp, TimeSpan.FromMinutes(5));

        await SendOtpEmailAsync(companyEmail, otp);
        return "OTP has been resent to your email.";
    }


    private async Task SendOtpEmailAsync(string toEmail, string otp)
    {
        try
        {
            var message = new MailMessage(_smtpSettings.UserName, toEmail)
            {
                Subject = "Your OTP Code",
                Body = $"Dear User,\n\nYour One-Time Password (OTP) for registration is: {otp}. " +
                $"\n\nPlease use this code to complete your registration. This OTP is valid for 5 minutes. " +
                $"\n\nIf you did not request this, please disregard this message.\n\nBest regards,\nAD Banking App",
                IsBodyHtml = false
            };

            using var smtp = new SmtpClient(_smtpSettings.Host)
            {
                Port = _smtpSettings.Port,
                Credentials = new NetworkCredential(_smtpSettings.UserName, _smtpSettings.Password),
                EnableSsl = _smtpSettings.EnableSsl
            };

            await smtp.SendMailAsync(message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[EMAIL ERROR] {ex}");
            throw;
        }
    }

   

    public List<Company> GetAprovedCompanies()
    {
        var companies = _companyRepo.GetAllAsync();
        return companies.Where(company => company.IsAproved == true && company.IsVerified == true).ToList();
    }

    

    public List<Company> GetAllCompanies()
    {
        var companies = _companyRepo.GetAllAsync();
        return companies.ToList();
    }

    public async Task<Beneficiary> AddInbouBeneficiaries(Beneficiary beneficiary, string companyEmail)
    {
        var beneficiaryEntity = new Beneficiary
        {
            BeneficiaryCompanyEmail = beneficiary.BeneficiaryCompanyEmail,
            BeneficiaryCompanyName = beneficiary.BeneficiaryCompanyName,
            BankAccountNumber = beneficiary.BankAccountNumber,
            IFSCNumber = beneficiary.IFSCNumber,
            BeneficiaryType = "Inbound",
            IsApproved = true,
            CompanyEmail = companyEmail,
        };

        var companies = GetAllCompanies();
        bool isValidCompany = companies
            .Any(c => string.Equals(c.CompanyEmail, beneficiary.CompanyEmail, StringComparison.OrdinalIgnoreCase));

        if (!isValidCompany)
        {
            var approvedCompanies = GetAprovedCompanies();
            bool isValidApprovedCompany = approvedCompanies
                .Any(c => string.Equals(c.CompanyEmail, beneficiary.CompanyEmail, StringComparison.OrdinalIgnoreCase));
            if (!isValidApprovedCompany)
            {
                await repository.AddAsync(beneficiaryEntity);
                return beneficiaryEntity;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        else
        {
            throw new NullReferenceException();
        }
    }

    public List<Beneficiary> GetAllInboundBeneficiaries()
    {
        var emailClaim = _httpContextAccessor.HttpContext?.User?.Claims
            .FirstOrDefault(c => c.Type == "Id");

        var companyEmail = emailClaim?.Value;
        var beneficiaries = repository.GetAllAsync();
        return beneficiaries.Where(beneficiary => beneficiary.BeneficiaryType == "Inbound"
        && beneficiary.CompanyEmail == companyEmail).ToList();
    }

    public async Task<Beneficiary> AddOutbouBeneficiaries(Beneficiary beneficiary, string companyEmail)
    {
        var beneficiaryEntity = new Beneficiary
        {
            BeneficiaryCompanyEmail = beneficiary.BeneficiaryCompanyEmail,
            BeneficiaryCompanyName = beneficiary.BeneficiaryCompanyName,
            BankAccountNumber = beneficiary.BankAccountNumber,
            IFSCNumber = beneficiary.IFSCNumber,
            BeneficiaryType = "Outbound",
            IsApproved = false,
            CompanyEmail = companyEmail,
        };
        var companies = GetAllCompanies();
        bool isValidCompany = companies
            .Any(c => string.Equals(c.CompanyEmail, beneficiary.CompanyEmail, StringComparison.OrdinalIgnoreCase));

        if (!isValidCompany)
        {
            var approvedCompanies = GetAprovedCompanies();
            bool isValidApprovedCompany = approvedCompanies
                .Any(c => string.Equals(c.CompanyEmail, beneficiary.CompanyEmail, StringComparison.OrdinalIgnoreCase));
            if (isValidApprovedCompany)
            {
                await repository.AddAsync(beneficiaryEntity);
                return beneficiaryEntity;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        else
        {
            throw new NullReferenceException();
        }
        
    }


    public List<Beneficiary> GetAllOutboundBeneficiaries()
    {
        var emailClaim = _httpContextAccessor.HttpContext?.User?.Claims
            .FirstOrDefault(c => c.Type == "Id");

        var companyEmail = emailClaim?.Value;
        var beneficiaries = repository.GetAllAsync();
        return beneficiaries.Where(beneficiary => beneficiary.BeneficiaryType == "Outbound"
        && beneficiary.CompanyEmail == companyEmail).ToList();
    }



    public List<Beneficiary> GetAllBeneficiaries()
    {
        var beneficiaries = repository.GetAllAsync();
        return beneficiaries.ToList();
    }

    public List<Transaction> GetAllCompanyTransaction(string companyEmail)
    {
        var transactions = trans_repository.GetAllAsync();
        return transactions.Where(c => c.TransferFromCompanyEmail == companyEmail).ToList();
    }
    public async Task<Transaction> AddTrasaction(Transaction transaction, string companyEmail)
    {
        var transactionEntity = new Transaction
        {
            TransferFromCompanyEmail = companyEmail,
            TransferToCompanyEmail = transaction.TransferToCompanyEmail,
            TransactionAmount = transaction.TransactionAmount,
            PaymentDate = DateTime.Now,
            Status = "Pending"
        };

        var beneficiaries = GetAllBeneficiaries();

        bool isValidBeneficiary = beneficiaries.Any(b =>
            string.Equals(b.BeneficiaryCompanyEmail, transaction.TransferToCompanyEmail, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(b.CompanyEmail, companyEmail, StringComparison.OrdinalIgnoreCase));

        if (isValidBeneficiary)
        {
            var approvedCompanies = GetAprovedCompanies();
            bool isValidApprovedCompany = approvedCompanies
                .Any(c => string.Equals(c.CompanyEmail, companyEmail, StringComparison.OrdinalIgnoreCase));
            if (isValidApprovedCompany)
            {
                await trans_repository.AddAsync(transactionEntity);
                return transactionEntity;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        else
        {
            throw new NullReferenceException();
        }
    }

    public async Task<string> AddEmployeesByCSV(IFormFile csvFile, string companyEmail)
    {
        if (csvFile == null || csvFile.Length == 0)
            return "CSV file is empty.";

        var employees = new List<Employee>();
        var existingEmails = context.Employees.Select(e => e.EmployeeEmail).ToHashSet(); 

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
                        IsActive = true,
                        CompanyEmail = companyEmail
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



    //public Task<Employee> AddEmployeesTransactionSalary(Employee employee)
    //{
    //    throw new NotImplementedException();
    //}

    public List<Employee> GetAllEmployees()
    {
        var emailClaim = _httpContextAccessor.HttpContext?.User?.Claims
            .FirstOrDefault(c => c.Type == "Id");

        var companyEmail = emailClaim?.Value;
        var employees = emp_repository.GetAllAsync();
        return employees.Where(employee => employee.IsActive == true
        && employee.CompanyEmail == companyEmail).ToList();
    }

    public async Task<string> DisburseSalaryToAllEmployees(string companyEmail, List<SalaryDisburesement> employees)
    {
        var successfulDisbursements = 0;
        var disbursementRecords = new List<SalaryDisburesement>();

        foreach (var emp in employees)
        {
            try
            {
                // Check if salary has been disbursed for the employee this month
                var existingDisbursement = await context.SalaryDisburesements
                    .FirstOrDefaultAsync(d => d.EmployeeEmail == emp.EmployeeEmail && d.TransactionDate.Month == DateTime.Now.Month && d.TransactionDate.Year == DateTime.Now.Year);

                if (existingDisbursement != null)
                {
                    // Skip employees who have already received salary this month
                    Console.WriteLine($"Salary already disbursed to {emp.EmployeeEmail} for this month.");
                    continue;
                }

                // Disbursement logic
                var disbursement = new SalaryDisburesement
                {
                    EmployeeEmail = emp.EmployeeEmail,
                    Amount = emp.Amount,
                    TransactionDate = DateTime.Now,
                    CompanyEmail = emp.CompanyEmail, 
                    Status = emp.Status
                };

                disbursementRecords.Add(disbursement);
                successfulDisbursements++;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to disburse salary to {emp.EmployeeEmail}: {ex.Message}");
            }
        }

        if (disbursementRecords.Any())
        {
            await context.SalaryDisburesements.AddRangeAsync(disbursementRecords);
            await context.SaveChangesAsync();
        }

        return $"Salary disbursed to {successfulDisbursements} employees.";
    }

    
}