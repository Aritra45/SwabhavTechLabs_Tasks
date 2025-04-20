using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.BeneficiaryDto
{
    public class AddBeneficiaryDto
    {
        public string BeneficiaryCompanyEmail { get; set; }
        public string BeneficiaryCompanyName { get; set; }

        public string BankAccountNumber { get; set; }

        public string IFSCNumber { get; set; }
    }
}
