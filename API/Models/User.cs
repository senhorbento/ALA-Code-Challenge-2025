// Models/User.cs
using Newtonsoft.Json;

namespace API.Models
{
    public class User
    {
        public long id { get; set; } = -1;
        public string email { get; set; } = "";
        [JsonIgnore]
        public string password { get; set; } = "";
        public string name { get; set; } = "";
        public string role { get; set; } = "user"; // Adicionado campo de role
    }

    public class UserLoginResponse
    {
        public string role { get; set; } = "";
        public string name { get; set; } = "";
        public string token { get; set; } = "";
    }

    public class UserLogin
    {
        public string email { get; set; } = "";
        public string password { get; set; } = "";
    }

    public class UserInsert
    {
        public string email { get; set; } = "";
        public string name { get; set; } = "";
        public string password { get; set; } = "";
        public string role { get; set; } = "user"; // Adicionado role
    }

    public class UserUpdate
    {
        public long id { get; set; } = -1;
        public string email { get; set; } = "";
        public string password { get; set; } = "";

        public string name { get; set; } = "";
        public string role { get; set; } = "user"; // Adicionado role
    }
}