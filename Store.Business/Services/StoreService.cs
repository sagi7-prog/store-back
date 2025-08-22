using Store.Business.Services.Interfaces;
using Store.Data.Repositories.Interfaces;
using Store.Entities.Models;
using System.Collections.Generic;

namespace Store.Business.Services
{
    public class StoreService : IStoreService
    {

        private readonly IGenericRepository<Tiendas> _tiendaRepo;

        public StoreService(IGenericRepository<Tiendas> tiendaRepo)
        {
            _tiendaRepo = tiendaRepo;
        }


        public IEnumerable<Tiendas> GetAll() => _tiendaRepo.GetAll();

        public Tiendas GetById(int id) => _tiendaRepo.GetById(id);

        public void Create(Tiendas tienda) => _tiendaRepo.Add(tienda);

        public void Update(Tiendas tienda) => _tiendaRepo.Update(tienda);

        public void Delete(int id)
        {
            var tienda = _tiendaRepo.GetById(id);
            if (tienda != null)
                _tiendaRepo.Delete(tienda);
        }
    }
}
