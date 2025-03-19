using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Exception
{
    internal class InValidChoiceException : System.Exception
    {
        public InValidChoiceException(string message) : base(message) { }
    }
}
