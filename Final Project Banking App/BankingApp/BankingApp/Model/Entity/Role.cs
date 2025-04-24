using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.Entity
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [NotNull]
        public string RoleName { get; set; }
    }
}
