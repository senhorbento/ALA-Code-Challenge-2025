using Microsoft.Data.Sqlite;

namespace API.Repositories
{
    public interface IRepository<TCreate, TUpdate>
    {
        public abstract string TABLE { get; }
        public abstract dynamic SetAttributes(SqliteDataReader reader);
        public abstract int Insert(TCreate obj);
        public abstract List<dynamic> SelectAll();
        public abstract dynamic SelectById(long id);
        public abstract int UpdateById(TUpdate obj);
        public abstract int DeleteById(long id);

    }
}
