using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverMethodDesignPattern.Observer;

namespace ObserverMethodDesignPattern.Subcriber
{
    internal class Subscribers : I_Observers
    {
        public string Name { get; set; }
        public Subscribers(string name)
        {
            Name = name;
        }
        public void Notified()
        {
            Console.WriteLine($"Hello {Name}");
            Console.WriteLine("Notification: New video uploaded");
        }
    }
}
