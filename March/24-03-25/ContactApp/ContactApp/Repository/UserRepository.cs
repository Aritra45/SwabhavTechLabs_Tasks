using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Database;
using ContactApp.Model;

namespace ContactApp.Repository
{
    internal class UserRepository
    {
        public void AddUser()
        {
            Console.WriteLine("Enter User Name: ");
            Console.ForegroundColor = ConsoleColor.Red;
            string name = Console.ReadLine();
            Console.ResetColor();

            using (var context = new MyContext())
            {
                User newUser = new User()
                {
                    Name = name,
                    IsAdmin = false,
                    IsActive = true,
                };


                context.User.Add(newUser);


                context.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("User added successfully!");
                Console.ResetColor();
            }
        }
        public void RemoveUser(int userID)
        {
            Console.WriteLine("Enter User ID: ");
            Console.ForegroundColor = ConsoleColor.Red;
            int id = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();

            using (var context = new MyContext())
            {

                User userToDeactivate = context.User.FirstOrDefault(u => u.UserId == id);
                
                if (userToDeactivate != null)
                {
                    //User userInfo = context.User.FirstOrDefault(cd => cd.UserId == userID);
                    if (userID == id)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("You are the Admin!!! You cannot remove yourself.");
                        Console.ResetColor();
                    }
                    else
                    {
                        userToDeactivate.IsActive = false;

                        context.User.Update(userToDeactivate);
                        context.SaveChanges();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"User with ID {id} is now deactivated.");
                        Console.ResetColor();
                        
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("User not found.");
                    Console.ResetColor();
                }


            }
        }
        public void UpdateUser()
        {
            Console.WriteLine("Enter User ID: ");
            Console.ForegroundColor = ConsoleColor.Red;
            int id = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();

            using (var context = new MyContext())
            {
                User userToUpdate = context.User.FirstOrDefault(u => u.UserId == id);
                if (userToUpdate != null)
                {
                    Console.WriteLine("Enter New User Name: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    string upadatedName = Console.ReadLine();
                    Console.ResetColor();
                    if (!string.IsNullOrWhiteSpace(upadatedName))
                    {
                        userToUpdate.Name = upadatedName;
                    }
                    Console.WriteLine("Enter User Activation (ON/OFF): ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    string isActive = Console.ReadLine().ToUpper();
                    Console.ResetColor();

                    if (isActive == "ON")
                    {
                        userToUpdate.IsActive = true;
                    }
                    else if (isActive == "OFF")
                    {
                        userToUpdate.IsActive = false;
                    }
                    context.User.Update(userToUpdate);
                    context.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("User updated successfully!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("User not found.");
                    Console.ResetColor();
                }
            }

        }
        public void ViewUserByID()
        {
            Console.WriteLine("Enter User ID: ");
            Console.ForegroundColor = ConsoleColor.Red;
            int id = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();

            using (var context = new MyContext())
            {
                User user = context.User.FirstOrDefault(u => u.UserId == id);

                if (user != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"User ID: {user.UserId} \n Name: {user.Name} \n IsAdmin: {user.IsAdmin} \n IsActive: {user.IsActive}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("User not found.");
                    Console.ResetColor();
                }
            }

        }
        public void ViewAllUsers()
        {
            using (var context = new MyContext())
            {
                List<User> users = context.User.ToList();

                if (users.Any())
                {
                    Console.WriteLine("\nUser List:\n");
                    foreach (var user in users)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"User ID: {user.UserId} \n Name: {user.Name} \n IsAdmin: {user.IsAdmin} \n IsActive: {user.IsActive}");
                        Console.ResetColor();
                        Console.WriteLine("-------------------------------------------");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("No users found.");
                    Console.ResetColor();
                }
            }

        }
    }
}
