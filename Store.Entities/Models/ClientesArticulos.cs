using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.Entities.Models
{
    public partial class ClientesArticulos
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ArticuloId { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Articulos Articulo { get; set; }
        public virtual Clientes Cliente { get; set; }
    }
}
