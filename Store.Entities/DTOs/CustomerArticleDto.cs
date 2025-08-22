using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Entities.DTOs
{
    public class CustomerArticleDto
    {

        public int ClienteId { get; set; }
        public int ArticuloId { get; set; }
        public string NombreArticulo { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }

    }
}
