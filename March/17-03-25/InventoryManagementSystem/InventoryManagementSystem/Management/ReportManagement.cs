using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace InventoryManagementSystem.Management
{
    internal class ReportManagement
    {
        public void GenerateReport(SqlConnection connection)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nInventory Management System Report");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=======================================");
                string totalProductsQuery = "SELECT COUNT(*) FROM Product";
                using (SqlCommand command = new SqlCommand(totalProductsQuery, connection))
                {
                    int totalProducts = (int)command.ExecuteScalar();
                    Console.WriteLine($"Total Products: {totalProducts}");
                }

                string totalSuppliersQuery = "SELECT COUNT(*) FROM Supplier";
                using (SqlCommand command = new SqlCommand(totalSuppliersQuery, connection))
                {
                    int totalSuppliers = (int)command.ExecuteScalar();
                    Console.WriteLine($"Total Suppliers: {totalSuppliers}");
                }

                string totalTransactionsQuery = "SELECT COUNT(*) FROM Transactions";
                using (SqlCommand command = new SqlCommand(totalTransactionsQuery, connection))
                {
                    int totalTransactions = (int)command.ExecuteScalar();
                    Console.WriteLine($"Total Transactions: {totalTransactions}");
                }

                string totalStockValueQuery = "SELECT SUM(Quantity * Price) FROM Product";
                using (SqlCommand command = new SqlCommand(totalStockValueQuery, connection))
                {
                    var totalStockValue = command.ExecuteScalar();
                    Console.WriteLine($"Total Stock Value(₹): {totalStockValue}");
                }

                Console.WriteLine("=======================================");
                Console.ResetColor();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
