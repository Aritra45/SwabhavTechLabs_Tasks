using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStoreusingList_Exception;

namespace MovieStoreApp.Model
{
    internal class MovieDetails
    {
        
        public string MovieName { get; set; }
        public string YearOfRelease { get; set; }
        public GenreList Genre { get; set; }
        public string Id { get; }

        public MovieDetails(string movieName, string yearOfRelease, GenreList genre)
        { 
            MovieName = movieName;
            YearOfRelease = yearOfRelease;
            Genre = genre;
            Id = movieName.Substring(0, 1) + yearOfRelease.Substring(0, 1); //+genre.Substring(0, 1);
        }
    }
}
