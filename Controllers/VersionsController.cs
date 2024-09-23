using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ПР49_Осокин.Models;

namespace ПР49_Осокин.Controllers
{
    [Route("api/VersionsController")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class VersionsController : Controller
    {
        /// <summary>
        /// Получение списка версий
        /// </summary>
        /// <remarks>Данный метод получает список версий, находящийся в базе данных</remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="400">Проблемы при запросе</response>
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Versions>), 200)]
        [ProducesResponseType(400)]
        public ActionResult List()
        {
            try
            {
                IEnumerable<Versions> Versions = new VersionsContext().Versions;
                return Json(Versions);
            }
            catch
            {
                return StatusCode(400);
            }
        }
    }
}
