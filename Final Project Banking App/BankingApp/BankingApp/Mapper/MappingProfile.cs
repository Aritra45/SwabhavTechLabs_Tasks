using AutoMapper;
using BankingApp.Model.BankDto;
using BankingApp.Model.BeneficiaryDto;
using BankingApp.Model.CompanyDto;
using BankingApp.Model.Entity;
using BankingApp.Model.TrasactionDto;
using BankingApp.Model.UserDtos;

namespace BankingApp.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, AddUserDto>();
            CreateMap<AddUserDto, User>();
            CreateMap<User, GetAllUsersDto>();
            CreateMap<GetAllUsersDto, User>();

            CreateMap<Bank, GetAllBankDto>();
            CreateMap<GetAllBankDto, Bank>();
            CreateMap<Bank, AddBankDto>();
            CreateMap<AddBankDto, Bank>();
            CreateMap<Bank, UpdateBankPasswordDto>();
            CreateMap<UpdateBankPasswordDto, Bank>();

            CreateMap<Company, CompanyRegisterDto>();
            CreateMap<CompanyRegisterDto, Bank>();
            CreateMap<Company, OtpVerificationDto>();
            CreateMap<OtpVerificationDto, Company>();
            CreateMap<Company, GetAllNotApprovedCompanies>();
            CreateMap<GetAllNotApprovedCompanies, Company>();
            CreateMap<Company, UpdateNotApprovedDto>();
            CreateMap<UpdateNotApprovedDto, Company>();
            CreateMap<Company, GetAllCompanyDto>();
            CreateMap<GetAllCompanyDto, Company>();

            CreateMap<Beneficiary, AddBeneficiaryDto>();
            CreateMap<AddBeneficiaryDto, Beneficiary>();
            CreateMap<Beneficiary, GetAllbeneficiariesDto>();
            CreateMap<GetAllbeneficiariesDto, Beneficiary>();
            CreateMap<Beneficiary, GetAllOutboundNotApprovedBeneficiariesDto>();
            CreateMap<GetAllOutboundNotApprovedBeneficiariesDto, Beneficiary>();
            CreateMap<Beneficiary, UpdateNotApprovedBeneficiaryDto>();
            CreateMap<UpdateNotApprovedBeneficiaryDto, Beneficiary>();

            CreateMap<Transaction, AddTransactionDto>();
            CreateMap<AddTransactionDto, Transaction>();
            CreateMap<Transaction, GetAllPendingTransactionsDto>();
            CreateMap<GetAllPendingTransactionsDto, Transaction>();
            CreateMap<Transaction, UpdatePendingTransactionDto>();
            CreateMap<UpdatePendingTransactionDto, Transaction>();

            CreateMap<Employee, GetAllEmployeesDto>();
            CreateMap<GetAllEmployeesDto, Employee>();

        }
    }
}
