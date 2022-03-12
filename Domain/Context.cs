using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Context:DbContext
    {
        public DbSet<Grad> Gradovi { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Klijent> Klijenti { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=TuristickaAgencija;
            Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasBaseType<User>().ToTable("Admins");
            modelBuilder.Entity<Klijent>().HasBaseType<User>().ToTable("Klijenti");

            modelBuilder.Entity<Rezervacija>().HasKey(r => new { r.GradId, r.UserId, r.RezervacijaId });

            modelBuilder.Entity<Rezervacija>().HasOne(r => r.Grad).WithMany(g => g.Rezervacije).HasForeignKey(r => r.GradId);
            modelBuilder.Entity<Rezervacija>().HasOne(r => r.User).WithMany(u => u.Rezervacije).HasForeignKey(r => r.UserId);
        }
    }
}
