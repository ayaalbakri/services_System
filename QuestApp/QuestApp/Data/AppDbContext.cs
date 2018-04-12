using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestApp.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<LU_Treatment> Treatments { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<LU_TimeSlot> TimeSlots { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Booking>()
                .HasOne(p => p.Treatment)
                .WithMany(b => b.Bookings)
                .HasForeignKey(p => p.treatmentId);
        }
    }

}

