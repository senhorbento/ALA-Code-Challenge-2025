using API.Models;
using API.Repositories;

namespace API.Services
{
    public class PurchaseServices
    {
        private readonly PurchaseRepository _repository;
        public PurchaseServices()
        {
            _repository = new PurchaseRepository();
        }
        public dynamic Insert(PurchaseInsert obj)
        {
            if (obj.userID <= 0) throw new Exception("UserID can't be null");
            if (obj.total == -1) throw new Exception("Total can't be null");
            if (obj is null) throw new Exception("Object can't be null");
            return _repository.Insert(obj);
        }
        public dynamic Update(PurchaseUpdate obj)
        {
            if (obj.id <= 0) throw new Exception("Id can't be null");
            if (obj.userID <= 0) throw new Exception("UserID can't be null");
            if (obj.total == -1) throw new Exception("Total can't be null");
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