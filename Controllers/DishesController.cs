using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ПР49_Осокин.Models;
using ПР49_Осокин.Context;
using System.Linq;

namespace ПР49_Осокин.Controllers
{
    [Route("api/DishesController")]
    [ApiExplorerSettings(GroupName = "v3")]
    public class DishesController : Controller
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
