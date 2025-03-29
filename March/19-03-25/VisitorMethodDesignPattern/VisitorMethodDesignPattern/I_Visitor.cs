using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorMethodDesignPattern
{
    internal interface I_Visitor
    {
        public void Visit(Book book);
        public void Visit(DVD dvd);

    }
}
