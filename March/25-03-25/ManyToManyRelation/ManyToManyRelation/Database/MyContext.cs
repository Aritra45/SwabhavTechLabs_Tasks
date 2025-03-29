using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManyToManyRelation.Model;
using Microsoft.EntityFrameworkCore;

namespace ManyToManyRelation.Database
{
    internal class MyContext : DbContext
    {
        string connectionString;
        public MyContext()
        {
            connectionString = "Data Source=DESKTOP-IN48U7N;Initial Catalog=ManyToMany;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;";
        }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
