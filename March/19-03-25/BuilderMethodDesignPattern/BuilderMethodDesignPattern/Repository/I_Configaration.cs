using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderMethodDesignPattern.Repository
{
    internal interface I_Configaration
    {
        public void SetOS(string os);
        public void SetProcessor(string  Processor);
        public void SetScreenSize(double screenSize);
        public void SetBattery(int battery);
        public void SetCamera(int camera);
    }
}
