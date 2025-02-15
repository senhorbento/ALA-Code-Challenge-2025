using API.Models;
using API.Repositories;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PurchaseController : BaseController<PurchaseInsert, PurchaseUpdate>
    {
        private readonly PurchaseServices _services;
        private readonly PurchaseRepository _repository;

        public PurchaseController()
        {
            _repository = new PurchaseRepository();
            _services = new PurchaseServices();
        }
        public override IActionResult Create(PurchaseInsert obj)
        {
            try
            {
                int inserted = _services.Insert(obj);
                return inserted == 0 ? Problem("Object not inserted", obj.ToString()) : Created("Sucess", obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        public override IActionResult Read()
        {
            try
            {
                List<dynamic> i = _repository.SelectAll();
                return i.Count == 0 ? NotFound() : Ok(i);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

        
        public override IActionResult Read(long id)
        {
            try
            {
                if(id <= 0) return BadRequest();
                dynamic i = _repository.SelectById(id);
                return i == null ? NotFound() : Ok(i);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public override IActionResult UpdateById(PurchaseUpdate obj)
        {
            try
            {
                dynamic i = _services.Update(obj);
                return i == 0 ? Problem($"Object {obj.id} not updated, {i} rows affected") : Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public override IActionResult DeleteById(long id)
        {
            try
            {
                dynamic i = _services.Delete(id);
                return i == 0 ? Problem($"Object {id} not updated, {i} rows affected") : Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}