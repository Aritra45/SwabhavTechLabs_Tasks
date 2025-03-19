using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Exception;
using InventoryManagementSystem.Repository;
using Microsoft.Data.SqlClient;

namespace InventoryManagementSystem.Services
{
    internal class InventoryOperations : Service
    {
        string connectionString = ConfigurationManager.AppSettings["connectionStringName"];
        public void ChooseMenu()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    bool continueMenu = true;
                    while (continueMenu)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nInventory Management");
                        Console.ResetColor();
                        Console.WriteLine("***************************************");
                        Console.WriteLine("What action do you want to perform in Inventory Management?");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("=======================================");
                        Console.WriteLine("1. Add Inventory");
                        Console.WriteLine("2. Delete Inventory");
                        Console.WriteLine("3. Update Inventory");
                        Console.WriteLine("4. View Inventory Details");
                        Console.WriteLine("5. View All inventories");
                        Console.WriteLine("6. Go Back to Main Menu");
                        Console.WriteLine("=======================================");
                        Console.ResetColor();

                        Console.Write("\nEnter Your Choice For Inventory Management: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        int choice = int.Parse(Console.ReadLine());
                        Console.ResetColor();
                        switch (choice)
                        {
                            case 1:
                                Add(connection);
                                break;
                            case 2:
                                Delete(connection);
                                break;
                            case 3:
                                Update(connection);
                                break;
                            case 4:
                                ViewSpecificDetails(connection);
                                break;
                            case 5:
                                ViewAllDetails(connection);
                                break;
                            case 6:
                                continueMenu = false;
                                break;
                            default:
                                throw new InValidChoiceException("Invalid choice, please try again.");
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
        public void Add(SqlConnection connection)
        {
            try
            {
                Console.Write("Enter Inventory Location: ");
                string location = Console.ReadLine();
                string insertQuery = "INSERT INTO Inventory (Location) VALUES (@Location)";
                CheckInsertQueryForAdd(connection, ref location, ref insertQuery);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void CheckInsertQueryForAdd(SqlConnection connection, ref string location, ref string insertQuery)
        {
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@Location", location);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows inserted: {rowsAffected}");
            }
        }

        public void Delete(SqlConnection connection)
        {
            try
            {
                Console.Write("Enter Inventory ID: ");
                int inventoryID = Convert.ToInt32(Console.ReadLine());
                string checkSupplierQuery = "SELECT COUNT(*) FROM Supplier WHERE InventoryID = @InventoryID";
                CheckSupplierQuery(connection, ref inventoryID, ref checkSupplierQuery);
                string checkProductQuery = "SELECT COUNT(*) FROM Product WHERE InventoryID = @InventoryID";
                CheckInventoryID(connection, ref inventoryID, ref checkProductQuery);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void CheckSupplierQuery(SqlConnection connection, ref int inventoryID, ref string checkSupplierQuery)
        {

            using (SqlCommand checkCommand = new SqlCommand(checkSupplierQuery, connection))
            {
                checkCommand.Parameters.AddWithValue("@InventoryID", inventoryID);

                int supplierCount = (int)checkCommand.ExecuteScalar();

                CheckSupplierCount(connection, ref supplierCount, ref inventoryID);
            }
        }
        public void CheckSupplierCount(SqlConnection connection, ref int supplierCount, ref int inventoryID)
        {
            if (supplierCount > 0)
            {
                string updateSupplierQuery = "UPDATE Supplier SET InventoryID = NULL WHERE InventoryID = @InventoryID";
                UpdateSupplier(connection, ref inventoryID, ref updateSupplierQuery);
            }
        }
        public void UpdateSupplier(SqlConnection connection, ref int inventoryID, ref string updateSupplierQuery)
        {
            using (SqlCommand updateCommand = new SqlCommand(updateSupplierQuery, connection))
            {
                updateCommand.Parameters.AddWithValue("@InventoryID", inventoryID);

                updateCommand.ExecuteNonQuery();
            }
        }
        public void CheckInventoryID(SqlConnection connection, ref int inventoryID, ref string checkProductQuery)
        {
            using (SqlCommand checkCommand = new SqlCommand(checkProductQuery, connection))
            {
                checkCommand.Parameters.AddWithValue("@InventoryID", inventoryID);

                int exists = (int)checkCommand.ExecuteScalar();

                CheckExistenceOfInventoryID(connection, ref exists, ref inventoryID);
                string deleteInventory = "DELETE FROM Inventory WHERE InventoryID = @InventoryID";
                CheckDeleteQuery(connection, ref inventoryID, ref deleteInventory);
            }
        }

        public void CheckExistenceOfInventoryID(SqlConnection connection, ref int exists, ref int inventoryID)
        {
            if (exists > 0)
            {
                string updateProductQuery = "UPDATE Product SET Quantity = 0 WHERE InventoryID = @InventoryID";
                UpdateProductQuantity(connection, ref updateProductQuery, ref inventoryID);
            }
        }
        public void UpdateProductQuantity(SqlConnection connection, ref string updateProductQuery, ref int inventoryID)
        {
            using (SqlCommand updateCommand = new SqlCommand(updateProductQuery, connection))
            {
                updateCommand.Parameters.AddWithValue("@InventoryID", inventoryID);

                updateCommand.ExecuteNonQuery();
            }
        }
        public void CheckDeleteQuery(SqlConnection connection, ref int inventoryID, ref string deleteInventory)
        {
            using (SqlCommand command = new SqlCommand(deleteInventory, connection))
            {
                command.Parameters.AddWithValue("@InventoryID", inventoryID);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows inserted: {rowsAffected}");
            }
        }

        public void Update(SqlConnection connection)
        {
            try
            {
                Console.Write("Enter Inventory ID: ");
                int inventoryID = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter New location: ");
                string newLocation = Console.ReadLine();
                string updateQuery = "UPDATE Inventory SET location = @Location WHERE InventoryID = @InventoryID";
                CheckUpdateLocationQuery(connection, ref inventoryID, ref newLocation, ref updateQuery);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void CheckUpdateLocationQuery(SqlConnection connection, ref int inventoryID, ref string newLocation, ref string updateQuery)
        {
            using (SqlCommand command = new SqlCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@InventoryID", inventoryID);
                command.Parameters.AddWithValue("@Location", newLocation);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows inserted: {rowsAffected}");
            }
        }

        public void ViewSpecificDetails(SqlConnection connection)
        {
            try
            {
                Console.Write("Enter Product ID to View: ");
                int inventoryId = int.Parse(Console.ReadLine());
                string query = "SELECT * FROM Inventory WHERE InventoryID = @InventoryID";
                CheckQueryForViewSpecificDetails(connection, ref inventoryId, ref query);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void CheckQueryForViewSpecificDetails(SqlConnection connection, ref int inventoryId, ref string query)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InventoryID", inventoryId);

                DisplaySpecificDetails(connection, command);
            }
        }
        public void DisplaySpecificDetails(SqlConnection connection, SqlCommand command)
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine($"Inventory ID: {reader["InventoryID"]}");
                    Console.WriteLine($"Location: {reader["Location"]}");
                }
                else
                {
                    throw new NotFoundException("Inventory ID not found.");
                }
            }
        }
        public void ViewAllDetails(SqlConnection connection)
        {
            try
            {
                string query = "SELECT * FROM Inventory";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DisplayAllDetails(connection, command);
                }
                Console.WriteLine("---------------------------------------------");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public void DisplayAllDetails(SqlConnection connection, SqlCommand command)
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("---- All Inventories ----");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["InventoryID"]}, Location: {reader["location"]}");
                }
            }
        }
    }
}
