using API.Models;
using API.Repositories;

namespace API.Services
{
    public class ProductServices
    {
        private readonly ProductRepository _repository;
        public ProductServices()
        {
            _repository = new ProductRepository();
        }
        public dynamic Insert(ProductInsert obj)
        {
            if (string.IsNullOrEmpty(obj.name)) throw new Exception("Name can't be null");
            if (obj.price == -1) throw new Exception("Price can't be null");
            if (obj is null) throw new Exception("Object can't be null");
            return _repository.Insert(obj);
        }
        public dynamic Update(ProductUpdate obj)
        {
            if (obj.id <= 0) throw new Exception("Id can't be null");
            if (string.IsNullOrEmpty(obj.name)) throw new Exception("Name can't be null");
            if (obj.price == -1) throw new Exception("Price can't be null");
            if (obj is null) throw new Exception("Object can't be null");
            dynamic exists = _repository.SelectById(obj.id);
            int rows = 0;
            if (exists.id != -1) rows = _repository.UpdateById(obj);
            return rows;
        }
        public dynamic Delete(long id)
        {
            if (id <= 0) throw new Exception("Id can't be null");
            dynamic exists = _repository.SelectById(id);
            int rows = 0;
            if (exists.id != -1) rows = _repository.DeleteById(id);
            return rows;
        }
    }
}
