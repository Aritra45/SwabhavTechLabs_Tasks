using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderMethodDesignPattern.Model;
using BuilderMethodDesignPattern.Repository;

namespace BuilderMethodDesignPattern.Service
{
    internal class Configaration : I_BuildCellPhone
    {
        private CellPhone cellPhone;

        public Configaration()
        {
            this.cellPhone = new CellPhone();
        }
        public void BuildBattery()
        {
            cellPhone.SetBattery(4000);
        }

        public void BuildCamera()
        {
            cellPhone.SetCamera(50);
        }

        public void BuildOS()
        {
            cellPhone.SetOS("Oxyzen");
        }

        public void BuildProcessor()
        {
            cellPhone.SetProcessor("Snapdragon");
        }

        public void BuildScreenSize()
        {
            cellPhone.SetScreenSize(16.08);
        }

        public CellPhone GetCellPhone()
        {
            return cellPhone;
        }
    }
}
