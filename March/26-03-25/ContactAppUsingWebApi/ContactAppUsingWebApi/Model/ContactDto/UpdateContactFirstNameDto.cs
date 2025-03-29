using System.Diagnostics.CodeAnalysis;

namespace ContactAppUsingWebApi.Model.ContactDto
{
    public class UpdateContactFirstNameDto
    {
        [NotNull]
        public string FirstName { get; set; }
    }
}
