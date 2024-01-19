using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerUsers : ControllerBase
    {
        public PracticContext Context { get;}
        public ControllerUsers(PracticContext context) 
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> users = Context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            User? user = Context.Users.Where(x => x.UsersId == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not found");
            }
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Add(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(User user)
        {
            Context.Users.Update(user);
            Context.SaveChanges();
            return Ok(user);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            User? user = Context.Users.Where(x =>x.UsersId == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not found");
            }
            Context.Users.Remove(user);
            Context.SaveChanges();
            return Ok();
        }
    }
}
