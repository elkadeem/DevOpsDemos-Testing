using Microsoft.EntityFrameworkCore;

namespace CustomersWebapp.Models
{
    public class CustomersDbContext : DbContext
    {
        public CustomersDbContext(DbContextOptions<CustomersDbContext> contextOptions)
            :base(contextOptions)
        {

        }
        
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(builder =>
            {
                builder.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

                builder.Property(c => c.Email)
                     .HasMaxLength(100).IsRequired();

                builder.Property(c => c.Phone)
                     .HasMaxLength(15).IsRequired();

                builder.HasData(new Customer()
                {
                    ID = 1,
                    Name = "Wael Elkadim",
                    Email = "elkadim@email.com",
                    Phone = "01324213",
                    Department  = "Department",
                },
                new Customer()
                {
                    ID = 2,
                    Name = "Ahmed Mohamed",
                    Email = "amohamed@email.com",
                    Phone = "01322213",
                    Department = "Department",
                },
                new Customer()
                {
                    ID = 3,
                    Name = "Ali Mohamed",
                    Email = "alimohamed@email.com",
                    Phone = "01324223",
                    Department = "Department",
                });
            });
        }
    }
}
