namespace ПР49_Осокин.Models
{
    public class Dishes
    {
        /// <summary>
        /// Идентификатор блюда
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Категория
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Название блюда
        /// </summary>
        public string NameDish { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// Изображение
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// Версия
        /// </summary>
        public int Version { get; set; }
    }
}
