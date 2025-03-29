using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Model
{
    internal class User
    {
        [Key]
        public int UserId { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public bool IsAdmin { get; set; }
        [NotNull]
        public bool IsActive {  get; set; }

    }
}
