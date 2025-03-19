using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountLibrary.Exceptions
{
    internal class InvalidPanException : Exception
    {
        public InvalidPanException(string message) : base(message) { }
    }
}
