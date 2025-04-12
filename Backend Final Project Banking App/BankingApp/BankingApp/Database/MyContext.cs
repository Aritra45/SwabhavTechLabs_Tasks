using BankingApp.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BankingApp.Database
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; }

    }
}
