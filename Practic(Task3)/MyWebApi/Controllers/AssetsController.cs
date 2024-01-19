using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        public PracticContext Context { get; }
        public AssetsController(PracticContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Asset> assets = Context.Assets.ToList();
            return Ok(assets);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Asset? assets = Context.Assets.Where(x => x.AssetId == id).FirstOrDefault();
            if (assets == null)
            {
                return BadRequest("Not found");
            }
            return Ok(assets);
        }
        [HttpPost]
        public IActionResult Add(Asset assets)
        {
            Context.Assets.Add(assets);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Asset assets)
        {
            Context.Assets.Update(assets);
            Context.SaveChanges();
            return Ok(assets);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Asset? assets = Context.Assets.Where(x => x.AssetId == id).FirstOrDefault();
            if (assets == null)
            {
                return BadRequest("Not found");
            }
            Context.Assets.Remove(assets);
            Context.SaveChanges();
            return Ok();
        }
    }
}
