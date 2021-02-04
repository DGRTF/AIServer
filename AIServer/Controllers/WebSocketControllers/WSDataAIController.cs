using AIServer.Models.DBModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace AIServer.Controllers.WebSocketControllers
{
    [Route("ws/WSDataAI/[action]")]
    [Authorize]
    public class WSDataAIController : Controller
    {
        private readonly ApplicationDBContext _context;

        public WSDataAIController(ApplicationDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Нужно для коннекта клиента
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task Connect()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                WebSocket webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await Echo(HttpContext, webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        async Task Echo(HttpContext context, WebSocket webSocket)
        {

            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer),
                CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {
                await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count),
                    result.MessageType,
                    result.EndOfMessage,
                    CancellationToken.None);

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer),
                    CancellationToken.None);
            }
            await webSocket.CloseAsync(result.CloseStatus.Value,
                result.CloseStatusDescription,
                CancellationToken.None);

        }
    }
}
