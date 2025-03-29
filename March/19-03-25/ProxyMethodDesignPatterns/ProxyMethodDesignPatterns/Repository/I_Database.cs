using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyMethodDesignPatterns.Repository
{
    internal interface I_Database
    {
        public string GetDataByID(int id);
    }
}
