using Microsoft.EntityFrameworkCore;

namespace CURDUSingAPIEFCore.Models
{
    public class CompanyContext:DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Product>().HasData(
                new Product() { 
                 ProductID=121,
                 ProductName="Laptop",
                 MfgName="Dell",
                 Price= 89000
                },
                new Product()
                {
                    ProductID = 122,
                    ProductName = "Mouse",
                    MfgName = "Logitech",
                    Price = 91000
                },
                new Product()
                {
                    ProductID = 123,
                    ProductName = "Monitor",
                    MfgName = "LG",
                    Price = 12000
                }
               );
        }
        public DbSet<Product> Products { get; set; }
    }
}
