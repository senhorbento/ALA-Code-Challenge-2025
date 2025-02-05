using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public abstract class BaseController<TCreate, TUpdate> : ControllerBase
    {
        [HttpPost]
        public abstract IActionResult Create(TCreate obj);
        [HttpGet]
        public abstract IActionResult Read();
        [HttpGet("{id}")]
        public abstract IActionResult Read(long id);
        [HttpPut]
        public abstract IActionResult UpdateById(TUpdate obj);
        [HttpDelete("{id}")]
        public abstract IActionResult DeleteById(long id);
    }
}
