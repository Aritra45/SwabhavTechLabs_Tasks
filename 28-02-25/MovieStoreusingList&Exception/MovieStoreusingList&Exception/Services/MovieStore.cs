using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStoreApp.Model;

namespace MovieStoreusingList_Exception.Services
{
    internal class MovieStore
    {
        MovieManager movieManager = new MovieManager();
        public void ShowMenu()
        {
            Console.Write("Enter Your Name: ");
            string nameOfAdmin = Console.ReadLine();
            Console.WriteLine($"Welcome to movie store developed by: {nameOfAdmin}");
            while (true)
            {
                Console.WriteLine("\n1. Add new Movie");
                Console.WriteLine("2. Display All Movies");
                Console.WriteLine("3. Find Movie by ID");
                Console.WriteLine("4. Remove Movie by ID");
                Console.WriteLine("5. Clear All Movies");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        movieManager.AddNewMovie();
                        break;
                    case "2":
                        movieManager.DisplayMovies();
                        break;
                    case "3":
                        movieManager.FindMovieByID();
                        break;
                    case "4":
                        movieManager.RemoveMovieByID();
                        break;
                    case "5":
                        movieManager.ClearAllMovies();
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
}
