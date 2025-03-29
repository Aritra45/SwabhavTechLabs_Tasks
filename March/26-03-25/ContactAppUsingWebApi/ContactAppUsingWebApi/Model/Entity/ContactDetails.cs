using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ContactAppUsingWebApi.Model.Entity
{
    public class ContactDetails
    {
        [Key]
        public int ContactDetailsID { get; set; }
        [NotNull]
        public string Type { get; set; }
        [NotNull]
        public string Value { get; set; }
        [NotNull]
        public required bool IsActive { get; set; }
        [NotNull]
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
