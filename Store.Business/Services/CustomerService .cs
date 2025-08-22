using Store.Business.Services.Interfaces;
using Store.Data.Repositories.Interfaces;
using Store.Entities.Models;
using System.Collections.Generic;
using System.Linq;


namespace Store.Business.Services
{
    public class CustomerService : IcustomerService
    {

        private readonly IGenericRepository<Clientes> _clienteRepo;
        private readonly IGenericRepository<ClientesArticulos> _clientesArticulosRepo;

        public CustomerService(IGenericRepository<Clientes> clienteRepo,
                              IGenericRepository<ClientesArticulos> clientesArticulosRepo)
        {
            _clienteRepo = clienteRepo;
            _clientesArticulosRepo = clientesArticulosRepo;
        }

        public IEnumerable<Clientes> GetAll()
        {
            return _clienteRepo.GetAll()
                .Select(c =>
                {
                    c.ClientesArticulos = _clientesArticulosRepo
                        .Find(ca => ca.ClienteId == c.ClienteId)
                        .ToList();
                    return c;
                });
        }

        public Clientes GetById(int id)
        {
            var cliente = _clienteRepo.GetById(id);
            if (cliente != null)
            {
                cliente.ClientesArticulos = _clientesArticulosRepo
                    .Find(ca => ca.ClienteId == cliente.ClienteId)
                    .ToList();
            }
            return cliente;
        }

        public void Create(Clientes cliente)
        {
            // Here you hash the password before saving
            cliente.PasswordHash = BCrypt.Net.BCrypt.HashPassword(cliente.PasswordHash);

            _clienteRepo.Add(cliente);
        }

        public void Update(Clientes cliente)
        {
            cliente.PasswordHash = BCrypt.Net.BCrypt.HashPassword(cliente.PasswordHash);

            _clienteRepo.Update(cliente);
        }

        public void Delete(int id)
        {
            var cliente = _clienteRepo.GetById(id);
            if (cliente != null)
            {
                // Delete relationships first if necessary
                var relaciones = _clientesArticulosRepo.Find(ca => ca.ClienteId == id);
                foreach (var rel in relaciones)
                    _clientesArticulosRepo.Delete(rel);

                _clienteRepo.Delete(cliente);
            }
        }


    }
}
