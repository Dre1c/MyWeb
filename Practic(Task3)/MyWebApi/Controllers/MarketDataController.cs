using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult GetAll()
        {
            List<MarketDatum> marketData = Context.MarketData.ToList();
            return Ok(marketData);
        }

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
        [HttpPost]
        public IActionResult Add(MarketDatum marketData)
        {
            Context.MarketData.Add(marketData);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(MarketDatum marketData)
        {
            Context.MarketData.Update(marketData);
            Context.SaveChanges();
            return Ok(marketData);
        }
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
