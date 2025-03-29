using Microsoft.EntityFrameworkCore;
using MyFirstWwbApi.Model.Entity;

namespace MyFirstWwbApi.Data
{
    public class Mycontext : DbContext
    {
        public Mycontext(DbContextOptions options) : base(options) { }
        
        public DbSet<Employee> Employess { get; set; }
    }
}
