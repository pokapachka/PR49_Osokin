using System;

namespace ПР49_Осокин.Models
{
    public class Order
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Дата заказа
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Блюдо
        /// </summary>
        public int DishId { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public int Count { get; set; }
    }
}
