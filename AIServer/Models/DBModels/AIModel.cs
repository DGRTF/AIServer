using Microsoft.AspNetCore.Http;

namespace AIServer.Models.DBModels
{
    public class AIModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Model { get; set; }

    }
}
