using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountLibrary.Exceptions
{
    internal class BankAccountNotFoundException : Exception
    {
        public BankAccountNotFoundException(string message) : base (message) { }
    }
}
