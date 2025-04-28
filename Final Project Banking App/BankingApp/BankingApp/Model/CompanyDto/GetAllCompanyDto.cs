using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.CompanyDto
{
    public class GetAllCompanyDto
    {
        public string CompanyEmail { get; set; }

        public string CompanyName { get; set; }

        public string CompanyAccountNumber { get; set; }

        public string IFSCNumber { get; set; }
        public string Remark { get; set; }
    }
}
