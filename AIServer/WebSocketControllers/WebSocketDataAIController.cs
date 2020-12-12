using AIServer.DBModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace AIServer.WebSocketControllers
{
    //[Microsoft.AspNetCore.Components.Route("ws/[controller]/[action]")]
    [Authorize]
    public class WebSocketDataAIController : Controller
    {
        private readonly ApplicationContext _context;

        public WebSocketDataAIController(ApplicationContext context):base()
        {
            _context = context;
            //User = new ClaimsPrincipal();
        }

        /// <summary>
        /// Нужно для коннекта клиента
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        [HttpGet("WebSocketDataAI/Connect")]
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

        // Тест возврата полученных сообщений
        public async Task Echo(HttpContext context, WebSocket webSocket)
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

    //class a
    //{
    //    public a()
    //    {
    //    }
    //    public string g  {get;}
    //}
    //class b : a
    //{
    //    public b(string g)
    //    {
    //        this.g = g;
    //    }
    //}
}
