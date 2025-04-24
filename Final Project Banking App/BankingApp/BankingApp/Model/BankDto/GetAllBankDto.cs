using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.BankDto
{
    public class GetAllBankDto
    {
        public string BankEmail { get; set; }
        public string BankName { get; set; }

        public string BranchCode { get; set; }

        public string BankAddress { get; set; }
    }
}
