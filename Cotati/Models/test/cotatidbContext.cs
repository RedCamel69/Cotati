using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cotati.Models.test
{
    public partial class cotatidbContext : DbContext
    {
        public virtual DbSet<Employee> Employee { get; set; }

        public cotatidbContext(DbContextOptions<cotatidbContext> options)
    : base(options)
{ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer(@"Server=NUMPTY\SQLEXPRESS;Database=cotatidb;Trusted_Connection=True;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnType("nchar(10)");
            });
        }
    }
}
