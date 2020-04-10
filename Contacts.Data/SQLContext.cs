using Contacts.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace Contacts.Data
{
    public class SQLContext : DbContext
    {
        public SQLContext() => Database.EnsureCreated();
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filename = "Contacts.db3";
            string pathDatabase = Path.Combine(directory, filename);

            if (!File.Exists(pathDatabase))
                File.Create(pathDatabase);

            optionsBuilder.UseSqlite($"Filename={pathDatabase}");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
