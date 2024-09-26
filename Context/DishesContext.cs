using Microsoft.EntityFrameworkCore;
using ПР49_Осокин.Models;

namespace ПР49_Осокин.Context
{
    public class DishesContext : DbContext
    {
        public DbSet<Dishes> Dishes { get; set; }
        /// <summary>
        /// Конструктор контекста
        /// </summary>
        public DishesContext()
        {
            Database.EnsureCreated();
            Dishes.Load();
        }
        /// <summary>
        /// Переопределяем метод конфигурации
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(Config.connection, Config.mySqlServerVersion);
    }
}
