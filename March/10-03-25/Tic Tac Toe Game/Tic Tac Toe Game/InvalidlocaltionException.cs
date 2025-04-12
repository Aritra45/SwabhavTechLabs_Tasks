using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Game
{
    internal class InvalidlocaltionException : Exception
    {
        public InvalidlocaltionException(string message) : base(message) { }
    }
}
