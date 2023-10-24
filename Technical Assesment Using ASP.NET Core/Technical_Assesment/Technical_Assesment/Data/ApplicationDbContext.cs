
using EmployeeManagement.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using Technical_Assesment.Model;

namespace Technical_Assesment.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Inventories>()
              .HasIndex(inv => inv.BillNo)
                .IsUnique();
        }
        public DbSet<User> Users { get; set; }
       public DbSet<Customers> Customers { get; set; }
       public DbSet<Products> Products { get; set; }
       public DbSet<Inventories> Inventories { get; set; }
       public DbSet<InventoryProduct> InventoryProduct { get; set; }

    }
}
