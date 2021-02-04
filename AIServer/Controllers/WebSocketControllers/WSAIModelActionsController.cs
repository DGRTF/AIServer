using AIServer.AI;
using AIServer.Models.DBModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace AIServer.Controllers.WebSocketControllers
{
    [Route("ws/WSAIModelActions/[action]")]
    [Authorize]
    public class WSAIModelActionsController : Controller
    {
        ApplicationDBContext ContextDB { get; }
        AiSingleNumber Model { get; set; }
        WebSocketReceiveResult Result { get; set; }
        WebSocket Socket { get; set; }

        public WSAIModelActionsController(ApplicationDBContext contextDB)
        {
            ContextDB = contextDB;
        }

        /// <summary>
        /// Connection method
        /// </summary>
        /// <param name="modelName">Model name</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> RunModel(string modelName)
        {
            if (String.IsNullOrEmpty(modelName))
                return BadRequest(new { errorText = "Model is not have name" });

            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                var model = await ContextDB.AIModels.FirstOrDefaultAsync(model => model.Name == modelName);

                if (model == null)
                    return BadRequest(new { errorText = "Model not found" });

                Model = new AiSingleNumber(model.Model);

                Socket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await EchoAsync();
            }

            return Json(new
            {
                message = ""
            });
        }

        async Task EchoAsync()
        {
            ResultData resultData = await ReceiveObjectDataAsync();

            while (!Result.CloseStatus.HasValue)
            {
                await SendObjectDataAsync(resultData);
                resultData = await ReceiveObjectDataAsync();
            }

            await Socket.CloseAsync(Result.CloseStatus.Value,
                Result.CloseStatusDescription,
                CancellationToken.None);
        }

        async Task<ResultData> ReceiveObjectDataAsync()
        {
            var dataByte = await ReceiveByteDataAsync();
            var message = Encoding.UTF8.GetString(dataByte, 0, dataByte.Length);
            var data = JsonSerializer.Deserialize<float[]>(message);

            return new ResultData()
            {
                ResultDataSet = Model.DefineNumber(data),
            };
        }

        async Task<byte[]> ReceiveByteDataAsync()
        {
            byte[] data = Array.Empty<byte>();
            int resultLength;

            while (true)
            {
                int currentLength = 30;
                byte[] buffer = new byte[currentLength];
                Result = await Socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                data = data.Concat(buffer).ToArray();

                if (Result.EndOfMessage)
                {
                    resultLength = data.Length + Result.Count - currentLength;
                    break;
                }
            }

            byte[] outData = new byte[resultLength];
            Array.Copy(data, outData, outData.Length);

            return outData;
        }

        async Task SendObjectDataAsync(ResultData resultData)
        {
            var buffer = JsonSerializer.SerializeToUtf8Bytes(resultData, typeof(ResultData));

            await Socket.SendAsync(new ArraySegment<byte>(buffer, 0, buffer.Length),
                Result.MessageType,
                Result.EndOfMessage,
                CancellationToken.None);
        }



    }

    class ResultData
    {
        public int ResultDataSet { get; set; }
    }
}
