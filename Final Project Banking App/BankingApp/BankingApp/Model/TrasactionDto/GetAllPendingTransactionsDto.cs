using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.TrasactionDto
{
    public class GetAllPendingTransactionsDto
    {
        public int TransactionId { get; set; }

        public decimal TransactionAmount { get; set; }

        public string Status { get; set; }

        public DateTime PaymentDate { get; set; }

        public string TransferFromCompanyEmail { get; set; }

        public string TransferToCompanyEmail { get; set; }
    }
}
