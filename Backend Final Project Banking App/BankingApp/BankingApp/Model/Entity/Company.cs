using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.Entity
{
    public class Company
    {
        [Key]
        public string CompanyEmail { get; set; }
        [NotNull]
        public string CompanyName { get; set; }
        [NotNull]
        public string CompanyContactNumber { get; set; }
        [NotNull]
        public string CompanyAddress { get; set; }
        [NotNull]
        public string FileName { get; set; }
        [NotNull]
        public string FilePath { get; set; }
        [NotNull]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsVerified { get; set; }
        [NotNull]
        public int BankId { get; set; }
        public Bank Bank { get; set; }
    }
}
