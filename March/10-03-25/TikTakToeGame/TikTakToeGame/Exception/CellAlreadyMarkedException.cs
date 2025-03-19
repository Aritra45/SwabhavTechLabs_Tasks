using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TicTacToeGame.Exception
{
    internal class CellAlreadyMarkedException : System.Exception
    {
        public CellAlreadyMarkedException(string message) : base (message) { }
    }
}
