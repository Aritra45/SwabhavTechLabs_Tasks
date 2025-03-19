using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using InventoryManagementSystem.Exception;
using InventoryManagementSystem.Repository;
using Microsoft.Data.SqlClient;

namespace InventoryManagementSystem.Model
{
    internal class InventoryStore
    {

        public int InventoryID { get;}
        public string Name { get; set; }

        public InventoryStore() { }

        public InventoryStore(string name) 
        {
            Name = name;
        }

    }
}
