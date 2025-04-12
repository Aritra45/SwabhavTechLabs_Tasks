using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace JWTImplementation.Model.Entity
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [NotNull]
        public string Rolename { get; set; }
    }
}
