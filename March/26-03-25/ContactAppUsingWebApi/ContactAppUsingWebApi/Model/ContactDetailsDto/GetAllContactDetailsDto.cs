using System.Diagnostics.CodeAnalysis;
using ContactAppUsingWebApi.Model.Entity;

namespace ContactAppUsingWebApi.Model.ContactDetailsDto
{
    public class GetAllContactDetailsDto
    {
        [NotNull]
        public string Type { get; set; }
        [NotNull]
        public string Value { get; set; }
        [NotNull]
        public bool IsActive { get; }
        [NotNull]
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
