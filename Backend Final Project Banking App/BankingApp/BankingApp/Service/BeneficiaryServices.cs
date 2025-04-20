using System.Transactions;
using BankingApp.Database;
using BankingApp.Interfaces.IRepository;
using BankingApp.Interfaces.IService;
using BankingApp.Model.BankDto;
using BankingApp.Model.BeneficiaryDto;
using BankingApp.Model.CompanyDto;
using BankingApp.Model.Entity;
using Microsoft.AspNetCore.Routing.Tree;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BankingApp.Service
{
    public class BeneficiaryServices : IBeneficiaryServices
    {
        private readonly IGenericRepository<Beneficiary> repository;
        ICompanyService companyService;
        MyContext context;
        public BeneficiaryServices(IGenericRepository<Beneficiary> beneficiaryRepository, MyContext context, ICompanyService companyService)
        {
            this.context = context;
            this.repository = beneficiaryRepository;
            this.companyService = companyService;
        }
        public async Task<Beneficiary> AddInbouBeneficiaries(Beneficiary beneficiary)
        {
            var beneficiaryEntity = new Beneficiary
            {
                BeneficiaryCompanyEmail = beneficiary.BeneficiaryCompanyEmail,
                BeneficiaryCompanyName = beneficiary.BeneficiaryCompanyName,
                BankAccountNumber = beneficiary.BankAccountNumber,
                IFSCNumber = beneficiary.IFSCNumber,
                BeneficiaryType = "Inbound",
                IsApproved = true,
                CompanyEmail = beneficiary.CompanyEmail,
            };

            var companies = companyService.GetAllCompanies();
            bool isValidCompany = companies
                .Any(c => c.CompanyEmail==beneficiary.CompanyEmail);

            if (isValidCompany)
            {
                var approvedCompanies = companyService.GetAprovedCompanies();
                bool isValidApprovedCompany = companies
                    .Any(c => c.CompanyEmail == beneficiary.CompanyEmail);
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
        public async Task<Beneficiary> AddOutbouBeneficiaries(Beneficiary beneficiary)
        {
            var beneficiaryEntity = new Beneficiary
            {
                BeneficiaryCompanyEmail = beneficiary.BeneficiaryCompanyEmail,
                BeneficiaryCompanyName = beneficiary.BeneficiaryCompanyName,
                BankAccountNumber = beneficiary.BankAccountNumber,
                IFSCNumber = beneficiary.IFSCNumber,
                BeneficiaryType = "Outbound",
                IsApproved = false,
                CompanyEmail = beneficiary.CompanyEmail,
            };

            var companies = companyService.GetAllCompanies();
            bool isValidCompany = companies
                .Any(c => c.CompanyEmail == beneficiary.CompanyEmail);

            if (isValidCompany)
            {
                var approvedCompanies = companyService.GetAprovedCompanies();
                bool isValidApprovedCompany = companies
                    .Any(c => c.CompanyEmail == beneficiary.CompanyEmail);
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

        //public Task DeleteBeneficiaries(int beneficiaryId)
        //{
        //    throw new NotImplementedException();
        //}

        public List<Beneficiary> GetAllInboundBeneficiaries()
        {
            var beneficiaries = repository.GetAllAsync();
            return beneficiaries.Where(beneficiary => beneficiary.BeneficiaryType == "Inbound").ToList();
        }
        public List<Beneficiary> GetAllOutboundBeneficiaries()
        {
            var beneficiaries = repository.GetAllAsync();
            return beneficiaries.Where(beneficiary => beneficiary.BeneficiaryType == "Outbound").ToList();
        }

        public List<Beneficiary> GetAllOutboundNotApprovedBeneficiaries()
        {
            var beneficiaries = repository.GetAllAsync();
            return beneficiaries.Where(beneficiary => beneficiary.BeneficiaryType == "Outbound" && 
            beneficiary.IsApproved == false).ToList();
        }

        public Beneficiary UpdateOutboundNotApprovedBeneficiaries(string beneficiaryEmail, UpdateNotApprovedBeneficiaryDto updateNotApprovedBeneficiary)
        {
            var beneficiaryEntity = repository.GetByEmail(beneficiaryEmail);
            if (beneficiaryEntity != null)
            {
                beneficiaryEntity.IsApproved = updateNotApprovedBeneficiary.IsApproved;
                repository.Update(beneficiaryEntity);
                return beneficiaryEntity;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public List<Beneficiary> GetAllBeneficiaries()
        {
            var beneficiaries = repository.GetAllAsync();
            return beneficiaries.ToList();
        }

        //public Beneficiary GetByID(int beneficiaryId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Beneficiary UpdateBeneficiariesAccountNumber(int beneficiaryId, UpdateBankPasswordDto updateBankPasswordDto)
        //{
        //    throw new NotImplementedException();
        //}

        //public Beneficiary UpdateBeneficiariesIFSCNumber(int beneficiaryId, UpdateBankPasswordDto updateBankPasswordDto)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
