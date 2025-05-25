using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDEMNet.Models;

namespace TestDEMNet.Context
{
    public class ApplicationContext : DbContext
    {
        public static ApplicationContext Instance { get; } = new();

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Partner> Partners { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TestDEMNet;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
