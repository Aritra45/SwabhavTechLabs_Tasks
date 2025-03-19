using System;
using System.Linq;
using MovieStoreApp.Model;

internal class Program
{
    public static MovieDetails[] details = new MovieDetails[5];
    public static int index = 0;

    public static void AddNewMovie()
    {
        if (index >= 5)
        {
            Console.WriteLine("Movie store is full. Can't add more movies.");
            return;
        }
        string id = "";
        bool isInvalid = true;
        while (isInvalid)
        {
            Console.Write("Enter Movie ID: ");
            id = Console.ReadLine();
            isInvalid = false;
            foreach (MovieDetails movie in details) { 
                if(movie !=null && movie.Id == id)
                {
                    Console.WriteLine("ID is already used. Give another ID.");
                    isInvalid = true;
                    break;
                }
            }
            
        }
        Console.Write("Enter Movie Name: ");
        string movieName = Console.ReadLine();
        Console.Write("Enter Movie Release Year: ");
        string yearOfRelease = Console.ReadLine();
        Console.Write("Enter Movie Genre: ");
        string genre = Console.ReadLine();

        details[index] = new MovieDetails(id, movieName, yearOfRelease, genre);
        index++;
        Console.WriteLine("Movie added successfully.");
    }

    public static void DisplayMovies()
    {
        if (index == 0)
        {
            Console.WriteLine("No movies to display.");
            return;
        }

        foreach (MovieDetails movie in details)
        {
            if (movie == null)
            {
                break;
            }
            else
            {
                Console.WriteLine($"Movie ID: {movie.Id}");
                Console.WriteLine($"Movie Name: {movie.MovieName}");
                Console.WriteLine($"Year of Release: {movie.YearOfRelease}");
                Console.WriteLine($"Genre: {movie.Genre}");
                Console.WriteLine();
            }
        }
    }

    public static void FindMovieByID()
    {
        Console.Write("Enter Movie ID: ");
        string id = Console.ReadLine();
        bool isValidMovieId = false;

        foreach (MovieDetails movie in details)
        {
            if (movie != null && movie.Id == id)
            {
                isValidMovieId = true;
                Console.WriteLine($"Movie ID: {movie.Id}");
                Console.WriteLine($"Movie Name: {movie.MovieName}");
                Console.WriteLine($"Year of Release: {movie.YearOfRelease}");
                Console.WriteLine($"Genre: {movie.Genre}");
                break;
            }
        }

        if (!isValidMovieId)
        {
            Console.WriteLine("Movie not found.");
        }

    }

    public static void RemoveMovieByID()
    {
        Console.Write("Enter Movie ID to remove: ");
        string id = Console.ReadLine();
        for (int i = 0; i < details.Length; i++)
        {
            if (details[i] != null && details[i].Id == id)
            {
                details[i] = null;
                for (int j = i; j < details.Length-1; j++)
                {
                    details[j] = details[j + 1];
                    details[j + 1] = null;
                }
                index--;
                Console.WriteLine("Movie removed successfully.");
                return;
            }
        }
        Console.WriteLine("Movie not found.");
    }

    public static void ClearAllMovies()
    {
        if (index == 0)
        {
            Console.WriteLine("Storage is already cleared.");
        }
        else
        {
            for (int i = 0; i < details.Length; i++)
            {
                details[i] = null;
            }
            index = 0;
            Console.WriteLine("All movies cleared.");
        }
    }

    private static void Main(string[] args)
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
                    AddNewMovie();
                    break;
                case "2":
                    DisplayMovies();
                    break;
                case "3":
                    FindMovieByID();
                    break;
                case "4":
                    RemoveMovieByID();
                    break;
                case "5":
                    ClearAllMovies();
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
