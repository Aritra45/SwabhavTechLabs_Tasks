using System;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace StudentAppUsingDB.Model
{
    public class StudentManager
    {
        string connectionString = ConfigurationManager.AppSettings["connectionStringName"];

        public void ChooseMenu()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection opened successfully.");

                    bool continueMenu = true;
                    while (continueMenu)
                    {
                        Console.WriteLine("\nWelcome to Student Management App");
                        Console.WriteLine("What action do you want to perform?");
                        Console.WriteLine("1. Create a new Student");
                        Console.WriteLine("2. Display all Students");
                        Console.WriteLine("3. Update Student Email");
                        Console.WriteLine("4. Delete a Student Record");
                        Console.WriteLine("5. Exit");

                        int userInput = int.Parse(Console.ReadLine());
                        switch (userInput)
                        {
                            case 1:
                                CreateStudent(connection);
                                break;
                            case 2:
                                ReadStudents(connection);
                                break;
                            case 3:
                                Console.WriteLine("Enter Student Id to update:");
                                int updateId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter new Email:");
                                string newEmail = Console.ReadLine();
                                UpdateStudentEmail(connection, updateId, newEmail);
                                break;
                            case 4:
                                Console.WriteLine("Enter Student Id to delete:");
                                int deleteId = int.Parse(Console.ReadLine());
                                DeleteStudent(connection, deleteId);
                                break;
                            case 5:
                                continueMenu = false;
                                Console.WriteLine("Exiting the application.");
                                break;
                            default:
                                Console.WriteLine("Invalid option, please choose again.");
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        static void CreateStudent(SqlConnection connection)
        {
            Console.WriteLine("Enter student details:");
            Console.WriteLine("Student Id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Student Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Roll Number:");
            int rollNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Address:");
            string address = Console.ReadLine();

            string query = "INSERT INTO student (student_id, student_name, roll_number, email, address) VALUES (@Id, @Name, @RollNumber, @Email, @Address)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@RollNumber", rollNumber);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Address", address);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows inserted: {rowsAffected}");
            }
        }

        static void ReadStudents(SqlConnection connection)
        {
            string query = "SELECT * FROM student";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["student_id"]}, {reader["student_name"]}, {reader["roll_number"]}, {reader["email"]}, {reader["address"]}");
                    }
                }
            }
        }

        static void UpdateStudentEmail(SqlConnection connection, int id, string newEmail)
        {
            string query = "UPDATE student SET email = @Email WHERE student_id = @Id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Email", newEmail);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows updated: {rowsAffected}");
            }
        }

        static void DeleteStudent(SqlConnection connection, int id)
        {
            string query = "DELETE FROM student WHERE student_id = @Id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows deleted: {rowsAffected}");
            }
        }
    }
}
