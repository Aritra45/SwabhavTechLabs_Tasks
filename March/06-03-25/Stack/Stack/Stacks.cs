using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    internal class Stacks
    {
        public Node Top;
        Node[] stack = new Node[100];
        public void AddElement(object obj)
        {
            Node newNode = new Node(obj);
            //Top = newNode;
            int i = 0;
            while (stack[i]  != null)
            {
                i++;
            }
            stack[i] = newNode;
            Top = stack[i];
        }

        public void RemoveElement()
        {
            if (Top == null)
            {
                Console.WriteLine("Stack Empty");
            }
            else
            {
                int i = 0;
                while (stack[i] != null)
                {
                    Top = stack[i];
                    i++;
                }
                if (i == 1)
                {
                    Top = null;
                    stack[0] = null;
                }
                else
                {
                    Top = stack[i - 2];
                    stack[i - 1] = null;
                }
            }
        }

        public void Display()
        {
            if (Top == null)
            {
                Console.WriteLine("Stack is Empty");
            }
            else
            {
                int i = 0;
                while (stack[i] != null)
                {

                    i++;
                }
                i = i - 1;
                while (i >= 0)
                {
                    Console.WriteLine(stack[i].Data);
                    i--;
                }
            }
        }
    }
}
