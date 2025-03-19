using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    internal class HashSets
    {
        int[] keys = new int[100];
        Sets[] setOfSet = new Sets[100];
        public int setkeys = -1;
        public void AddSets(int key, Sets sets)
        {
            setkeys++;
            keys[setkeys] = key;

            setOfSet[setkeys] = sets;
        }

        public void Display()
        {
            for (int i = 0; i <= setkeys; i++)
            {
                Console.Write($"\n{keys[i]}");
                setOfSet[i].DisplaySet();
            }
            

        }
    }
}
