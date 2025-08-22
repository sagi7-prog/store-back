using Microsoft.AspNetCore.Mvc;
using Store.Business.Services.Interfaces;
using Store.Entities.DTOs;
using System.Collections.Generic;

namespace Store.Front.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("add")]
        public IActionResult AgregarArticulo([FromBody] CartDto dto)
        {

            try
            {
                var compras = _cartService.AgregarArticulo(dto);
                return Ok(compras);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("shopping/{clientId}")]
        public IActionResult Compras(int clientId)
        {
            var compras = _cartService.GetCompras(clientId);
            return Ok(compras);
        }

    }
}
