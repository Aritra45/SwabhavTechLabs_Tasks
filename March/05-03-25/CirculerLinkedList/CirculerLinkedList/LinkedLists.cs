using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubblyLinkedList
{
    internal class LinkedLists
    {
        public Node head;

        public void AddFirst(object obj)
        {
            Node newNode = new Node(obj);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node temp = head.Prev;
                newNode.Next = head;
                head.Prev = newNode;
                newNode.Prev = temp;
                head = newNode;
            }
        }

        public void AddEnd1(object obj)
        {
            Node newNode = new Node(obj);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node temp = head;
                while(temp.Next!=head.Prev)
                {
                    temp = temp.Next;
                }
                Node temp2 = temp.Next;
                newNode.Prev = temp;
                newNode.Next = temp2;
                temp.Next = newNode;
            }
        }

        public void AddAddBetween(object obj)
        {
            Node newNode = new Node(obj);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node temp = head;
                int a = 2;
                object o = a;
                while (temp.Data == o)
                {
                    temp = temp.Next;
                }
                newNode.Next = temp.Next;
                temp.Next = newNode;
                newNode.Prev = temp;
            }
        }



        public void Display()
        {
            if (head == null)
            {
                Console.WriteLine("not Exist");
            }
            else
            {
                Node temp1 = head;
                Node temp2 = head.Prev;
                while(temp1.Next != temp2)
                {
                    Console.WriteLine(temp1.Data.ToString());
                    temp1 = temp1.Next;
                }
                if(temp1.Next == temp2)
                {
                    Console.WriteLine(temp1.Data.ToString());
                }
                
            }
        }
    }
}
