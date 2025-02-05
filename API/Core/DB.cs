using Microsoft.Data.Sqlite;
using SQLitePCL;
using System.Data;

namespace API.Core;
public class DB : IDisposable
{
    private readonly SqliteConnection cnn = new(Constants.DB._CONNECTION_STRING_);
    public SqliteCommand command { get; private set; } = new();
    public void NewCommand(string query) => command = new(query, cnn);
    public void Parameter(string parameter, dynamic value) => command.Parameters.AddWithValue(parameter, value);
    public void Command(string sql) => command = new(sql, cnn);
    public void Connect()
    {
        try
        {
            Batteries.Init();
            if (cnn != null || cnn?.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
        }
        catch (SqliteException ex)
        {
            Console.WriteLine($"Error connecting to the database: {ex.Message}");
            throw;
        }
    }
    public void Disconnect()
    {
        if (cnn != null && cnn.State != ConnectionState.Closed)
        {
            cnn.Close();
            command.Dispose();
        }
    }
    public dynamic Execute()
    {
        if (cnn?.State == ConnectionState.Closed)
        {
            Connect();
        }
        if (command.CommandText.ToUpper().StartsWith("SELECT"))
        {
            return command.ExecuteReader();
        }
        return command.ExecuteNonQuery();
    }
    public void Dispose()
    {
        Disconnect();
    }

    public void CreateDatabase()
    {
        NewCommand(@"
        CREATE TABLE IF NOT EXISTS User ( id INTEGER PRIMARY KEY AUTOINCREMENT, email TEXT NOT NULL, password TEXT NOT NULL, name TEXT NOT NULL );
        CREATE TABLE IF NOT EXISTS Product ( id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL, price DECIMAL(10, 2) NOT NULL );
        CREATE TABLE IF NOT EXISTS Purchase ( id INTEGER PRIMARY KEY AUTOINCREMENT, userID INTEGER, orderDate DATETIME, total DECIMAL(10, 2) NOT NULL, FOREIGN KEY (userID) REFERENCES User(id) );");
        Connect();
        Execute();
        Dispose();
    }
}