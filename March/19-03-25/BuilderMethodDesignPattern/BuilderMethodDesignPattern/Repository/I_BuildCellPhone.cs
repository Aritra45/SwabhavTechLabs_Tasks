using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderMethodDesignPattern.Model;

namespace BuilderMethodDesignPattern.Repository
{
    internal interface I_BuildCellPhone
    {
        public void BuildProcessor();
        public void BuildOS();
        public void BuildCamera();

        public void BuildBattery();

        public void BuildScreenSize();
        public CellPhone GetCellPhone();
    }
}
