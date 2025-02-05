namespace API.Models
{
    public class User
    {
        public string user { get; set; } = "";
        public string password { get; set; } = "";
    }
    public class UserLoginResponse
    {
        public string role { get; set; } = "";
        public string name { get; set; } = "";
        public string token { get; set; } = "";
    }
    public class UserLogin
    {
        public string user { get; set; } = "";
        public string password { get; set; } = "";
    }
    public class UserInsert
    {
        public string email { get; set; } = "";
        public string name { get; set; } = "";
        public string password { get; set; } = "";
    }
    public class UserUpdate
    {
        public int id { get; set; } = -1;
        public string email { get; set; } = "";
        public string name { get; set; } = "";
        public string password { get; set; } = "";
    }
}
