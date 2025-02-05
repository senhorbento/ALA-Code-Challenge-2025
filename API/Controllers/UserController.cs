using API.Models;
using API.Repositories;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : BaseController<UserInsert, UserUpdate>
    {
        private readonly UserRepository _repository;
        private readonly TokenService _tokenService;

        public UserController(TokenService tokenService)
        {
            _tokenService = tokenService;
            _repository = new UserRepository();
        }
        public override IActionResult Create(UserInsert obj)
        {
            throw new NotImplementedException();
        }

        public override IActionResult DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public override IActionResult Read()
        {
            throw new NotImplementedException();
        }

        public override IActionResult Read(long id)
        {
            throw new NotImplementedException();
        }
        public override IActionResult UpdateById(UserUpdate obj)
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Validate(UserUpdate obj)
        {
            try
            {
                UserLoginResponse user = new()
                {
                    role = "user",
                    name = obj.name,
                    token = _tokenService.CreateToken(obj.name),
                };
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
