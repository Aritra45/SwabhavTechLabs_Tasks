using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Exception;

namespace TicTacToeGame
{
    internal class Cells
    {
        private MarkType mark;

        public Cells()
        {
            mark = MarkType.Empty;
        }

        public bool IsEmpty()
        {
            return mark == MarkType.Empty;
        }

        public MarkType GetMark()
        {
            return mark;
        }

        public MarkType SetMark(MarkType marktype)
        {
            if (!IsEmpty())
            {
                throw new CellAlreadyMarkedException("!!!Cell is Already Occupied!!!");
            }
            mark = marktype;
            return mark;
        }
    }
}
