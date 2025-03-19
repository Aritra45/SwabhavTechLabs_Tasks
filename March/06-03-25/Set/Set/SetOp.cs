using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    internal class SetOp
    {
        public int setRare;
        public void Union(Sets sets1, Sets sets2)
        {
            int[] unionSet = new int[100];
            int j = 0;
            int i = 0;
            while (i <= sets1.setRare)
            {
                if (sets1.set[i] == null)
                {
                    break;
                }
                else
                {
                    unionSet[i] = sets1.set[i];
                    j++;
                }
                i++;
            }

            i = 0;
            while (i <= sets2.setRare)
            {
                bool found = false;
                for (int k = 0; k <= sets1.setRare; k++)
                {
                    if (sets2.set[i] == sets1.set[k])
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    unionSet[j] = sets2.set[i];
                    j++;
                }
                i++;
            }
            Console.Write("\nUnion :");
            for (int k = 0; k < j; k++)
            {
                Console.Write($"[ {unionSet[k]} ]");
            }
        }

        public void Intersection(Sets sets1, Sets sets2)
        {
            int[] intersectionSet = new int[100];
            int j = 0;

            for (int i = 0; i <= sets1.setRare; i++)
            {
                for (int k = 0; k <= sets2.setRare; k++)
                {
                    if (sets1.set[i] == sets2.set[k])
                    {
                        intersectionSet[j] = sets1.set[i];
                        j++;
                        break;
                    }
                }
            }

            Console.Write("\nIntersection: ");
            for (int i = 0; i < j; i++)
            {
                Console.Write($"[ {intersectionSet[i]} ] ");
            }
        }
    }

}
