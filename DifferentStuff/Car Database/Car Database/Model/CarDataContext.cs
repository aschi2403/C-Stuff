using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Car_Database.Model
{
    public class CarDataContext: DbContext
    {
        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Ownership> Ownerships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);

            var dbPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "mydb.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath};");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure unique VehicleIdentificationNumber
            //modelBuilder.Entity<Ownership>()
              //  .HasAlternateKey(o => o.VehicleIdentificationNumber);

            modelBuilder.Entity<Ownership>()
                .HasKey(o => new { o.CarModelId, o.PersonId });

            modelBuilder.Entity<CarModel>()
                .HasMany(c => c.Ownerships)
                .WithOne(c => c.CarModel);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Ownerships)
                .WithOne(p => p.Person);

            
        }
    }
}
