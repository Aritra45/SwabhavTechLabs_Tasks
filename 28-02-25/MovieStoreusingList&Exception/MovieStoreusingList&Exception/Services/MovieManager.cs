using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStoreApp.Exceptions;
using MovieStoreApp.Model;
using MovieStoreusingList_Exception.Exceptions;

namespace MovieStoreusingList_Exception.Services
{
    internal class MovieManager
    {
        DataSerializer serializer;
        public List<MovieDetails> movies;
        public MovieManager() {
            movies = new List<MovieDetails>();
            serializer = new DataSerializer();
            movies = serializer.DeSerializer();
        }

        public void AddNewMovie()
        {
            try
            {
                if (movies.Count >= 5)
                {
                    throw new ListFullException("Movie store is full. Can't add more movies.");
                }
                Console.Write("Enter Movie Name: ");
                string movieName = Console.ReadLine();
                Console.Write("Enter Movie Release Year: ");
                string yearOfRelease = Console.ReadLine();
                Console.Write("Select Movie Genre Number According The List: \n");
                int i = 1;
                foreach (var genres in Enum.GetValues(typeof(GenreList)).Cast<GenreList>())
                {
                    Console.WriteLine($"{i} {genres}");
                    i++;
                }
                int genreNumber = Convert.ToInt32(Console.ReadLine());
                var genre = (GenreList)genreNumber;
                MovieDetails newmovies = new MovieDetails(movieName, yearOfRelease, genre);
                movies.Add(newmovies);
                serializer.Serializer(movies);
                Console.WriteLine("Movie added successfully.");
                
            }
            catch (Exception e) { 
                Console.WriteLine(e.ToString());
            }
        }

        public void DisplayMovies()
        {
            try
            {
                if (movies.Count == 0)
                {
                    throw new ListEmptyException("No movies to display.");
                }

                foreach (MovieDetails movie in movies)
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
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void FindMovieByID()
        {
            try
            {
                Console.Write("Enter Movie ID: ");
                string id = Console.ReadLine();
                bool isValidMovieId = false;

                foreach (MovieDetails movie in movies)
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
                    throw new MovieNotFoundException("Movie not found.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public void RemoveMovieByID()
        {
            try
            {
                Console.Write("Enter Movie ID to remove: ");
                string id = Console.ReadLine();
                for (int i = 0; i < movies.Count; i++)
                {
                    if (movies[i].Id == id)
                    {
                        movies.RemoveAt(i);
                        Console.WriteLine("Movie removed successfully.");
                        return;
                    }
                }
                throw new MovieNotFoundException("Movie not found.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void ClearAllMovies()
        {
            try
            {
                if (movies.Count == 0)
                {
                    throw new StorageClearedException("Storage is already cleared.");
                }
                else
                {
                    movies.Clear();
                    Console.WriteLine("All movies cleared.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}
