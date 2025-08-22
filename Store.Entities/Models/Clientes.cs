using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.Entities.Models
{
    public partial class Clientes
    {
        public Clientes()
        {
            ClientesArticulos = new HashSet<ClientesArticulos>();
        }

        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }

        // Login field
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public virtual ICollection<ClientesArticulos> ClientesArticulos { get; set; }
    }
}
