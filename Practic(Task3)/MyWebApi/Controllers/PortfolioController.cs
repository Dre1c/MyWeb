using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.ContractPortfolio;
using MyWebApi.Models;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        public PracticContext Context { get; }
        public PortfolioController(PracticContext context)
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
            List<Portfolio> portfolios = Context.Portfolios.ToList();
            return Ok(portfolios);
        }
        /// <summary>
        /// Получить информацию о определенной записи
        /// </summary>
        /// <param name="id">Портфель</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Portfolio? portfolios = Context.Portfolios.Where(x => x.PortfolioId == id).FirstOrDefault();
            if (portfolios == null)
            {
                return BadRequest("Not found");
            }
            return Ok(portfolios);
        }
        /// <summary>
        /// Создание нового портфеля
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
        /// <param name="request">Портфель</param>
        /// <returns></returns>

        // POST api/<PortfolioController>
        [HttpPost]
        public IActionResult Add(CreatePortfolioRequest request)
        {
            var userDto = request.Adapt<Portfolio>();
            Context.Portfolios.Add(userDto);
            Context.SaveChanges();
            return Ok(userDto);
        }
        /// <summary>
        /// Изменение данных о портфеле
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
        /// <param name="update">Портфель</param>
        /// <returns></returns>

        // POST api/<PortfolioController>
        [HttpPut]
        public IActionResult Update(int id, [FromBody] UpdatePortfolioRequest update)
        {
            var userDtos = Context.Portfolios.FirstOrDefault(u => u.PortfolioId == id);
            Context.Portfolios.Update(userDtos);
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
            Portfolio? portfolios = Context.Portfolios.Where(x => x.UsersId == id).FirstOrDefault();
            if (portfolios == null)
            {
                return BadRequest("Not found");
            }
            Context.Portfolios.Remove(portfolios);
            Context.SaveChanges();
            return Ok();
        }
    }
}
