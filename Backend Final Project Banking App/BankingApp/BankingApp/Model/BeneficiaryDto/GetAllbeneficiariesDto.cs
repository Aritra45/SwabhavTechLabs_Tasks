namespace BankingApp.Model.BeneficiaryDto
{
    public class GetAllbeneficiariesDto
    {
        public string BeneficiaryCompanyEmail { get; set; }
        public string BeneficiaryCompanyName { get; set; }

        public string BankAccountNumber { get; set; }

        public string IFSCNumber { get; set; }
        public string BeneficiaryType { get; set; }
        public bool IsApproved { get; set; }

        public string CompanyEmail { get; set; }
    }
}
