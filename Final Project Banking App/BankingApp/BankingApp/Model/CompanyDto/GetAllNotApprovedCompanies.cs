using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.CompanyDto
{
    public class GetAllNotApprovedCompanies
    {
        public string CompanyEmail { get; set; }
        public string CompanyName { get; set; }
        public string AadharFilePath { get; set; }
        public string PanFilePath { get; set; }
    }
}
