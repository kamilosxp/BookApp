using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BookApp.Models;
using Microsoft.EntityFrameworkCore;
using Xamarin.Essentials;

namespace BookApp.Services
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppContext()
        {
            SQLitePCL.Batteries_V2.Init();

            this.Database.EnsureCreated();

            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "database.db");

            optionsBuilder
                .UseSqlite($"Filename={dbPath}");
        }
    }
}
