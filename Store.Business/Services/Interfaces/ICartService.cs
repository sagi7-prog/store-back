using Store.Entities.DTOs;
using Store.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Business.Services.Interfaces
{
    public interface ICartService
    {

        IEnumerable<ClientesArticulos> AgregarArticulo(CartDto dto);
        IEnumerable<CustomerArticleDto> GetCompras(int clientId);

    }
}
