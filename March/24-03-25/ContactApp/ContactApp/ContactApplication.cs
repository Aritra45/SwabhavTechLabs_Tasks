using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Database;
using ContactApp.Interface;
using ContactApp.Model;
using ContactApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ContactApp
{
    internal class ContactApplication
    {
        I_UserService _userService = new UserService();
        I_ContactService _contactService = new ContactService();
        bool isActiveUser = true;
        public void TakeInput()
        {
            
            while (isActiveUser)
            {
                Console.Write("Enter User ID: ");
                Console.ForegroundColor = ConsoleColor.Red;
                int id = Convert.ToInt32(Console.ReadLine());
                Console.ResetColor();

                using (var context = new MyContext())
                {
                    User user = context.User.FirstOrDefault(u => u.UserId == id);


                    if (user.UserId == id)
                    {
                        if (user.IsActive)
                        {
                            if (user.IsAdmin)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine($"\nHello {user.Name}");
                                Console.WriteLine("Welcome to the Contacat App");
                                Console.ResetColor();
                                Console.WriteLine("***************************************");
                                ShowAdminMenu(id);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine($"\nHello {user.Name}");
                                Console.WriteLine("Welcome to the Contacat App");
                                Console.ResetColor();
                                Console.WriteLine("***************************************");
                                ShowStaffMenu(id);
                            }
                        }
                        else
                        {
                            Console.WriteLine("User is not Active");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid User ID.");
                    }
                }
            }
        }

        public void ShowAdminMenu(int userID)
        {
            bool continueAdmin = true;
            while (continueAdmin)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nAdmin Menu:");
                Console.ResetColor ();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Remove Users");
                Console.WriteLine("3. Update Users");
                Console.WriteLine("4. View User By ID");
                Console.WriteLine("5. View All User");
                Console.WriteLine("6. Exit");
                Console.ResetColor();
                Console.Write("\nEnter Your choice for Admin: ");
                Console.ForegroundColor = ConsoleColor.Red;
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.ResetColor();
                switch (choice)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Redirecting to Add User. . .\n");
                        Console.ResetColor();
                        _userService.AddUser();
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Redirecting to Remove User. . .\n");
                        Console.ResetColor();
                        _userService.RemoveUser(userID);
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Redirecting to Update User. . .\n");
                        Console.ResetColor();
                        _userService.UpdateUser();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Redirecting to View User by ID. . .\n");
                        Console.ResetColor();
                        _userService.ViewUserByID();
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Redirecting to View All User. . .\n");
                        Console.ResetColor();
                        _userService.ViewAllUser();
                        break;
                    case 6:
                        continueAdmin = false;
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("\nExiting the application . . .");
                        Console.ResetColor();
                        isActiveUser = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Invalid choice.");
                        Console.ResetColor();
                        break;
                }
            }
        }

        public void ShowStaffMenu(int userId)
        {
            bool continueStaff = true;
            while (continueStaff)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nStaff Menu:");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Create Contact");
                Console.WriteLine("2. Remove Contacts");
                Console.WriteLine("3. Update Contact");
                Console.WriteLine("4. View Contact By ID");
                Console.WriteLine("5. View All Contact");
                Console.WriteLine("6. Exit");
                Console.ResetColor();
                Console.Write("Enter Your choice for Staff: ");
                Console.ForegroundColor = ConsoleColor.Red;
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.ResetColor();
                switch (choice)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Redirecting to Add Contact. . .\n");
                        Console.ResetColor();
                        _contactService.AddContact(userId);
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Redirecting to Remove Contact. . .\n");
                        Console.ResetColor();
                        _contactService.RemoveContact();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Redirecting to Update Contact. . .\n");
                        Console.ResetColor();
                        _contactService.UpdateContact();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Redirecting to View Contact by ID. . .\n");
                        Console.ResetColor();
                        _contactService.ViewContactByID();
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Redirecting to View All Contact. . .\n");
                        Console.ResetColor();
                        _contactService.ViewAllContact();
                        break;
                    case 6:
                        continueStaff = false;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\nExiting the application . . .");
                        Console.ResetColor();
                        isActiveUser = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Invalid choice.");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}
