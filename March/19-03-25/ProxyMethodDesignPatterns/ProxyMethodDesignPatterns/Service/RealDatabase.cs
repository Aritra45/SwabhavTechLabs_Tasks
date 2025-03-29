using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxyMethodDesignPatterns.Repository;

namespace ProxyMethodDesignPatterns.Service
{
    internal class RealDatabase : I_Database
    {
        public string GetDataByID(int id)
        {
            return $"Data from DB for ID = {id}";
        }
    }
}
