using CustomerApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApi.Data.Database
{
    public class CustomerContext:DbContext
    {
        public CustomerContext()
        {

        }
        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion","2.2.6-servicing-10079");

            modelBuilder.Entity<Customer>(entity => {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.BirthDay).HasColumnType("date");
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
            });
        }
    }
}
