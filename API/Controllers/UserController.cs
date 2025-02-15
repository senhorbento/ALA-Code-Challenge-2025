using API.Models;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : BaseController<UserInsert, UserUpdate>
    {
        private readonly UserServices _services;
        private readonly TokenService _tokenService;

        public UserController(TokenService tokenService, UserServices services)
        {
            _tokenService = tokenService;
            _services = services;
        }

        // Endpoint de login
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(UserLogin login)
        {
            try
            {
                var response = _services.ValidateLogin(login);
                response.token = _tokenService.CreateToken(response.name, response.role);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        // Criar um novo usuário (apenas admin)
        [Authorize(Roles = "admin")]
        public override IActionResult Create(UserInsert obj)
        {
            try
            {
                int inserted = _services.Insert(obj);
                return inserted == 0 ? Problem("Object not inserted", obj.ToString()) : Created("Success", obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Listar todos os usuários (apenas admin)
        [Authorize(Roles = "admin")]
        public override IActionResult Read()
        {
            try
            {
                List<dynamic> users = _services.SelectAll();
                return users.Count == 0 ? NotFound() : Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Buscar usuário por ID (apenas admin)
        [Authorize(Roles = "admin")]
        public override IActionResult Read(long id)
        {
            try
            {
                if (id <= 0) return BadRequest("Invalid ID");

                dynamic user = _services.SelectById(id);
                return user == null ? NotFound() : Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Atualizar um usuário (apenas admin)
        [Authorize(Roles = "admin")]
        public override IActionResult UpdateById(UserUpdate obj)
        {
            try
            {
                dynamic updated = _services.Update(obj);
                return updated == 0 ? Problem($"Object {obj.id} not updated") : Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Deletar um usuário (apenas admin)
        [Authorize(Roles = "admin")]
        public override IActionResult DeleteById(long id)
        {
            try
            {
                dynamic deleted = _services.Delete(id);
                return deleted == 0 ? Problem($"Object {id} not deleted") : Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}