using DemoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.DataAccess
{
    public class DemoDataAccess : DbContext, IDataAccess
    {
        public DemoDataAccess(DbContextOptions<DemoDataAccess> options) : base(options) { }

        public DbSet<PersonModel> Persons { get; set; }
    }
}
