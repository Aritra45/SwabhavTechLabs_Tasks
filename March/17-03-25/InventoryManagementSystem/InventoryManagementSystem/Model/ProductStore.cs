using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Exception;
using InventoryManagementSystem.Management;
using InventoryManagementSystem.Repository;
using Microsoft.Data.SqlClient;

namespace InventoryManagementSystem.Model
{
    internal class ProductStore
    {
        public int ProductID { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int InventoryID { get; set; }

        public ProductStore() { }
        public ProductStore(string name, string description, int quantity, decimal price, int inventoryID)
        {
            Name = name;
            Description = description;
            Quantity = quantity;
            Price = price;
            InventoryID = inventoryID;
        }
    }

}
