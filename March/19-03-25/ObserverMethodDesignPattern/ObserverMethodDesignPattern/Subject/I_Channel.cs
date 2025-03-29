using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverMethodDesignPattern.Observer;

namespace ObserverMethodDesignPattern.Subject
{
    internal interface I_Channel
    {
        public void Subscribe(I_Observers ob);
        public void Unsubscribe(I_Observers ob);
        public void Notify();
    }
}
