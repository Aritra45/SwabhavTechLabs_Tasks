using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.TrasactionDto
{
    public class AddTransactionDto
    {
        public string TransferFromCompanyEmail { get; set; }
        public string TransferToCompanyEmail { get; set; }
        public decimal TransactionAmount { get; set; }

    }
}
