using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.ContractPortfolio;
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
        /// <summary>
        /// Получить все записи
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Asset> assets = Context.Assets.ToList();
            return Ok(assets);
        }
        /// <summary>
        /// Получить информацию о определенной записи
        /// </summary>
        /// <param name="id">Актив</param>
        /// <returns></returns>
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
        /// <summary>
        /// Добавить актив
        /// </summary>
        ///  <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///         "assetName" : "0",
        ///         "currency" : "sdf",
        ///         "assetType" : "0",
        ///         "theDate" : "2024-01-19T08:57:13.353Z", 
        ///         "addedTime": "2024-01-19T08:57:13.353Z",
        ///         "addedBy": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="request">актив</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(CreateAssetsRequest request)
        {
            var userDto = request.Adapt<Asset>();
            Context.Assets.Add(userDto);
            Context.SaveChanges();
            return Ok(userDto);
        }
        /// <summary>
        /// Редактировать запись
        /// </summary>
        ///  <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///         "assetName" : "0",
        ///         "currency" : "sdf",
        ///         "assetType" : "0",
        ///         "theDate" : "2024-01-19T08:57:13.353Z", 
        ///         "addedTime": "2024-01-19T08:57:13.353Z",
        ///         "addedBy": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="id">Актив</param>
        /// <param name="update">Актив</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(int id, [FromBody] UpdateAssetsRequest update)
        {
            var userDtos = Context.Assets.FirstOrDefault(u => u.AssetId == id);
            Context.Assets.Update(userDtos);
            Context.SaveChanges();
            return Ok(userDtos);
        }
        /// <summary>
        /// Удалить все записи 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
