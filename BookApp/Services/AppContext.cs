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
    public sealed class BookAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Offer> Offers { get; set; }

        public BookAppContext()
        {
            //this.Database.OpenConnection();
            //this.Database.EnsureCreated();
            //this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseNpgsql("Host=localhost;Database=bookapp;User ID=postgres;Password=qwe123;port=5432");


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string databaseName = "db1.db";
        //    string databasePath;
        //    switch (Device.RuntimePlatform)
        //    {
        //        case Device.iOS:
        //            SQLitePCL.Batteries_V2.Init();

        //            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

        //            if (!Directory.Exists(libFolder))
        //            {
        //                Directory.CreateDirectory(libFolder);
        //            }

        //            databasePath = Path.Combine(libFolder, databaseName);
        //            break;
        //        case Device.Android:
        //            databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), databaseName);
        //            break;
        //        default:
        //            throw new NotImplementedException("Platform not supported");
        //    }

        //    if (!File.Exists(databasePath))
        //        File.Create(databasePath);

        //    // Specify that we will use sqlite and the path of the database here
        //    optionsBuilder.UseSqlite($"Filename={databasePath}");
        //}
    }
}
