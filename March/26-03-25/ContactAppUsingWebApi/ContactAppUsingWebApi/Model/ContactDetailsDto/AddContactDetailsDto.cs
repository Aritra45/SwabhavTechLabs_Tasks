using ContactAppUsingWebApi.Model.Entity;
using System.Diagnostics.CodeAnalysis;

namespace ContactAppUsingWebApi.Model.ContactDetailsDto
{
    public class AddContactDetailsDto
    {
        [NotNull]
        public string Type { get; set; }
        [NotNull]
        public string Value { get; set; }
        [NotNull]
        public bool IsActive { get;}
        [NotNull]
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
