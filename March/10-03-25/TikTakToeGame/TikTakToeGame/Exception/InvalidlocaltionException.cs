using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Exception
{
    internal class InvalidlocaltionException : System.Exception
    {
        public InvalidlocaltionException(string message) : base(message) { }
    }
}
