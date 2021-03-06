using Final.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final.Infrastructure.Data
{
    public class FinalDbContext : DbContext
    {
        public FinalDbContext(DbContextOptions<FinalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(ConfigureClient);
            modelBuilder.Entity<Employee>(ConfigureEmployee);
            modelBuilder.Entity<Interaction>(ConfigureInteraction);



        }
        private void ConfigureInteraction(EntityTypeBuilder<Interaction> builder)
        {
            builder.ToTable("Interaction");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.InType).HasMaxLength(1);

            builder.Property(p => p.Remarks).HasMaxLength(500);
            builder.HasIndex(p => new { p.ClientId, p.EmployeeId }).IsUnique();
        }
        private void ConfigureClient(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(50);
            builder.Property(p => p.Phones).HasMaxLength(30);
            builder.Property(p => p.Address).HasMaxLength(100);
            
        }

        private void ConfigureEmployee(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(50);
            builder.Property(p => p.Password).HasMaxLength(10);
            builder.Property(p => p.Designation).HasMaxLength(50);
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees{ get; set; }
        public DbSet<Interaction> Interactions { get; set; }
    }
}
