using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ContactAppUsingWebApi.Model.Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public bool IsAdmin { get; set; }
        [NotNull]
        public bool IsActive { get; set; }

        [NotNull]
        public string Password { get; set; }
        [NotNull]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
