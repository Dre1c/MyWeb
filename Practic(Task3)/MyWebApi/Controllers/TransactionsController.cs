using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Transaction> transactions = Context.Transactions.ToList();
            return Ok(transactions);
        }

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
        [HttpPost]
        public IActionResult Add(Transaction transactions)
        {
            Context.Transactions.Add(transactions);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Transaction transactions)
        {
            Context.Transactions.Update(transactions);
            Context.SaveChanges();
            return Ok(transactions);
        }
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
