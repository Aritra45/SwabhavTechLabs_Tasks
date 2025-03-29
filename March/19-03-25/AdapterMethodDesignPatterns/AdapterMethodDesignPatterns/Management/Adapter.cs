using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdapterMethodDesignPatterns.Repository;
using AdapterMethodDesignPatterns.Service;

namespace AdapterMethodDesignPatterns.Management
{
    internal class Adapter : I_Vehical
    {
        public NewServices NewServices { get; set; }

        public Adapter(NewServices newServices)
        {
            NewServices = newServices;
        }

        public void Specifications()
        {
            NewServices.SoundBox();
        }
    }
}
