using Microsoft.EntityFrameworkCore;
using OrderApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAPI.Data.Database
{
    public class OrderContext:DbContext
    {
        public OrderContext()
        {
        }

        public OrderContext(DbContextOptions<OrderContext> options):base(options)
        {
            
        }

        public virtual DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Order>(entity => {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.CustomerFullName).IsRequired();
            });
        }
    }
}
