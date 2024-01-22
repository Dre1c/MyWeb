using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Contracts;
using MyWebApi.Models;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public PracticContext Context { get;}
        public UsersController(PracticContext context) 
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> users = Context.Users.ToList();
            return Ok(users);
        }
        /// <summary>
        /// Получить информацию о определенном пользователе
        /// </summary>
        /// <param name="id">Пользователь</param>
        /// <returns></returns>
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            User? user = Context.Users.Where(x => x.UsersId == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not found");
            }
            return Ok(user);
        }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///         "usersName": "Geroy",
        ///         "pasword": "qwerty",
        ///         "addedTime": "2024-01-19T08:57:13.353Z",
        ///         "addedBy": 0, 
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Пользователь</param>
        /// <returns></returns>

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Add(CreateUserRequest request)
        {
            var userDtos = request.Adapt<User>();
            Context.Users.Add(userDtos);
            Context.SaveChanges();
            return Ok(userDtos);
            
        }
        /// <summary>
        /// Изменение данных пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///        "usersName": "Geroy",
        ///         "pasword": "qwerty",
        ///         "addedTime": "2024-01-19T08:57:13.353Z",
        ///         "addedBy": 0, 
        ///     }
        ///
        /// </remarks>
        /// <param name="update">Пользователь</param>
        /// <returns></returns>

        // POST api/<UsersController>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateUserRequest update)
        {
            var user = Context.Users.FirstOrDefault(u => u.UsersId == id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            user = update.Adapt(user);
            Context.SaveChanges();
            return Ok("User updated successfully");
        }
        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <param name="id">Пользователь</param>
        /// <returns></returns>
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