using ContactAppUsingWebApi.Model.Entity;
using System.Diagnostics.CodeAnalysis;

namespace ContactAppUsingWebApi.Model.ContactDto
{
    public class AddContactDto
    {
        [NotNull]
        public string FirstName { get; set; }
        [NotNull]
        public string LastName { get; set; }
        [NotNull]
        public bool IsActive { get; }
        [NotNull]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
