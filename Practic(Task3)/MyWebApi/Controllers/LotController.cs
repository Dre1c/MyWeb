using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.ContractPortfolio;
using MyWebApi.Models;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotController : ControllerBase
    {
        public PracticContext Context { get; }
        public LotController(PracticContext context)
        {
            Context = context;
        }
        /// <summary>
        /// Получить все записи
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Lot> lots = Context.Lots.ToList();
            return Ok(lots);
        }
        /// <summary>
        /// Получить информацию о определенной записи
        /// </summary>
        /// <param name="id">Лот</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Lot? lots = Context.Lots.Where(x => x.LotId == id).FirstOrDefault();
            if (lots == null)
            {
                return BadRequest("Not found");
            }
            return Ok(lots);
        }
        /// <summary>
        /// Создание нового лота
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///         "usersId" : "0",
        ///         "portfolioName" : "sdf",
        ///         "balance" : "0",
        ///         "addedTime": "2024-01-19T08:57:13.353Z",
        ///         "addedBy": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="request">лот</param>
        /// <returns></returns>

        // POST api/<LotController>
        [HttpPost]
        public IActionResult Add(CreateLotRequest request)
        {
            var userDto = request.Adapt<Lot>();
            Context.Lots.Add(userDto);
            Context.SaveChanges();
            return Ok(userDto);
        }
        /// <summary>
        /// Редактирование лота
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///         "usersId" : "0",
        ///         "portfolioName" : "sdf",
        ///         "balance" : "0",
        ///         "addedTime": "2024-01-19T08:57:13.353Z",
        ///         "addedBy": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="update">Лот</param>
        /// <returns></returns>

        // POST api/<LotController>
        [HttpPut]
        public IActionResult Update(int id, [FromBody]UpdateLotRequest update)
        {
            var userDtos = Context.Lots.FirstOrDefault(u => u.LotId == id);
            Context.Lots.Update(userDtos);
            Context.SaveChanges();
            return Ok(userDtos);
        }
        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Lot? lots = Context.Lots.Where(x => x.LotId == id).FirstOrDefault();
            if (lots == null)
            {
                return BadRequest("Not found");
            }
            Context.Lots.Remove(lots);
            Context.SaveChanges();
            return Ok();
        }
    }
}
