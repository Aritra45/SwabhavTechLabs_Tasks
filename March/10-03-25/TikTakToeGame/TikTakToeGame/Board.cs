using System;
using System.Dynamic;
using TicTacToeGame.Exception;

namespace TicTacToeGame
{
    internal class Board
    {
        public string[] cell = new string[9];

        public Board()
        {
            for (int i = 0; i < cell.Length; i++)
            {
                cell[i] = MarkType.Empty.ToString();
            }
        }

        public bool IsBoardFull()
        {
            foreach (string mark in cell)
            {
                if (mark == MarkType.Empty.ToString())
                {
                    return false;
                }
            }
            return true;
        }

        public void SetCellMark(int loc, MarkType mark)
        {
            if (loc < 0 || loc >= cell.Length)
            {
                throw new InvalidlocaltionException("InvalidLocationException");
            }
            if (cell[loc] != MarkType.Empty.ToString())
            {
                throw new CellAlreadyMarkedException("!!!Cell is Already Occupied!!!");
            }
            cell[loc] = mark.ToString();
        }

        public bool CheckWinner(MarkType mark)
        {
            return CheckRow(mark)||CheckColomn(mark)||CheckDigonal(mark);
        }

        public bool CheckRow(MarkType mark) {
            if ((cell[0] == mark.ToString() && cell[1] == mark.ToString() && cell[2] == mark.ToString())
                ||
             (cell[3] == mark.ToString() && cell[4] == mark.ToString() && cell[5] == mark.ToString())
               ||
             (cell[6] == mark.ToString() && cell[7] == mark.ToString() && cell[8] == mark.ToString()))
                return true;

            return false;
        }

        public bool CheckColomn(MarkType mark)
        {
            if ((cell[0] == mark.ToString() && cell[3] == mark.ToString() && cell[6] == mark.ToString())
                ||
            (cell[1] == mark.ToString() && cell[4] == mark.ToString() && cell[7] == mark.ToString())
                ||
            (cell[2] == mark.ToString() && cell[5] == mark.ToString() && cell[8] == mark.ToString()))
                return true;

            return false;
        }

        public bool CheckDigonal(MarkType mark) {
            if ((cell[0] == mark.ToString() && cell[4] == mark.ToString() && cell[8] == mark.ToString())
               ||
             (cell[2] == mark.ToString() && cell[4] == mark.ToString() && cell[6] == mark.ToString()))
                return true;

            return false;
        }

        public void DisplayBoard()
        { 
            for (int i = 0; i <= 8; i++)
            {
                Console.Write("|  ");
                Console.Write(cell[i] == MarkType.Empty.ToString() ? i : cell[i]);
                Console.Write("  |");
                if (i == 2 || i == 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("------------------------");
                }

            }
        }
             
    }
}
