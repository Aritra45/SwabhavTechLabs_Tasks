using DemoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.DataAccess
{
    public interface IDataAccess
    {
        DbSet<PersonModel> Persons { get; set; }
    }
}