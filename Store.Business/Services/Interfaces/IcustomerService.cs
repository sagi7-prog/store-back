using Store.Entities.Models;
using System.Collections.Generic;

namespace Store.Business.Services.Interfaces
{
    public interface IcustomerService
    {
        IEnumerable<Clientes> GetAll();
        Clientes GetById(int id);
        void Create(Clientes cliente);
        void Update(Clientes cliente);
        void Delete(int id);
    }
}
