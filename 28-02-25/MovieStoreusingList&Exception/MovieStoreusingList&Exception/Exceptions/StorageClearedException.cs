using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreusingList_Exception.Exceptions
{
    internal class StorageClearedException:Exception
    {
        public StorageClearedException(string message) : base(message) { }
    }
}
