using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Contracts;
using MyWebApi.Models;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketDataController : ControllerBase
    {

        public PracticContext Context { get; }
        public MarketDataController(PracticContext context)
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
            List<MarketDatum> marketData = Context.MarketData.ToList();
            return Ok(marketData);
        }
        /// <summary>
        /// Получить информацию о определенной записи
        /// </summary>
        /// <param name="id">Маркет</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            MarketDatum? marketData = Context.MarketData.Where(x => x.MarketId == id).FirstOrDefault();
            if (marketData == null)
            {
                return BadRequest("Not found");
            }
            return Ok(marketData);
        }

        /// <summary>
        /// Создание нового маркета
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///         "assetId" : 0,
        ///         "price" : 223,
        ///         "assetCreationDate" : "2024-01-19T08:57:13.353Z",
        ///         "addedTime": "2024-01-19T08:57:13.353Z",
        ///         "addedBy": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="marketData">Маркет</param>
        /// <returns></returns>

        // POST api/<MarketDataController>
        [HttpPost]
        public IActionResult Add(CreateMarketDataRequest request)
        {
            var userDto = request.Adapt<MarketDatum>();
            Context.MarketData.Add(userDto);
            Context.SaveChanges();
            return Ok(userDto);
        }
        /// <summary>
        /// Изменение записи
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///         "assetId" : 0,
        ///         "price" : 223,
        ///         "assetCreationDate" : "2024-01-19T08:57:13.353Z",
        ///         "addedTime": "2024-01-19T08:57:13.353Z",
        ///         "addedBy": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="marketData"></param>
        /// <returns></returns>

        // POST api/<MarketDataController>
        [HttpPut]
        public IActionResult Update(int id, [FromBody] UpdateMarketDataRequest update)
        {
            var userDtos = Context.MarketData.FirstOrDefault(u => u.MarketId == id);
            Context.MarketData.Update(userDtos);
            Context.SaveChanges();
            return Ok(userDtos);
        }
        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="id">Маркет</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            MarketDatum? marketData = Context.MarketData.Where(x => x.MarketId == id).FirstOrDefault();
            if (marketData == null)
            {
                return BadRequest("Not found");
            }
            Context.MarketData.Remove(marketData);
            Context.SaveChanges();
            return Ok();
        }
    }
}
