using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Exception;
using InventoryManagementSystem.Model;
using InventoryManagementSystem.Repository;
using InventoryManagementSystem.Services;
using Microsoft.Data.SqlClient;

namespace InventoryManagementSystem.Management
{
    internal class Store : Menu
    {
        string connectionString = ConfigurationManager.AppSettings["connectionStringName"];
        Service productStore = new ProductOperations();
        Service supplierStore = new SupplierOperations();
        TransactionService transactionStore = new TransactionOperations();
        Service inventoryStore = new InventoryOperations();
        
        ReportManagement reportManagement = new ReportManagement();
        public void ChooseMenu()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection opened successfully.");
                    Console.WriteLine("***************************************");
                    bool continueMenu = true;
                    while (continueMenu)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nWelcome to the Inventory Management System");
                        Console.ResetColor();
                        Console.WriteLine("***************************************");
                        Console.WriteLine("What action do you want to perform?");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("=======================================");
                        Console.WriteLine("1. Product Management");
                        Console.WriteLine("2. Supplier Management");
                        Console.WriteLine("3. Transaction Management");
                        Console.WriteLine("4. Inventory Management");
                        Console.WriteLine("5. Generate Report");
                        Console.WriteLine("6. Exit");
                        Console.WriteLine("=======================================");
                        Console.ResetColor();

                        Console.Write("\nEnter Your Choice: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        int userInput = int.Parse(Console.ReadLine());
                        Console.ResetColor();
                        switch (userInput)
                        {
                            case 1:
                                Console.WriteLine("Redirecting to Product Management...");
                                productStore.ChooseMenu();
                                break;
                            case 2:
                                Console.WriteLine("Redirecting to Supplier Management...");
                                supplierStore.ChooseMenu();
                                break;
                            case 3:
                                Console.WriteLine("Redirecting to Transaction Management...");
                                transactionStore.ChooseMenu();
                                break;
                            case 4:
                                Console.WriteLine("Redirecting to Inventory Management...");
                                inventoryStore.ChooseMenu();
                                break;
                            case 5:
                                Console.WriteLine("Generating Report...");
                                reportManagement.GenerateReport(connection);
                                break;
                            case 6:
                                continueMenu = false;
                                Console.WriteLine("\nExiting the application . . .");
                                break;
                            default:
                                throw new InValidChoiceException("Invalid option, please choose again.");
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
