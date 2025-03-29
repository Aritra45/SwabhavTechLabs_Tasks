using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Model
{
    internal class ContactDetails
    {
        [Key]
        public int ContactDetailsID { get; set; }
        [NotNull]
        public string Type { get; set; }
        [NotNull]
        public string Value { get; set; }
        [NotNull]
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
