using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStoreusingList_Exception.Services;

namespace MovieStoreApp.Exceptions
{
    internal class ListFullException : Exception
    {
        public ListFullException(string message) : base(message) {}
    }
}
