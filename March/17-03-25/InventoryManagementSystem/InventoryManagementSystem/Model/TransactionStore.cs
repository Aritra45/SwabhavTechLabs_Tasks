using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Exception;
using InventoryManagementSystem.Management;
using InventoryManagementSystem.Repository;
using Microsoft.Data.SqlClient;

namespace InventoryManagementSystem.Model
{
    internal class TransactionStore
    {

        public int TransactionID { get;}
        public int ProductID { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get;}
        public int InventoryID { get; set; }

        public TransactionStore() { }
        public TransactionStore(int productID, string type, int quantity, int inventoryID)
        {
            ProductID = productID;
            Type = type;
            Quantity = quantity;
            Quantity = quantity;
            InventoryID = inventoryID;
        }
        
    }
}
