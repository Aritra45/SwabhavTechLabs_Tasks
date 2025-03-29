using ContactAppUsingWebApi.Model.Entity;
using System.Diagnostics.CodeAnalysis;

namespace ContactAppUsingWebApi.Model.ContactDetailsDto
{
    public class UpdateContactDetailsValueDto
    {
        
        [NotNull]
        public string Value { get; set; }
        
    }
}
