using CoxinhaSystem.Domain.Models;
using Microsoft.Data.Entity;
using System.Configuration;

namespace CoxinhaSystem.Infra.Data.Context
{
    // install-package entityframework.microsoftsqlserver -pre
    // install-package entityframework.commands -pre
    public class CoxinhaContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Add Reference... Assemblies... System.Configuration
            string connectionString = ConfigurationManager.ConnectionStrings["coxinhaSystemConnectionString"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurações adicionais
            modelBuilder.Entity<Customer>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(x => x.Name).IsUnique();

            base.OnModelCreating(modelBuilder);            
        }        
    }
}