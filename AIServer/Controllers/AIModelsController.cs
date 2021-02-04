using AIServer.Models.DBModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public async Task<JsonResult> AddAIModel(IFormFile file)
        {
            var model = await ContextDB.AIModels.FirstOrDefaultAsync(model => model.Name == file.FileName);

            if (model == null)
            {
                var user = await ContextDB.Users.FirstOrDefaultAsync(user => user.Name == User.Identity.Name);
                int id = user.Id;

                var stream = file.OpenReadStream();

                model = new AIModel()
                {
                    Name = file.FileName,
                    UserId = id,
                    Model = new byte[stream.Length],
                };

                await stream.ReadAsync(model.Model, 0, (int)stream.Length);

                await ContextDB.AIModels.AddAsync(model);
                await ContextDB.SaveChangesAsync();

                return Json(true);
            }
            else
                return Json(false);
        }

        [HttpGet]
        public async Task<JsonResult> GetMyModels(RequesModelGetMyModels request)
        {
            if (request.Take > 0)
            {
                if (request.Take > 1000)
                    request.Take = 1000;

                var models = await ContextDB.AIModels.Where(model =>
                    model.UserId == ContextDB.Users.FirstOrDefault(user =>
                        user.Name == User.Identity.Name).Id)
                    .Select(model => new
                    {
                        model.Id,
                        model.Name,
                    }).Skip(request.Skip).Take(request.Take).ToListAsync();

                return Json(models);
            }
            else
                return Json(
                    BadRequest(
                        new { errorText = "Количество запрашиваемых моделей не может быть меньше 1." }));
        }

        [HttpDelete]
        public void DeleteModel()
        {

        }

        public class RequesModelGetMyModels
        {
            public int Skip { get; set; } = 0;
            public int Take { get; set; } = 100;
        }
    }
}
