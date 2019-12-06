using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Task.DAL.Entities;

namespace Task.DAL.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }
        public DbSet<Player> Players { get; set; }
        public DbSet<Forecast> Forecasts { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasIndex(x => x.Phone)
                .IsUnique();
            
            

            //modelBuilder
            //    .Entity<Player>()
            //    .HasOne(u => u.Forecast)
            //    .WithOne(p => p.Player)
            //    .HasForeignKey<Forecast>(p => p.PlayerId);
        }
    }
}
