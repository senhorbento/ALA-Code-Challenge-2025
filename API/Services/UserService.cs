using API.Models;
using API.Repositories;

namespace API.Services
{
    public class UserServices
    {
        private readonly UserRepository _repository;

        public UserServices()
        {
            _repository = new UserRepository();
        }

        // Inserir um novo usuário
        public dynamic Insert(UserInsert obj)
        {
            if (string.IsNullOrEmpty(obj.email)) throw new Exception("Email can't be null");
            if (string.IsNullOrEmpty(obj.name)) throw new Exception("Name can't be null");
            if (string.IsNullOrEmpty(obj.password)) throw new Exception("Password can't be null");
            if (obj is null) throw new Exception("Object can't be null");

            // Verifica se o email já está cadastrado
            var existingUser = _repository.GetByEmail(obj.email);
            if (existingUser != null) throw new Exception("Email already registered");

            // Insere o usuário sem hash de senha
            return _repository.Insert(obj);
        }

        public dynamic Update(UserUpdate obj)
        {
            if (obj.id <= 0) throw new Exception("Id can't be null");
            if (string.IsNullOrEmpty(obj.email)) throw new Exception("Email can't be null");
            if (string.IsNullOrEmpty(obj.name)) throw new Exception("Name can't be null");
            if (obj is null) throw new Exception("Object can't be null");

            dynamic exists = _repository.SelectById(obj.id);
            if (exists == null) throw new Exception("User not found");

            return _repository.UpdateById(obj);
        }

        public dynamic Delete(long id)
        {
            if (id <= 0) throw new Exception("Id can't be null");

            dynamic exists = _repository.SelectById(id);
            if (exists == null) throw new Exception("User not found");

            return _repository.DeleteById(id);
        }

        public UserLoginResponse ValidateLogin(UserLogin login)
        {
            if (string.IsNullOrEmpty(login.email)) throw new Exception("Email can't be null");
            if (string.IsNullOrEmpty(login.password)) throw new Exception("Password can't be null");

            // Busca o usuário pelo email
            var user = _repository.GetByEmail(login.email);
            if (user == null || user.password != login.password) 
                throw new Exception("Invalid credentials");

            return new UserLoginResponse
            {
                name = user.name,
                role = user.role,
                token = "" // O token será gerado no controller
            };
        }

        // Listar todos os usuários
        public List<dynamic> SelectAll()
        {
            return _repository.SelectAll();
        }

        // Buscar usuário por ID
        public dynamic SelectById(long id)
        {
            if (id <= 0) throw new Exception("Id can't be null");
            return _repository.SelectById(id);
        }
    }
}