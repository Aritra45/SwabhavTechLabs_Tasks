using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    internal class Queues
    {
        public int rare=-1;
        Node[] queue = new Node[100];

        public void AddElement(object obj)
        {
            Node newNode = new Node(obj);
            int temp_rare= rare;
            if (temp_rare < 0)
            {
                temp_rare++;
                queue[temp_rare] = newNode;
            }
            else {
                while (temp_rare >= 0)
                {
                    queue[temp_rare + 1] = queue[temp_rare];
                    temp_rare--;
                }
                queue[temp_rare+1] = newNode;
                
            }
            rare++;

        }

        public void RemoveElement()
        {
            if (rare < 0)
            {
                Console.WriteLine("Queue is Empty");
            }
            else
            {
                queue[rare].Data = null;

                rare--;
            }
        }

        public void Display()
        {
            if (rare == -1)
            {
                Console.WriteLine("No Element to Remove");
            }
            else
            {
                //Node temp = front;
                int i = rare;
                while (i>=0)
                {
                    Console.WriteLine(queue[i].Data.ToString());
                    i--;
                    
                }
            }
        }
    }
}
