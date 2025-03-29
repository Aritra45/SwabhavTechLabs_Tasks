using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorMethodDesignPattern
{
    internal class DVD : I_Element
    {
        public string Name { get; set; }

        public DVD(string name)
        {
            Name = name;
        }

        public void Accept(I_Visitor visitor)
        {
            visitor.Visit(this);
        }

    }
}
