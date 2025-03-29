using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorMethodDesignPattern
{
    internal class PriceCalculator : I_Visitor
    {
        public void Visit(Book book)
        {
            Console.WriteLine($"Calculating price for book: {book.Title}");
        }

        public void Visit(DVD dvd)
        {
            Console.WriteLine($"Calculating price for DVD: {dvd.Name}");
        }

    }
}
