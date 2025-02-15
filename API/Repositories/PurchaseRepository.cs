using API.Core;
using API.Models;
using Microsoft.Data.Sqlite;

namespace API.Repositories
{
    public class PurchaseRepository : IRepository<PurchaseInsert, PurchaseUpdate>
    {
        public string TABLE => "Purchase";
        public dynamic SetAttributes(SqliteDataReader reader) => new Purchase()
        {
            id = long.Parse(reader["id"].ToString()!),
            userID = long.Parse(reader["userID"].ToString()!),
            orderDate = DateTime.Parse(reader["orderDate"].ToString()!),
            total = decimal.Parse(reader["total"].ToString()!),
        };
        public int Insert(PurchaseInsert obj)
        {
            using DB db = new();
            db.NewCommand($"INSERT INTO {TABLE} (userID, orderDate, total) VALUES (@userID, @orderDate, @total)");
            db.Parameter("@userID", obj.userID);
            db.Parameter("@orderDate", obj.orderDate);
            db.Parameter("@total", obj.total);
            return db.Execute();
        }
        public List<dynamic> SelectAll()
        {
            using DB db = new();
            db.NewCommand($"SELECT id, userID, orderDate, total FROM {TABLE}");
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
            db.NewCommand($"SELECT id, userID, orderDate, total FROM {TABLE} WHERE id = @id");
            db.Parameter("@id", id);
            using SqliteDataReader reader = db.Execute();
            if (reader.Read()) return SetAttributes(reader);
            return new Purchase();
        }
        public int UpdateById(PurchaseUpdate obj)
        {
            using DB db = new();
            db.NewCommand($"UPDATE {TABLE} SET userID=@userID, orderDate=@orderDate, total=@total WHERE id = @id");
            db.Parameter("@id", obj.id);
            db.Parameter("@userID", obj.userID);
            db.Parameter("@orderDate", obj.orderDate);
            db.Parameter("@total", obj.total);
            return db.Execute();
        }
        public int DeleteById(long id)
        {
            using DB db = new();
            db.NewCommand($"DELETE FROM {TABLE} WHERE id = @id");
            db.Parameter("@id", id);
            return db.Execute();
        }
    }
}