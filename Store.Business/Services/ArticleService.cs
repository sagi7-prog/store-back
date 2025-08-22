using Store.Business.Services.Interfaces;
using Store.Data.Repositories.Interfaces;
using Store.Entities.Models;
using System.Collections.Generic;
using System.Linq;


namespace Store.Business.Services
{
    public class ArticleService: IArticleService
    {
        private readonly IGenericRepository<Articulos> _articuloRepo;
        private readonly IGenericRepository<ArticulosTiendas> _articulosTiendasRepo;
        private readonly IGenericRepository<ClientesArticulos> _clientesArticulosRepo;


        public ArticleService(IGenericRepository<Articulos> articuloRepo,
                              IGenericRepository<ArticulosTiendas> articulosTiendasRepo,
                              IGenericRepository<ClientesArticulos> clientesArticulosRepo)
        {
            _articuloRepo = articuloRepo;
            _articulosTiendasRepo = articulosTiendasRepo;
            _clientesArticulosRepo = clientesArticulosRepo;
        }

        public IEnumerable<Articulos> GetAll()
        {
            return _articuloRepo.GetAll()
                .Select(a =>
                {
                    a.ArticulosTiendas = _articulosTiendasRepo
                        .Find(at => at.ArticuloId == a.ArticuloId)
                        .ToList();
                    return a;
                });
        }

        public Articulos GetById(int id)
        {
            var articulo = _articuloRepo.GetById(id);
            if (articulo != null)
            {
                articulo.ArticulosTiendas = _articulosTiendasRepo
                    .Find(at => at.ArticuloId == articulo.ArticuloId)
                    .ToList();
            }
            return articulo;
        }

        public void Create(Articulos articulo)
        {
            _articuloRepo.Add(articulo);
        }

        public void Update(Articulos articulo)
        {
            _articuloRepo.Update(articulo);
        }

        public void Delete(int id)
        {
            var articulo = _articuloRepo.GetById(id);
            if (articulo != null)
            {
                // Delete relationships with ArticleStores
                var relacionesTiendas = _articulosTiendasRepo.Find(at => at.ArticuloId == id);
                foreach (var rel in relacionesTiendas)
                    _articulosTiendasRepo.Delete(rel);

                // Delete relationships with ClientsArticles
                var relacionesClientes = _clientesArticulosRepo.Find(ca => ca.ArticuloId == id);
                foreach (var rel in relacionesClientes)
                    _clientesArticulosRepo.Delete(rel);

                _articuloRepo.Delete(articulo);
            }
        }

    }
}
