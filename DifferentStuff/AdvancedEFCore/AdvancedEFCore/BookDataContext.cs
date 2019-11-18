using AdvancedEfCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace AdvancedEFCore
{
    public class BookDataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);

           var dbPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "mydb.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath};");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookID, ba.AuthorID });

            modelBuilder.Entity<Book>()
                .HasIndex(b => b.ISBN)
                .IsUnique();

            modelBuilder.Entity<Genre>()
                .HasIndex(g => g.GenreTitle)
                .IsUnique();

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Authors)
                .WithOne(ba => ba.Book);

            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(ba => ba.Author);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
    }
}
