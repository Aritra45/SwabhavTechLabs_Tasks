using ContactAppUsingWebApi.Model.Entity;
using System.Diagnostics.CodeAnalysis;

namespace ContactAppUsingWebApi.Model.ContactDetailsDto
{
    public class UpdateContactDetailsTypeDto
    {
        [NotNull]
        public string Type { get; set; }
        
    }
}
