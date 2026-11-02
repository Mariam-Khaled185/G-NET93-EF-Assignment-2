using EF_2.ConfigurationClasses;
using EF_2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_2.DBContext
{
    internal class EventHubContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Name=.;Database=EventHubDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrganizerProfileConfiguration());

            modelBuilder.Entity<Event>(e =>
            {
                e.HasKey(e => e.Id);

                e.Property(e => e.Title)
                      .IsRequired();

                e.Property(e => e.Description)
                      .IsRequired();

                e.HasOne(e => e.Organizer)
                      .WithMany(o => o.Events)
                      .HasForeignKey(e => e.OrganizerId);
            });

            modelBuilder.Entity<Badge>(b =>
            {
                b.HasKey(b => b.Id);

                b.Property(b => b.BadgeNumber)
                      .IsRequired();

                b.HasIndex(b => b.BadgeNumber)
                      .IsUnique();

                b.Property(b => b.Tier)
                      .HasConversion<string>();

                b.HasOne(b => b.Attendee)
                      .WithOne(a => a.Badge)
                      .HasForeignKey<Badge>(
                          b => b.AttendeeId);
            });

        }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<OrganizerProfile> organizerProfiles { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<Badge> badges { get; set; }
        public DbSet<Attendee> attendees { get; set; }
    }
}
