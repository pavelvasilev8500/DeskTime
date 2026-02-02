using DeskTime.Models.DataModels.Db;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection;

namespace DeskTime.Classes.Database
{
    internal class ApplicationContext : DbContext
    {
        private string _path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public DbSet<DbWeatherModel> Weather { get; set; } = null;

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
