using AuthenticationForm.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace AuthenticationForm
{
    public class UserDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);

            var dbPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "mydb.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath};");
        }
    }
}
