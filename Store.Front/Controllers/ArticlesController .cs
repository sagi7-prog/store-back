using Microsoft.AspNetCore.Mvc;
using Store.Business.Services.Interfaces;
using Store.Entities.Models;

namespace Store.Front.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _service;

        public ArticlesController(IArticleService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_service.GetById(id));

        [HttpPost]
        public IActionResult Post([FromBody] Articulos articulos)
        {
            _service.Create(articulos);
            return Ok(articulos);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Articulos articulos)
        {
            _service.Update(articulos);
            return Ok(articulos);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
