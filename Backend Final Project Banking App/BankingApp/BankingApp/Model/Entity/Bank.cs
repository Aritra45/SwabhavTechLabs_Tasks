using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.Entity
{
    public class Bank
    {
        [Key]
        public int BankId { get; set; }
        [NotNull]
        public string BankName { get; set; }
        [NotNull]
        public string BranchCode { get; set; }
        [NotNull]
        public string IFSCNumber { get; set; }
        [NotNull]
        public string BankAddress { get; set; }
        [NotNull]
        public string BankPassword { get; set; }
        [NotNull]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
