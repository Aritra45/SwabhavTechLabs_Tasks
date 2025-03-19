using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class Node
    {
        public object Key;
        public object Value;
        public Node Next;

        public Node(object obj1, object obj2) {
            Key = obj1;
            Value = obj2;
            Next = null;
        }
    }
}
