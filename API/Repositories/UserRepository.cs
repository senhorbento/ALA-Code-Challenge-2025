using API.Models;
using Microsoft.Data.Sqlite;
using API.Core;

namespace API.Repositories
{
    public class UserRepository : IRepository<UserInsert, UserUpdate>
    {
        public string TABLE => "User"; // Corrigido nome da tabela

        public dynamic SetAttributes(SqliteDataReader reader) => new User()
        {
            id = long.Parse(reader["id"].ToString()!),
            email = reader["email"].ToString()!,
            password = reader["password"].ToString()!,
            name = reader["name"].ToString()!,
            role = reader["role"].ToString()!
        };

        public int Insert(UserInsert obj)
        {
            using DB db = new();
            db.NewCommand($"INSERT INTO {TABLE} (email, name, password, role) VALUES (@email, @name, @password, @role)");
            db.Parameter("@email", obj.email);
            db.Parameter("@name", obj.name);
            db.Parameter("@password", obj.password); // Hash da senha
            db.Parameter("@role", obj.role);
            return db.Execute();
        }

        public List<dynamic> SelectAll()
        {
            using DB db = new();
            db.NewCommand($"SELECT id, email, password, name, role FROM {TABLE}");
            List<dynamic> list = [];
            using SqliteDataReader reader = db.Execute();
            while (reader.Read())
            {
                list.Add(SetAttributes(reader));
            }
            return list;
        }

        public dynamic SelectById(long id)
        {
            using DB db = new();
            db.NewCommand($"SELECT id, email, password, name, role FROM {TABLE} WHERE id = @id");
            db.Parameter("@id", id);
            using SqliteDataReader reader = db.Execute();
            return reader.Read() ? SetAttributes(reader) : null;
        }

        public int UpdateById(UserUpdate obj)
        {
            using DB db = new();
            db.NewCommand($"UPDATE {TABLE} SET email=@email, name=@name, password=@password, role=@role WHERE id = @id");
            db.Parameter("@id", obj.id);
            db.Parameter("@email", obj.email);
            db.Parameter("@name", obj.name);
            db.Parameter("@password", obj.password); // Hash da senha
            db.Parameter("@role", obj.role);
            return db.Execute();
        }

        public int DeleteById(long id)
        {
            using DB db = new();
            db.NewCommand($"DELETE FROM {TABLE} WHERE id = @id");
            db.Parameter("@id", id);
            return db.Execute();
        }

        public User? GetByEmail(string email)
        {
            using DB db = new();
            db.NewCommand($"SELECT * FROM {TABLE} WHERE email = @email");
            db.Parameter("@email", email);
            using SqliteDataReader reader = db.Execute();
            return reader.Read() ? (User)SetAttributes(reader) : null;
        }
    }
}