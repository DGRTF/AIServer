using AIServer.AI;
using AIServer.DataHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIServer.Controllers
{
    public class UploadImageModel
    {
        public IFormFile File { get; set; }
        //public Guid uniqueId { get; set; }
    }

    public class AiNumberController : Controller
    {

        public AiNumberController()
        {

        }

        //[HttpPost]
        public int DefineNumber(IFormFile File)
        {
            //System.Console.WriteLine(File.ContentType);
            var streamImage = File.OpenReadStream();
            var imageHandler = new ImageHandler(streamImage);

            var model = new AiSingleNumber();
            int i = (int)imageHandler.InputData[0];

            float[] inArr= new float[784];
            int count = 0;
            foreach(var n in imageHandler.InputData)
            {
                inArr[count] = n;
                count++;
            }
            
            return model.DefineNumber(inArr);
        }

    }
}
