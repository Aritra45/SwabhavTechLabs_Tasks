using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class Dictionarys
    {
        public Node head;
        public void AddElement(object obj1, object obj2)
        {
            Node newNode = new Node(obj1, obj2);
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

        public void RemoveElement(object obj1, object obj2)
        {
            if(head == null)
            {
                Console.WriteLine("Dictionary is Empty");
            }
            else
            {
                Node temp1 = head;
                Node temp2 = temp1.Next;
                while (temp1.Next != null || temp1 == head)
                {
                    if((temp1.Key == obj1 && temp1.Value == obj2) )
                    { 
                        if(temp1 == head )
                        {
                            head = temp1.Next;
                            temp1.Key = null;
                            temp1.Value = null;
                            break;
                        }
                                           
                    }
                    if (temp2 != null)
                    {
                        if (temp2.Key == obj1 && temp2.Value == obj2)
                        {
                            temp1.Next = temp2.Next;
                            temp2.Key = null;
                            temp2.Value = null;
                            break;
                        }

                        temp2 = temp2.Next;
                        temp1 = temp1.Next;
                    }
                    
                }
            }
        }
        public void Display()
        {
            if(head == null)
            {
                Console.WriteLine("Dictionary not exist");
            }
            else
            {
                Node temp = head;
                while (true)
                {
                    Console.WriteLine($"{temp.Key.ToString()} : {temp.Value.ToString()}");
                    if(temp.Next == null)
                    {
                        break;
                    }
                    temp = temp.Next;
                    if(temp.Next == null)
                    {
                        Console.WriteLine($"{temp.Key.ToString()} : {temp.Value.ToString()}");
                        break;
                    }
                }
            }
        }
    }
}
