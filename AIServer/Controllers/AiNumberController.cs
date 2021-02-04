using AIServer.AI;
using AIServer.DataHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace AIServer.Controllers
{
    [Route("AiNumber/[action]")]
    public class AiNumberController : Controller
    {
        public AiNumberController()
        {

        }

        [HttpPost]
        public IActionResult DefineNumber(IFormFile file)
        {
            var streamImage = file.OpenReadStream();
            var imageHandler = new ImageHandler(new Bitmap(streamImage));

            var model = new AiSingleNumber();
            int result = model.DefineNumber(imageHandler.InputData);

            return Json(result);
        }

    }
}
