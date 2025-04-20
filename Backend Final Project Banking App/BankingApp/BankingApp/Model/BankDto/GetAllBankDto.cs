using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.BankDto
{
    public class GetAllBankDto
    {
        public string BankName { get; set; }

        public string BranchCode { get; set; }

        public string BankAddress { get; set; }
    }
}
