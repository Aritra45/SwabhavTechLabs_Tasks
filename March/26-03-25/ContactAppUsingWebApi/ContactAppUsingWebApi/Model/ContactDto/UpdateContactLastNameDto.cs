using System.Diagnostics.CodeAnalysis;

namespace ContactAppUsingWebApi.Model.ContactDto
{
    public class UpdateContactLastNameDto
    {
        [NotNull]
        public string LastName { get; set; }
    }
}
