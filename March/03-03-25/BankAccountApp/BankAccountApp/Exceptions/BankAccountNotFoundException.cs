using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp.Exceptions
{
    internal class BankAccountNotFoundException : Exception
    {
        public BankAccountNotFoundException(string message) : base (message) { }
    }
}
