using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Lot> lots = Context.Lots.ToList();
            return Ok(lots);
        }

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
        [HttpPost]
        public IActionResult Add(Lot lots)
        {
            Context.Lots.Add(lots);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Lot lots)
        {
            Context.Lots.Update(lots);
            Context.SaveChanges();
            return Ok(lots);
        }
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
