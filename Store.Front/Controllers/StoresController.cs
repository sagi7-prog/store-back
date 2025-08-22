using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Business.Services.Interfaces;
using Store.Entities.Models;

namespace Store.Front.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {

        private readonly IStoreService _service;

        public StoresController(IStoreService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_service.GetById(id));

        [HttpPost]
        public IActionResult Post([FromBody] Tiendas tiendas)
        {
            _service.Create(tiendas);
            return Ok(tiendas);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Tiendas tienda)
        {
            _service.Update(tienda);
            return Ok(tienda);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }


    }
}
