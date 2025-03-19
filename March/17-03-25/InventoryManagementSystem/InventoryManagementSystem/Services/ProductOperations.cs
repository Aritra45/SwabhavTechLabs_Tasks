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
    internal class ProductOperations : Service
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
                        Console.WriteLine("\nProduct Management");
                        Console.ResetColor();
                        Console.WriteLine("***************************************");
                        Console.WriteLine("What action do you want to perform in Product Management?");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("=======================================");
                        Console.WriteLine("1. Add Product");
                        Console.WriteLine("2. Update Product");
                        Console.WriteLine("3. Delete Product");
                        Console.WriteLine("4. View Product Details");
                        Console.WriteLine("5. View All Products");
                        Console.WriteLine("6. Go Back to Main Menu");
                        Console.WriteLine("=======================================");
                        Console.ResetColor();

                        Console.Write("\nEnter Your Choice For Product Management: ");
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
                Console.Write("Enter Product Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Product Description: ");
                string description = Console.ReadLine();
                Console.Write("Enter Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                Console.Write("Enter Price: ");
                decimal price = decimal.Parse(Console.ReadLine());
                string query3 = "SELECT * FROM Inventory";
                DisplayAllInventories(connection, ref query3);
                Console.WriteLine("---------------------------------------------");
                Console.Write("Enter Inventory ID: ");
                int inventoryId = int.Parse(Console.ReadLine());
                string query2 = "SELECT COUNT(*) FROM Product WHERE Name = @Name AND InventoryId = @InventoryId";
                CheckNameAndInventoryIDExistence(connection, ref query2, ref name, ref inventoryId);
                string query = "INSERT INTO Product (Name, Description, Quantity, Price, InventoryId) VALUES (@Name, @Description, @Quantity, @Price, @InventoryId)";
                InsertProduct(connection, ref query, ref name, ref inventoryId, ref quantity, ref price, ref description);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
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
        public void CheckNameAndInventoryIDExistence(SqlConnection connection, ref string query2, ref string name, ref int inventoryId)
        {
            using (SqlCommand command2 = new SqlCommand(query2, connection))
            {
                command2.Parameters.AddWithValue("@Name", name);
                command2.Parameters.AddWithValue("@InventoryId", inventoryId);
                int count = (int)command2.ExecuteScalar();
                CheckExistenceCount(connection, ref count);
            }
        }
        public void CheckExistenceCount(SqlConnection connection, ref int count)
        {
            if (count > 0)
            {
                Console.WriteLine("Name Already Exist");
                return;
            }
        }

        public void InsertProduct(SqlConnection connection, ref string query, ref string name, ref int inventoryId, ref int quantity, ref decimal price, ref string description)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@InventoryId", inventoryId);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows inserted: {rowsAffected}");
            }
        }

        public void Update(SqlConnection connection)
        {
            try
            {
                Console.Write("Enter Product ID to Update: ");
                int productId = int.Parse(Console.ReadLine());

                Console.Write("Enter New Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter New Description: ");
                string description = Console.ReadLine();
                Console.Write("Enter New Price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                string query = "UPDATE Product SET Name = @Name, Description = @Description, Price = @Price WHERE ProductID = @ProductID";
                SetUpdatedItems(connection, ref query, ref name, ref price, ref description, ref productId);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void SetUpdatedItems(SqlConnection connection, ref string query, ref string name, ref decimal price, ref string description, ref int productId)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@ProductID", productId);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows inserted: {rowsAffected}");
            }
        }
        public void Delete(SqlConnection connection)
        {
            try
            {
                Console.Write("Enter Product ID to Delete: ");
                int productId = int.Parse(Console.ReadLine());

                string query = "DELETE FROM Product WHERE ProductID = @ProductID";
                CheckQueryForDeleteproduct(connection, ref query, ref productId);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void CheckQueryForDeleteproduct(SqlConnection connection, ref string query, ref int productId)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProductID", productId);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows inserted: {rowsAffected}");
            }
        }

        public void ViewSpecificDetails(SqlConnection connection)
        {
            try
            {
                Console.Write("Enter Product ID to View: ");
                int productId = int.Parse(Console.ReadLine());

                string query = "SELECT * FROM Product WHERE ProductID = @ProductID";
                CheckQueryForViewSpecificDetails(connection, ref query, ref productId);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void CheckQueryForViewSpecificDetails(SqlConnection connection, ref string query, ref int productId)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProductID", productId);

                DisplaySpecificDetails(connection, command);
            }
        }
        public void DisplaySpecificDetails(SqlConnection connection, SqlCommand command)
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine($"Product ID: {reader["ProductID"]}");
                    Console.WriteLine($"Name: {reader["Name"]}");
                    Console.WriteLine($"Description: {reader["Description"]}");
                    Console.WriteLine($"Quantity: {reader["Quantity"]}");
                    Console.WriteLine($"Price: {reader["Price"]}");
                    Console.WriteLine($"InventoryID:{reader["InventoryID"]}");
                }
                else
                {
                    throw new NotFoundException("Product ID not found.");
                }
            }
        }
        public void ViewAllDetails(SqlConnection connection)
        {
            try
            {
                string query = "SELECT * FROM Product";
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
                Console.WriteLine("---- All Products ----");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["ProductID"]}, Name: {reader["Name"]}, Quantity: {reader["Quantity"]}, Price: {reader["Price"]}, InventoryID: {reader["InventoryID"]}");
                }
            }
        }
    }
}
