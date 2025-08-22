using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.Entities.Models
{
    public partial class ArticulosTiendas
    {
        public int Id { get; set; }
        public int ArticuloId { get; set; }
        public int TiendaId { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Articulos Articulo { get; set; }
        public virtual Tiendas Tienda { get; set; }
    }
}
