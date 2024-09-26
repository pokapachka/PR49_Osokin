using Microsoft.EntityFrameworkCore;
using ПР49_Осокин.Models;

namespace ПР49_Осокин.Context
{
    public class UsersContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        /// <summary>
        /// Конструктор контекста
        /// </summary>
        public UsersContext()
        {
            Database.EnsureCreated();
            Users.Load();
        }
        /// <summary>
        /// Переопределяем метод конфигурации
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(Config.connection, Config.mySqlServerVersion);
    }
}
