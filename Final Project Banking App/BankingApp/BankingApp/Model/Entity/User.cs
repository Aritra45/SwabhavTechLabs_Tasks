using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.Entity
{
    public class User
    {
        [Key]
        public string UserEmail { get; set; }
        [NotNull]
        public string UserName { get; set; }
        [NotNull]
        public string UserPassword { get; set; }
        [NotNull]
        public bool IsActive { get; set; }

        public int RoleId { get; set; }

        public string SuperAdminEmail { get; set; }

    }
}
