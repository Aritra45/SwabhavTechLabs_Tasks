using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderMethodDesignPattern.Model;
using BuilderMethodDesignPattern.Repository;

namespace BuilderMethodDesignPattern.Service
{
    internal class Manufacturer
    {
        public I_BuildCellPhone Build {  get; set; }

        public Manufacturer(I_BuildCellPhone build)
        {
            Build = build;
        }

        public CellPhone GetCellPhone()
        {
            return Build.GetCellPhone();
        }

        public void DisplayCellPhone()
        {
            Build.BuildOS();
            Build.BuildScreenSize();
            Build.BuildCamera();
            Build.BuildBattery();
            Build.BuildProcessor();
        }
    }
}
