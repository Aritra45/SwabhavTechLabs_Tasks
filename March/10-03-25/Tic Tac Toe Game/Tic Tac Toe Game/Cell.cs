using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Game
{
    internal class Cell
    {
        public MarkType mark ;
        public Cell() 
        {
            mark = MarkType.EMPTY;
        }

        public bool IsEmpty ()
        {
            return mark == MarkType.EMPTY;
        }

        public MarkType GetMarkType()
        {
            return mark;
        }

        public void SetMark(MarkType newMark)
        {
            if (!IsEmpty())
            {
                throw new CellAlredyMarkedException("Cell is already marked.");
            }
            mark = newMark;
        }
    }
}
