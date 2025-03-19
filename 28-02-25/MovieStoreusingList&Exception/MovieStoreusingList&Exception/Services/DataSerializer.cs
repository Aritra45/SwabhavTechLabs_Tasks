using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MovieStoreApp.Model;

namespace MovieStoreusingList_Exception.Services
{
    internal class DataSerializer
    {
        public void Serializer(List<MovieDetails> moviesSerialize)
        {
            string fileName = "Movie.json";
            //List<MovieDetails> moviesSerialize = new List<MovieDetails>();
            //moviesSerialize.Add(movies);
            string jsonString = JsonSerializer.Serialize(moviesSerialize);
            File.WriteAllText(fileName, jsonString);
            //File.AppendAllText(fileName, jsonString);
            Console.WriteLine("Serializer Completed");
        }
        public List<MovieDetails> DeSerializer()
        {
            string fileName = "Movie.json";
            List<MovieDetails> moviesDeSerialize = new List<MovieDetails>();
            string jsonString;
            if (File.Exists(fileName))
            {
                jsonString = File.ReadAllText(fileName);
                moviesDeSerialize = JsonSerializer.Deserialize<List<MovieDetails>>(jsonString);
            }
            return moviesDeSerialize;

        }
    }
}
