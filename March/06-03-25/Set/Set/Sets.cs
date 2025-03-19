using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    internal class Sets
    {
        public int setRare = -1;
        public int setNumber;

        public int[] set = new int[100];
        
        public Sets(int setNumber)
        {
            this.setNumber = setNumber;
        }
        public void AddSetElement(int obj)
        {
            setRare++;
            set[setRare] = obj;
        }

        public void DisplaySet()
        {
            int i = 0;
            Console.Write($"\nSet {setNumber} :");
            while (i <= setRare)
            {
                Console.Write($"[ {set[i]} ]");
                i++;
            }
        }
    }
}
