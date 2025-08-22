using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.Entities.Models
{
    public partial class Tiendas
    {
        public Tiendas()
        {
            ArticulosTiendas = new HashSet<ArticulosTiendas>();
        }

        public int TiendaId { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<ArticulosTiendas> ArticulosTiendas { get; set; }
    }
}
