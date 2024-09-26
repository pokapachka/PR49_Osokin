using Microsoft.EntityFrameworkCore;
using ПР49_Осокин.Models;

namespace ПР49_Осокин.Context
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Order { get; set; }
        /// <summary>
        /// Конструктор контекста
        /// </summary>
        public OrderContext()
        {
            Database.EnsureCreated();
            Order.Load();
        }
        /// <summary>
        /// Переопределяем метод конфигурации
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(Config.connection, Config.mySqlServerVersion);
    }
}
