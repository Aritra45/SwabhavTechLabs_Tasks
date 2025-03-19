using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Exception;
using InventoryManagementSystem.Management;
using InventoryManagementSystem.Repository;
using Microsoft.Data.SqlClient;

namespace InventoryManagementSystem.Model
{
    internal class SupplierStore
    {

        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string ContactInformation {  get; set; }
        public int InventoryID { get; set; }

        public SupplierStore() { }
        public SupplierStore(string name, string contactInformation, int inventoryID) 
        {
            Name = name;
            ContactInformation = contactInformation;
            InventoryID = inventoryID;
        }
        
    }
}
