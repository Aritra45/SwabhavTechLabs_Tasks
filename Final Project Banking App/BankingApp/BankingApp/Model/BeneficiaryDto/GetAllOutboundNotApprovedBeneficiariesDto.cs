namespace BankingApp.Model.BeneficiaryDto
{
    public class GetAllOutboundNotApprovedBeneficiariesDto
    {
        public string BeneficiaryCompanyEmail { get; set; }
        public string BeneficiaryCompanyName { get; set; }
        public bool IsApproved { get; set; }
        public string CompanyEmail { get; set; }
    }
}
