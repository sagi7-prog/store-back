using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.Entities.Models
{
    public partial class Articulos
    {
        public Articulos()
        {
            ArticulosTiendas = new HashSet<ArticulosTiendas>();
            ClientesArticulos = new HashSet<ClientesArticulos>();
        }

        public int ArticuloId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }

        public virtual ICollection<ArticulosTiendas> ArticulosTiendas { get; set; }
        public virtual ICollection<ClientesArticulos> ClientesArticulos { get; set; }
    }
}
