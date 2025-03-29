using ContactAppUsingWebApi.Model.Entity;
using System.Diagnostics.CodeAnalysis;

namespace ContactAppUsingWebApi.Model.ContactDetailsDto
{
    public class UpdateContactDetailsActivationDto
    {
        
        [NotNull]
        public required bool IsActive { get; set; }
        
    }
}
