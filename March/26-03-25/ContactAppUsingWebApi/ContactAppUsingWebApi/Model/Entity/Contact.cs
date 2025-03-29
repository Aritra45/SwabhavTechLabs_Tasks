using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ContactAppUsingWebApi.Model.Entity
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [NotNull]
        public string FirstName { get; set; }
        [NotNull]
        public string LastName { get; set; }
        [NotNull]
        public required bool IsActive { get; set; }
        [NotNull]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
