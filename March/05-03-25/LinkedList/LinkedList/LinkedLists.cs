using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class LinkedLists
    {
        public Node head;
        //private LinkedLists(Node node) {
        //}

        public void AddFirst(object obj)
        {
            Node newNode = new Node(obj);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
        }

        //public void AddEnd(object obj)
        //{
        //    Node newNode = new Node(obj);
        //    if (head == null)
        //    {
        //        head = newNode;
        //    }
        //    else
        //    {
        //        Node temp = head;
        //        while(true)
        //        {
        //            if (temp.Next == null)
        //            {
        //                temp.Next = newNode;
        //                break;
        //            }
        //            temp = temp.Next;
        //        }
        //    }
        //}

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
                while (temp.Next != null)
                {
                   temp = temp.Next;
                }
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
                Node temp = head;
                
                while (true)
                {                    
                    Console.WriteLine(temp.Data.ToString());
                    if (temp.Next == null)
                    {
                        break;
                    }
                    temp = temp.Next;
                    if (temp.Next == null) { 
                        Console.WriteLine(temp.Data.ToString());
                        break;
                    }

                }
            }
        }
    } 
}
