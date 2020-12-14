using AIServer.Models.DBModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AIServer.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class AIModelsController : Controller
    {
        ApplicationDBContext ContextDB { get; }
        public AIModelsController(ApplicationDBContext contextDB)
        {
            ContextDB = contextDB;
        }

        [HttpPost]
        public JsonResult AddAIModel([Required]IFormFile file)
        {
            var model = ContextDB.AIModels.ToList().FirstOrDefault(model => model.Name == file.FileName);

            if (model == null)
            {
                model = new AIModel()
                {
                    Name = file.FileName
                };

                var stream = file.OpenReadStream();
                stream.ReadAsync(model.Model, 0, (int)stream.Length);

                ContextDB.AIModels.Add(model);
                ContextDB.SaveChanges();
                return Json(true);
            }
            else
                return Json(false);
        }
    }
}
