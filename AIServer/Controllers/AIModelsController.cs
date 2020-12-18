using AIServer.Models.DBModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AIServer.Controllers
{
    [Route("AIModels/[action]")]
    [Authorize]
    public class AIModelsController : Controller
    {
        ApplicationDBContext ContextDB { get; }
        public AIModelsController(ApplicationDBContext contextDB)
        {
            ContextDB = contextDB;
        }

        [HttpPost]
        public JsonResult AddAIModel(IFormFile file)
        {
            var model = ContextDB.AIModels.FirstOrDefault(model => model.Name == file.FileName);

            if (model == null)
            {
                int id = ContextDB.Users
                    .FirstOrDefault(user => user.Name == User.Identity.Name).Id;

                model = new AIModel()
                {
                    Name = file.FileName,
                    UserId = id,
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

        [HttpGet]
        public JsonResult GetMyModels(RequesModelGetMyModels request)
        {
            if (request.Take > 0)
            {
                if (request.Take > 1000)
                    request.Take = 1000;

                var models = ContextDB.AIModels.ToList().Where(model =>
                model.UserId == ContextDB.Users.FirstOrDefault(user =>
                user.Name == User.Identity.Name).Id)
                    .Select(model => new
                    {
                        model.Id,
                        model.Name,
                    }).Skip(request.Skip).Take(request.Take);

                return Json(models);
            }
            else
                return Json(
                    BadRequest(
                        new { errorText = "Количество запрашиваемых моделей не может быть меньше 1." }));
        }

        public class RequesModelGetMyModels
        {
            public int Skip { get; set; } = 0;
            public int Take { get; set; } = 100;
        }
    }
}
