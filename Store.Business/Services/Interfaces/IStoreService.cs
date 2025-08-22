using Store.Entities.Models;
using System.Collections.Generic;

namespace Store.Business.Services.Interfaces
{
    public interface IStoreService
    {
        IEnumerable<Tiendas> GetAll();
        Tiendas GetById(int id);
        void Create(Tiendas tienda);
        void Update(Tiendas tienda);
        void Delete(int id);
    }
}
