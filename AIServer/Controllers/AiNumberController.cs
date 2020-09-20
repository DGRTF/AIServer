﻿using AIServer.AI;
using AIServer.DataHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIServer.Controllers
{
    public class AiNumberController : Controller
    {

        public AiNumberController()
        {

        }

        [HttpPost]
        public int DefineNumber(IFormFile File)
        {
            var streamImage = File.OpenReadStream();
            var imageHandler = new ImageHandler(streamImage);

            var model = new AiSingleNumber();

            return model.DefineNumber(imageHandler.InputData);
        }

    }
}
