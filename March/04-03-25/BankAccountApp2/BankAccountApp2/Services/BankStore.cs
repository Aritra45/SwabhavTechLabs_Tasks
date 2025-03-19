using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using AccountLibrary.Services;
using AccountLibrary.Model;
using AccountLibrary.Exceptions;

namespace BankAccountApp2.Services;

internal class BankStore
{
    BankManager bankManager = new BankManager();
    public void ShowMenu()
    {
        Console.Write("Enter Your Name: ");
        string nameOfAdmin = Console.ReadLine();
        Console.WriteLine($"Welcome to Bank store Managed by: {nameOfAdmin}");
        while (true)
        {
            Console.WriteLine("\n1. Add new bank account");
            Console.WriteLine("2. Display All bank accounts");
            Console.WriteLine("3. Remove Account by Account Number");
            Console.WriteLine("4. Find Account by Account Number");
            Console.WriteLine("5. Clear All Bank Accounts");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    bankManager.AddBankAccount();
                    break;
                case "2":
                    bankManager.DisplayAllAccount();
                    break;
                case "3":
                    bankManager.RemoveAccountByAccountNumber();
                    break;
                case "4":
                    bankManager.FindAccountByAccountNumber();
                    break;
                case "5":
                    bankManager.ClearAllAccount();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
