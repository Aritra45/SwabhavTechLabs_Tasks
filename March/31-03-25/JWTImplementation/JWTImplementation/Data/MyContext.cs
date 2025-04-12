using JWTImplementation.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace JWTImplementation.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}
