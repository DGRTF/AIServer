using System.Collections.Generic;

namespace AIServer.Models.DBModels
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; } // имя пользователя
        public string Password { get; set; }
        public List<AIModel> AIModels { get; set; }
    }
}
