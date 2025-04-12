using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Game
{
    public class CellAlredyMarkedException : Exception
    {   
        public  CellAlredyMarkedException(string message) : base(message) { }
    }
}
