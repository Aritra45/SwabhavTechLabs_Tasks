using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        [NotNull]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
