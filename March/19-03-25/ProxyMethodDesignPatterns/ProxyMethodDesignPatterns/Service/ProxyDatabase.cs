using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ProxyMethodDesignPatterns.Repository;

namespace ProxyMethodDesignPatterns.Service
{
    internal class ProxyDatabase : I_Database
    {
        private I_Database realDatabase = new RealDatabase();
        public string GetDataByID(int id)
        {
            return realDatabase.GetDataByID(id);
        }
    }
}
