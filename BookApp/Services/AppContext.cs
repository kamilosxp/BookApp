using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BookApp.Models;
using Microsoft.EntityFrameworkCore;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BookApp.Services
{
    public sealed class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppContext()
        {
            //SQLitePCL.Batteries_V2.Init();
            this.Database.OpenConnection();
            this.Database.EnsureCreated();
            //this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseName = "database.db";
            string databasePath = String.Empty;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    SQLitePCL.Batteries_V2.Init();
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", databaseName); ;
                    break;
                case Device.Android:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), databaseName);
                    break;
                default:
                    throw new NotImplementedException("Platform not supported");
            }

            optionsBuilder
                .UseSqlite($"Filename={databasePath}");
        }
    }
}
