using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.BankDto
{
    public class UpdateBankPasswordDto
    {

        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
