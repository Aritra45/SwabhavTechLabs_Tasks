using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorMethodDesignPattern
{
    internal class Book : I_Element
    {
        public string Title { get; set; }

        public Book(string title)
        {
            Title = title;
        }

        public void Accept(I_Visitor visitor)
        {
            visitor.Visit(this);
        }

    }
}
