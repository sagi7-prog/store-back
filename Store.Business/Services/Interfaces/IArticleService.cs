using Store.Entities.Models;
using System.Collections.Generic;

namespace Store.Business.Services.Interfaces
{
    public interface IArticleService
    {
        IEnumerable<Articulos> GetAll();
        Articulos GetById(int id);
        void Create(Articulos articulo);
        void Update(Articulos articulo);
        void Delete(int id);
    }
}
