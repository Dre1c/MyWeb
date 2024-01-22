using Azure.Core;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Contracts;
using MyWebApi.ContractTransactions;
using MyWebApi.Models;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        public PracticContext Context { get; }
        public TransactionsController(PracticContext context)
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
            List<Transaction> transactions = Context.Transactions.ToList();
            return Ok(transactions);
        }

        /// <summary>
        /// Получить информацию о определенной транзакции
        /// </summary>
        /// <param name="id">Транзакция</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Transaction? transactions = Context.Transactions.Where(x => x.TransactionsId == id).FirstOrDefault();
            if (transactions == null)
            {
                return BadRequest("Not found");
            }
            return Ok(transactions);
        }
        /// <summary>
        /// Создание новой транзакции
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///         "portfolioId" : "0",
        ///         "userId" : "0",
        ///         "assetId" : "0",
        ///         "price" : 3500,
        ///         "theDate" : "2024-01-19T08:57:13.353Z",
        ///         "addedTime": "2024-01-19T08:57:13.353Z",
        ///         "addedBy": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Транзакция</param>
        /// <returns></returns>

        // POST api/<TransactionsController>
        [HttpPost]
        public IActionResult Add(CreateTransactionsRequest request)
        {
            var userDtos = request.Adapt<Transaction>();
            Context.Transactions.Add(userDtos);
            Context.SaveChanges();
            return Ok(userDtos);
        }
        /// <summary>
        /// Изменение данных транзакции
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///         "portfolioId" : "0",
        ///         "userId" : "0",
        ///         "assetId" : "0",
        ///         "price" : 3500,
        ///         "theDate" : "2024-01-19T08:57:13.353Z",
        ///         "addedTime": "2024-01-19T08:57:13.353Z",
        ///         "addedBy": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="id">ID транзакции</param>
        /// <param name="update">Транзакция</param>
        /// <returns></returns>

        // POST api/<TransactionsController>
        [HttpPut]
        public IActionResult Update(int id, [FromBody] UpdateTransactionsRequest update)
        {
            var userDtos = Context.Transactions.FirstOrDefault(u => u.TransactionsId == id);
            Context.Transactions.Update(userDtos);
            Context.SaveChanges();
            return Ok(userDtos);
        }
       /// <summary>
       /// Удаление записи
       /// </summary>
       /// <param name="id">Транзакция</param>
       /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Transaction? transactions = Context.Transactions.Where(x => x.AssetId == id).FirstOrDefault();
            if (transactions == null)
            {
                return BadRequest("Not found");
            }
            Context.Transactions.Remove(transactions);
            Context.SaveChanges();
            return Ok();
        }
    }
}
