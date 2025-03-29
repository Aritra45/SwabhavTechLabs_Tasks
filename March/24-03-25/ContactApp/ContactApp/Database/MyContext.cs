using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Database
{
    internal class MyContext : DbContext
    {
        string connectionString;
        public MyContext()
        {
            connectionString = "Data Source=DESKTOP-IN48U7N;Initial Catalog=ContactApp;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;";
        }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
