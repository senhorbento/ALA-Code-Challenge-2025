using API.Models;
using Microsoft.Data.Sqlite;

namespace API.Repositories
{
    public class UserRepository : IRepository<UserInsert, UserUpdate>
    {
        public string TABLE => "Usuario";
        
        public int DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public int Insert(UserInsert obj)
        {
            throw new NotImplementedException();
        }

        public List<dynamic> SelectAll()
        {
            throw new NotImplementedException();
        }

        public dynamic SelectById(long id)
        {
            throw new NotImplementedException();
        }

        public dynamic SetAttributes(SqliteDataReader reader)
        {
            throw new NotImplementedException();
        }

        public int UpdateById(UserUpdate obj)
        {
            throw new NotImplementedException();
        }

    }
}
