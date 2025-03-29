using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverMethodDesignPattern.Observer;
using ObserverMethodDesignPattern.Subject;

namespace ObserverMethodDesignPattern.Channels
{
    internal class YoutubeChannel : I_Channel
    {
        List<I_Observers> subscribes = new List<I_Observers>();
        public void Notify()
        {
            foreach(I_Observers observer in subscribes)
            {
                observer.Notified();
            }
        }

        public void Subscribe(I_Observers ob)
        {
            subscribes.Add(ob);
        }

        public void Unsubscribe(I_Observers ob)
        {
            subscribes.Remove(ob);
        }
    }
}
