using System;
using System.Net.Http;
using System.Net.WebSockets;

namespace WebSocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            Uri uri = new Uri("https://localhost:44371/token");


            var response = client.PostAsync(uri, new StringContent(@"name:Имя password:12345")).Result;
            ClientWebSocket socket = new ClientWebSocket();
            // Will throw
            socket.Options.SetRequestHeader("Authorization", "Bearer ");
        }
    }
}
