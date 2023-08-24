using System;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Web.Domain;

namespace Web.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<User>()
        //    .HasMany(e => e.Clients)
        //    .WithOne(e => e.User)
        //    .HasForeignKey(e => e.UserId);


        //modelBuilder.Entity<Client>()
        //   .HasOne(e => e.User)
        //   .WithMany(e => e.Clients)
        //   .HasForeignKey(e => e.UserId)
        //   .IsRequired();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Note> Notes { get; set; }

}