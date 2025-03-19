using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Exception;
using InventoryManagementSystem.Model;
using InventoryManagementSystem.Repository;
using Microsoft.Data.SqlClient;

namespace InventoryManagementSystem.Services
{
    internal class TransactionOperations : TransactionService
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
                        Console.WriteLine("\nTransaction Management");
                        Console.ResetColor();
                        Console.WriteLine("***************************************");
                        Console.WriteLine("What action do you want to perform in Transaction Management?");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("=======================================");
                        Console.WriteLine("1. Add Stock");
                        Console.WriteLine("2. Remove Stock");
                        Console.WriteLine("3. View Transaction History");
                        Console.WriteLine("4. Go Back to Main Menu");
                        Console.WriteLine("=======================================");
                        Console.ResetColor();

                        Console.Write("\nEnter Your Choice For Transaction Management: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        int choice = int.Parse(Console.ReadLine());
                        Console.ResetColor();
                        switch (choice)
                        {
                            case 1:
                                Add_Stock(connection);
                                break;
                            case 2:
                                Delete_Stock(connection);
                                break;
                            case 3:
                                ViewAllDetails(connection);
                                break;
                            case 4:
                                continueMenu = false;
                                break;
                            default:
                                throw new InValidChoiceException("Invalid choice, please try again.");
                        }
                    }
                }
                catch (InValidChoiceException ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        public void Add_Stock(SqlConnection connection)
        {
            try
            {
                string query = "SELECT * FROM Product";
                DisplayAllProducts(connection, ref query);
                Console.WriteLine("---------------------------------------------");

                Console.Write("Enter Product ID: ");
                int productId = int.Parse(Console.ReadLine());

                Console.Write("Enter Quantity to Add: ");
                int quantity = int.Parse(Console.ReadLine());

                string checkQuery = "SELECT Quantity FROM Product WHERE ProductID = @ProductID";
                int currentQuantity = 0;
                FetchQuantityOfProduct(connection, ref checkQuery, ref productId, ref currentQuantity);

                string updateQuery = "UPDATE Product SET Quantity = Quantity + @Quantity WHERE ProductID = @ProductID";
                UpdateQuantity(connection, ref quantity, ref updateQuery, ref productId);

                int inventoryID = 0;
                string takeInventoryID = "SELECT InventoryID FROM Product WHERE ProductID = @ProductID";
                FetchInventoryIDFromProductTable(connection, ref takeInventoryID, ref productId, ref inventoryID);

                string insertQuery = "INSERT INTO Transactions (ProductID, Type, Quantity, InventoryId) VALUES (@ProductID, @Type, @Quantity, @InventoryId)";
                InsertvaluesInTransactionTable(connection, ref insertQuery, ref productId, ref quantity, ref inventoryID);


            }
            catch (NotFoundException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public void DisplayAllProducts(SqlConnection connection, ref string query)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
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
        public void FetchQuantityOfProduct(SqlConnection connection, ref string checkQuery, ref int productId, ref int currentQuantity)
        {
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
            {
                checkCommand.Parameters.AddWithValue("@ProductID", productId);
                int result = (int)checkCommand.ExecuteScalar();
                CheckResult(connection, ref result);
                currentQuantity = (int)result;
            }
        }
        public void CheckResult(SqlConnection connection, ref int result)
        {
            if (result == 0)
            {
                throw new NotFoundException("Product not found.");
            }
        }

        public void UpdateQuantity(SqlConnection connection, ref int quantity, ref string updateQuery, ref int productId)
        {
            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
            {
                updateCommand.Parameters.AddWithValue("@Quantity", quantity);
                updateCommand.Parameters.AddWithValue("@ProductID", productId);

                updateCommand.ExecuteNonQuery();
            }
        }
        public void FetchInventoryIDFromProductTable(SqlConnection connection, ref string takeInventoryID, ref int productId, ref int inventoryID)
        {
            using (SqlCommand takeCommand = new SqlCommand(takeInventoryID, connection))
            {
                takeCommand.Parameters.AddWithValue("@ProductID", productId);
                using (SqlDataReader reader = takeCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        inventoryID = (int)reader["InventoryID"];
                    }
                }
                takeCommand.ExecuteNonQuery();
            }
        }
        public void InsertvaluesInTransactionTable(SqlConnection connection, ref string insertQuery, ref int productId, ref int quantity, ref int inventoryID)
        {
            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
            {
                insertCommand.Parameters.AddWithValue("@ProductID", productId);
                insertCommand.Parameters.AddWithValue("@Type", TransactionEnum.Add_Stock.ToString());
                insertCommand.Parameters.AddWithValue("@Quantity", quantity);
                insertCommand.Parameters.AddWithValue("@InventoryId", inventoryID);

                int rowsAffected = insertCommand.ExecuteNonQuery();
                Console.WriteLine($"Rows inserted: {rowsAffected}");
            }
        }
        public void Delete_Stock(SqlConnection connection)
        {
            try
            {
                string query = "SELECT * FROM Product";
                DisplayAllProducts(connection, ref query);
                Console.WriteLine("---------------------------------------------");
                Console.Write("Enter Product ID: ");
                int productId = int.Parse(Console.ReadLine());
                Console.Write("Enter Quantity to Remove: ");
                int quantity = int.Parse(Console.ReadLine());
                int inventoryID = 0;
                string takeInventoryID = "SELECT InventoryID FROM Product WHERE ProductID = @ProductID";
                FetchInventoryIDFromProductTable(connection, ref takeInventoryID, ref productId, ref inventoryID);
                string checkQuery = "SELECT Quantity FROM Product WHERE ProductID = @ProductID";
                int currentQuantity = 0;
                FetchQuantity(connection, ref checkQuery, ref productId, ref currentQuantity, ref quantity);

                string updateQuery = "UPDATE Product SET Quantity = Quantity - @Quantity WHERE ProductID = @ProductID";
                UpdateQuantity(connection, ref updateQuery, ref quantity, ref productId);

                string insertQuery = "INSERT INTO Transactions (ProductID, Type, Quantity, InventoryId) VALUES (@ProductID, @Type, @Quantity, @InventoryId)";
                InsertvaluesInTransactionTable(connection, ref insertQuery, ref productId, ref quantity, ref inventoryID);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void FetchQuantity(SqlConnection connection, ref string checkQuery, ref int productId, ref int currentQuantity, ref int quantity)
        {
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
            {
                checkCommand.Parameters.AddWithValue("@ProductID", productId);
                int result = (int)checkCommand.ExecuteScalar();
                CheckResult(connection, ref result);
                currentQuantity = (int)result;
                CheckInsufficientstock(connection, ref currentQuantity, ref quantity);
            }
        }
        public void CheckInsufficientstock(SqlConnection connection, ref int currentQuantity, ref int quantity)
        {
            if (currentQuantity < quantity)
            {
                Console.WriteLine("Insufficient stock available.");
                return;
            }
        }
        public void UpdateQuantity(SqlConnection connection, ref string updateQuery, ref int quantity, ref int productId)
        {
            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
            {
                updateCommand.Parameters.AddWithValue("@Quantity", quantity);
                updateCommand.Parameters.AddWithValue("@ProductID", productId);

                updateCommand.ExecuteNonQuery();
            }
        }
        public void ViewAllDetails(SqlConnection connection)
        {
            try
            {
                string query = "SELECT * FROM Transactions ORDER BY TransactionID DESC";
                ViewTransactionFromLast(connection, ref query);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public void ViewTransactionFromLast(SqlConnection connection, ref string query)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                DisplayAllDetails(connection, command);
                Console.WriteLine("---------------------------------------------");
            }
        }
        public void DisplayAllDetails(SqlConnection connection, SqlCommand command)
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("----Transaction History----");
                while (reader.Read())
                {
                    string typeValue = reader["Type"].ToString();
                    TransactionEnum transactionType = (TransactionEnum)Enum.Parse(typeof(TransactionEnum), typeValue);

                    Console.WriteLine($"Transaction ID: {reader["TransactionID"]}, Product ID: {reader["ProductID"]}, Type: {transactionType}, Quantity: {reader["Quantity"]}, Date: {reader["Date"]}, Inventory ID: {reader["InventoryId"]}");
                }
            }
        }
    }
}
