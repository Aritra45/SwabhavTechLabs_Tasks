using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Exception
{
    internal class InvalidInputException : System.Exception
    {
        public InvalidInputException(string message) : base (message) { }
    }
}
