using AIServer.AI;
using AIServer.DataHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace AIServer.Controllers
{
    [Route("[controller]/[action]")]
    public class AiNumberController : Controller
    {
        [HttpPost]
        public IActionResult DefineNumber(IFormFile File)
        {
            var streamImage = File.OpenReadStream();
            var imageHandler = new ImageHandler(new Bitmap(streamImage));

            var model = new AiSingleNumber();
            int result = model.DefineNumber(imageHandler.InputData);

            return Json(result);
        }

    }
}
