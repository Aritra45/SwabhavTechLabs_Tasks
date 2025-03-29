using System.Diagnostics.CodeAnalysis;

namespace ContactAppUsingWebApi.Model.ContactDto
{
    public class UpdateContactActivationDto
    {
        [NotNull]
        public bool IsActive { get; }
    }
}
