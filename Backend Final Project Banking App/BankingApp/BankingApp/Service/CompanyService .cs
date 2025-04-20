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

public class CompanyService : ICompanyService
{
    private readonly IGenericRepository<Company> _companyRepo;
    private readonly IMemoryCache _cache;
    private readonly SmtpSettings _smtpSettings;
    private readonly Cloudinary _cloudinary;
    private readonly IPhotoService _photoService;
    private readonly IServiceProvider serviceProvider;

    public CompanyService(
        IGenericRepository<Company> companyRepo,
        IMemoryCache cache,
        IOptions<SmtpSettings> smtpOptions,
        IOptions<CloudinarySettings> cloudinaryOptions,
        IPhotoService photoService,
        IServiceProvider serviceProvider)
        
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
            RoleId = 3
        };

        var bankService = serviceProvider.GetRequiredService<IBankServices>();
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

    //private async Task<(string fileUrl, string fileName)> UploadDocumentAsync(IFormFile file)
    //{
    //    if (file == null || file.Length == 0)
    //        return (null, null);

    //    await using var stream = file.OpenReadStream();
    //    var uploadParams = new RawUploadParams
    //    {
    //        File = new FileDescription(file.FileName, stream),
    //        Folder = "banking_docs"
    //    };

    //    var result = await _cloudinary.UploadAsync(uploadParams);
    //    return (result.SecureUrl.ToString(), result.OriginalFilename);
    //}

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

    private async Task SendOtpEmailAsync(string toEmail, string otp)
    {
        try
        {
            var message = new MailMessage(_smtpSettings.UserName, toEmail)
            {
                Subject = "Your OTP Code",
                Body = $"Your OTP for registration is: {otp}",
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

    public List<Company> GetAllNotAprovedCompanies()
    {
        var companies = _companyRepo.GetAllAsync();
        return companies.Where(company => company.IsAproved == false).ToList();
    }

    public List<Company> GetAprovedCompanies()
    {
        var companies = _companyRepo.GetAllAsync();
        return companies.Where(company => company.IsAproved == true && company.IsVerified == true).ToList();
    }

    public Company UpdateNotAprovedCompanies(string company, UpdateNotApprovedDto updateNotApprovedDto)
    {
        var companyEntity = _companyRepo.GetByEmail(company);
        if (companyEntity != null)
        {
            companyEntity.IsAproved = updateNotApprovedDto.IsAproved;
            _companyRepo.Update(companyEntity);
            return companyEntity;
        }
        else
        {
            throw new NullReferenceException();
        }
    }

    public List<Company> GetAllCompanies()
    {
        var companies = _companyRepo.GetAllAsync();
        return companies.ToList();
    }
}