using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ПР49_Осокин.Context;
using ПР49_Осокин.Models;

namespace ПР49_Осокин.Controllers
{
    [Route("api/OrderController")]
    [ApiExplorerSettings(GroupName = "v4")]
    public class OrderController : Controller
    {
        /// <summary>
        /// Получение списка блюд
        /// </summary>
        /// <param name="Version">Версия блюда</param>
        /// <remarks>Данный метод получает список блюд, находящийся в базе данных</remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="400">Проблемы при запросе</response>
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Dishes>), 200)]
        [ProducesResponseType(400)]
        public ActionResult List([FromQuery] int Version)
        {
            try
            {
                IEnumerable<Dishes> Dishes = new DishesContext().Dishes.Where(x => x.Version == Version);
                return Json(Dishes);
            }
            catch
            {
                return StatusCode(400);
            }
        }
    }
}
