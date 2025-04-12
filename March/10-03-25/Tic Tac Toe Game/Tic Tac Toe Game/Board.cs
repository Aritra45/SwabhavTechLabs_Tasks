using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tic_Tac_Toe_Game
{
    internal class Board
    {
        public Cell[,] newcell = new Cell[3,3];

        public Board ()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    newcell[i, j] = new Cell();
                }
            }
        }

        public bool IsBoardFull()
        {
            foreach (var cell in newcell)
            {
                if (cell.IsEmpty())
                {
                    return false;
                }
            }
            return true;
        }

        public void SetCellMark(int row , int col, MarkType mark)
        {
            if (row < 0 || row >=3 || col < 0 || col >= 3)
            {
                throw new InvalidlocaltionException("Invalid Cell Location");
            }
            

            newcell[row,col].SetMark(mark);


        }


        public MarkType GetMarkAt(int row, int col)
        {
            return newcell[row, col].GetMarkType();
        }



        public void DisplayBoard()
        {
            for (int i = 0; i < 3; i++)  // rows
            {
                for (int j = 0; j < 3; j++)  //column
                {
                    Console.Write(newcell[i, j].GetMarkType() == MarkType.EMPTY ? $"{i} {j}" : newcell[i, j].GetMarkType().ToString());
                    if (j < 2) Console.Write(" | ");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("----------------------");
            }
        }


    }
}
