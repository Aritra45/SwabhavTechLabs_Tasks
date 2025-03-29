using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ORMSample
{
    internal class MyContext : DbContext
    {
        string connectionString;
        public MyContext()
        {
            connectionString = "Data Source=DESKTOP-IN48U7N;Initial Catalog=ORMSample;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;";
        }

        public DbSet<Employee> Employess { get; set; }
        public DbSet<Depertment> DepertMent { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
