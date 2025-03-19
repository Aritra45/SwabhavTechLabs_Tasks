using System;
using System.Linq;
using MovieStoreApp.Model;
using MovieStoreusingList_Exception.Services;

internal class Program
{
    

    

    private static void Main(string[] args)
    {
        MovieStore movieStore = new MovieStore();
        movieStore.ShowMenu();
    }
}
