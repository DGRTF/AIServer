using System.Text.Json.Serialization;

namespace AIServer.Models.DBModels
{
    public class AIModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Model { get; set; }

        [JsonIgnore]
        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}
