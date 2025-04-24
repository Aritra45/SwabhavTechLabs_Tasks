using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.Entity
{
    public class Bank
    {
        [Key]
        public string BankEmail { get; set; }
        [NotNull]
        public string BankName { get; set; }
        [NotNull]
        public string BranchCode { get; set; }
        [NotNull]
        public string BankAddress { get; set; }
        [NotNull]
        public string BankPassword { get; set; }
        [NotNull]
        public bool IsActive { get; set; }
        [NotNull]
        public int RoleId { get; set; }
        
        
    }
}
