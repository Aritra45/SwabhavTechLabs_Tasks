using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApp.Model
{
    internal class MovieDetails
    {
        public string Id { get; set; }
        public string MovieName { get; set; }
        public string YearOfRelease {  get; set; }
        public string Genre { get; set; }

        public MovieDetails(string movieId, string movieName, string yearOfRelease, string genre)
        {
            Id = movieId;
            MovieName = movieName;
            YearOfRelease = yearOfRelease;
            Genre = genre;
        }
    }
}
