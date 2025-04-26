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
        public string CompanyAccountNumber { get; set; }
        [NotNull]
        public string IFSCNumber { get; set; }
        [NotNull]
        public string AadharFilePath { get; set; }
        [NotNull]
        public string PanFilePath { get; set; }
        [NotNull]
        public string Password { get; set; }
        [NotNull]
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }
        public bool IsAproved { get; set; }
        public int RoleId { get; set; }
        public string Remark { get; set; }
    }
}
