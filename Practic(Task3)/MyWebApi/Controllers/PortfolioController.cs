using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Portfolio> portfolios = Context.Portfolios.ToList();
            return Ok(portfolios);
        }

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
        [HttpPost]
        public IActionResult Add(Portfolio portfolios)
        {
            Context.Portfolios.Add(portfolios);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Portfolio portfolios)
        {
            Context.Portfolios.Update(portfolios);
            Context.SaveChanges();
            return Ok(portfolios);
        }
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
