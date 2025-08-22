using Store.Business.Services.Interfaces;
using Store.Data.Repositories.Interfaces;
using Store.Entities.DTOs;
using Store.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Store.Business.Services
{
    public class CartService : ICartService
    {
        private readonly IGenericRepository<ClientesArticulos> _clientesArticulosRepo;
        private readonly IGenericRepository<Articulos> _articulosRepo;


        public CartService(IGenericRepository<ClientesArticulos> clientesArticulosRepo,
                           IGenericRepository<Articulos> articulosRepo)
        {
            _clientesArticulosRepo = clientesArticulosRepo;
            _articulosRepo = articulosRepo;

        }

        public IEnumerable<ClientesArticulos> AgregarArticulo(CartDto dto)
        {

            var articulo = _articulosRepo.GetById(dto.ArticuloId);
            if (articulo == null)
            {
                throw new KeyNotFoundException("Error agregando al carrito: el artículo no existe");
            }

            var compra = new ClientesArticulos
            {
                ClienteId = dto.ClienteId,
                ArticuloId = dto.ArticuloId,
                Fecha = DateTime.Now
            };

            _clientesArticulosRepo.Add(compra);

            // Returns all customer purchases
            return _clientesArticulosRepo.Find(ca => ca.ClienteId == dto.ClienteId).ToList();
        }

        public IEnumerable<CustomerArticleDto> GetCompras(int clientId)
        {

            var compras = _clientesArticulosRepo
                .Find(ca => ca.ClienteId == clientId)
                .ToList();

            // Map to DTO
            var result = compras.Select(ca =>
            {
                var articulo = _articulosRepo.GetById(ca.ArticuloId);
                return new CustomerArticleDto
                {
                    ClienteId = ca.ClienteId,
                    ArticuloId = ca.ArticuloId,
                    NombreArticulo = articulo?.Descripcion,
                    Precio = articulo?.Precio ?? 0,
                    Fecha = ca.Fecha
                };
            });

            return result;


        }


    }
}
