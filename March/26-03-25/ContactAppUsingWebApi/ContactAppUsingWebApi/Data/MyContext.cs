using ContactAppUsingWebApi.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace ContactAppUsingWebApi.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
    }
}
