using Microsoft.AspNetCore.Mvc;
using Store.Business.Services.Interfaces;
using Store.Entities.Models;

namespace Store.Front.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly IcustomerService _service;

        public CustomersController(IcustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_service.GetById(id));

        [HttpPost]
        public IActionResult Post([FromBody] Clientes cliente)
        {
            _service.Create(cliente);
            return Ok(cliente);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Clientes cliente)
        {
            _service.Update(cliente);
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }

    }
}
