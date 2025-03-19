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
    internal class SupplierOperations : Service
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
                        Console.WriteLine("\nSupplier Management");
                        Console.ResetColor();
                        Console.WriteLine("***************************************");
                        Console.WriteLine("What action do you want to perform in Supplier Management?");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("=======================================");
                        Console.WriteLine("1. Add Supplier");
                        Console.WriteLine("2. Update Supplier");
                        Console.WriteLine("3. Delete Supplier");
                        Console.WriteLine("4. View Supplier's Details");
                        Console.WriteLine("5. View All Suppliers");
                        Console.WriteLine("6. Go Back to Main Menu");
                        Console.WriteLine("=======================================");
                        Console.ResetColor();

                        Console.Write("\nEnter Your Choice For Supplier Management: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        int choice = int.Parse(Console.ReadLine());
                        Console.ResetColor();
                        switch (choice)
                        {
                            case 1:
                                Add(connection);
                                break;
                            case 2:
                                Update(connection);
                                break;
                            case 3:
                                Delete(connection);
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
                Console.Write("Enter Supplier Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Contact Information: ");
                string contactInfo = Console.ReadLine();

                string query3 = "SELECT * FROM Inventory";
                DisplayAllInventories(connection, ref query3);
                Console.WriteLine("---------------------------------------------");

                Console.Write("Enter Inventory ID: ");
                int inventoryId = int.Parse(Console.ReadLine());

                string checkQuery = "SELECT COUNT(*) FROM Supplier WHERE InventoryID = @InventoryID";
                CheckInventoryIDExistence(connection, ref checkQuery, ref inventoryId);

                string query = "INSERT INTO Supplier (Name, ContactInformation, InventoryId) VALUES (@Name, @ContactInformation, @InventoryId)";
                InsertSupplier(connection, ref query, ref name, ref contactInfo, ref inventoryId);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public void DisplayAllInventories(SqlConnection connection, ref string query3)
        {
            using (SqlCommand command = new SqlCommand(query3, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("---- All Inventories ----");
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["InventoryID"]}, Location: {reader["Location"]}");
                    }
                }
            }
        }
        public void CheckInventoryIDExistence(SqlConnection connection, ref string checkQuery, ref int inventoryId)
        {
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
            {
                checkCommand.Parameters.AddWithValue("@InventoryID", inventoryId);
                int exists = (int)checkCommand.ExecuteScalar();
                CheckExistenceCount(connection, ref exists);
            }
        }
        public void CheckExistenceCount(SqlConnection connection, ref int exists)
        {
            if (exists > 0)
            {
                Console.WriteLine("This Inventory Already Have A Supplier.");
                return;
            }
        }
        public void InsertSupplier(SqlConnection connection, ref string query, ref string name, ref string contactInfo, ref int inventoryId)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@ContactInformation", contactInfo);
                command.Parameters.AddWithValue("@InventoryId", inventoryId);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows inserted: {rowsAffected}");
            }
        }
        public void Update(SqlConnection connection)
        {
            try
            {
                Console.Write("Enter Supplier ID to Update: ");
                int supplierId = int.Parse(Console.ReadLine());

                Console.Write("Enter New Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter New Contact Information: ");
                string contactInfo = Console.ReadLine();

                string query = "UPDATE Supplier SET Name = @Name, ContactInformation = @ContactInformation WHERE SupplierID = @SupplierID";
                SetUpdatedItems(connection, ref query, ref name, ref contactInfo, ref supplierId);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public void SetUpdatedItems(SqlConnection connection, ref string query, ref string name, ref string contactInfo, ref int supplierId)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@ContactInformation", contactInfo);
                command.Parameters.AddWithValue("@SupplierID", supplierId);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows inserted: {rowsAffected}");
            }
        }

        public void Delete(SqlConnection connection)
        {
            try
            {
                Console.Write("Enter Supplier ID to Delete: ");
                int supplierId = int.Parse(Console.ReadLine());
                string query = "DELETE FROM Supplier WHERE SupplierID = @SupplierID";
                CheckQueryForDeleteSupplier(connection, ref query, ref supplierId);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public void CheckQueryForDeleteSupplier(SqlConnection connection, ref string query, ref int supplierId)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SupplierID", supplierId);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows inserted: {rowsAffected}");
            }
        }
        public void ViewSpecificDetails(SqlConnection connection)
        {
            try
            {
                Console.Write("Enter Supplier ID to View: ");
                int supplierId = int.Parse(Console.ReadLine());

                string query = "SELECT * FROM Supplier WHERE SupplierID = @SupplierID";
                CheckQueryForViewSpecificDetails(connection, ref query, ref supplierId);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public void CheckQueryForViewSpecificDetails(SqlConnection connection, ref string query, ref int supplierId)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SupplierID", supplierId);
                DisplaySpecificDetails(connection, command);


            }
        }
        public void DisplaySpecificDetails(SqlConnection connection, SqlCommand command)
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine($"Supplier ID: {reader["SupplierID"]}");
                    Console.WriteLine($"Name: {reader["Name"]}");
                    Console.WriteLine($"Contact Information: {reader["ContactInformation"]}");
                    Console.WriteLine($"Inventory ID: {reader["InventoryId"]}");
                }
                else
                {
                    throw new NotFoundException("Supplier ID not found.");
                }
            }
        }
        public void ViewAllDetails(SqlConnection connection)
        {
            try
            {
                string query = "SELECT * FROM Supplier";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DisplayAllDetails(connection, command);
                    Console.WriteLine("---------------------------------------------");
                }
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
                Console.WriteLine("----All Suppliers----");
                while (reader.Read())
                {
                    Console.WriteLine($"Supplier ID: {reader["SupplierID"]}, Name: {reader["Name"]}, Contact: {reader["ContactInformation"]}, Inventory ID: {reader["InventoryId"]}");
                }
            }
        }
    }
}
