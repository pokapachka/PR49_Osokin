using Microsoft.EntityFrameworkCore;
using ПР49_Осокин.Models;

namespace ПР49_Осокин.Context
{
    public class VersionsContext : DbContext
    {
        public DbSet<Versions> Versions { get; set; }
        /// <summary>
        /// Конструктор контекста
        /// </summary>
        public VersionsContext()
        {
            Database.EnsureCreated();
            Versions.Load();
        }
        /// <summary>
        /// Переопределяем метод конфигурации
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(Config.connection, Config.mySqlServerVersion);
    }
}
