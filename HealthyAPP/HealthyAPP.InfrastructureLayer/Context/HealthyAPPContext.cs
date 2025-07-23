using HealthyAPP.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyAPP.InfrastructureLayer.Context
{
    public  class HealthyAPPContext : DbContext
    {
        public HealthyAPPContext(DbContextOptions options)
           : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Routine> Routines { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<HealthLog> HealthLogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User - Routine (1 - many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Routines)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.User_id)
                .OnDelete(DeleteBehavior.Cascade);

            // User - MealPlan (1 - many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.MealPlans)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.User_id)
                .OnDelete(DeleteBehavior.Cascade);

            // User - HealthLog (1 - many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.HealthLogs)
                .WithOne(h => h.User)
                .HasForeignKey(h => h.User_id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
