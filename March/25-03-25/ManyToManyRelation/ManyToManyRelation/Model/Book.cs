using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToManyRelation.Model
{
    internal class Book
    {
        [Key]
        public int BId { get; set; }
        [NotNull]
        public string Title { get; set; }
        public IList<Author> Authors { get; set; }
    }
}
