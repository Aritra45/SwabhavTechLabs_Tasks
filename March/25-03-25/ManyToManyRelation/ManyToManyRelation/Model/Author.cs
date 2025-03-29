using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToManyRelation.Model
{
    internal class Author
    {
        [Key]
        public int AId { get; set; }
        [NotNull]
        public string Name { get; set; }
        public IList<Book> Books { get; set; }

    }
}
