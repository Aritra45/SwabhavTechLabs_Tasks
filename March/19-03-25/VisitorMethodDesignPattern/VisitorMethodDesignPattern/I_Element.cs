using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorMethodDesignPattern
{
    internal interface I_Element
    {
        void AcceptAccept(I_Visitor visitor);
    }
}
