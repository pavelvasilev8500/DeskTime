using DeskTime.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection;

namespace DeskTime.Classes.Database
{
    internal class ApplicationContext : DbContext
    {
        private string _path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //public DbSet<_12HWDBModel> _12HWeather { get; set; } = null;

        public ApplicationContext()
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_path}\\WeatherDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
