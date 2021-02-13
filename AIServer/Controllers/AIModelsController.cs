using AIServer.Models.DBModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> AddAIModel(IFormFile file)
        {
            var model = await ContextDB.AIModels.AsNoTracking()
                .Where(model => model.UserId == ContextDB.Users.AsNoTracking()
                    .FirstOrDefault(user => user.Name == User.Identity.Name).Id)
                        .FirstOrDefaultAsync(model => model.Name == file.FileName);

            if (model != null)
                return BadRequest(
                        new { errorText = "Модель с таким именем уже существует" });

            var user = await ContextDB.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Name == User.Identity.Name);
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

        [HttpGet]
        public async Task<IActionResult> GetMyModels(RequesModelGetMyModels request)
        {
            if (request.Take < 1)
                return BadRequest(
                        new { errorText = "Количество запрашиваемых моделей не может быть меньше 1." });

            if (request.Take > 1000)
                request.Take = 1000;

            var models = await ContextDB.AIModels.AsNoTracking().Where(model =>
                model.UserId == ContextDB.Users.AsNoTracking().FirstOrDefault(user =>
                    user.Name == User.Identity.Name).Id)
                .Select(model => new
                {
                    model.Id,
                    model.Name,
                }).Skip(request.Skip).Take(request.Take).ToListAsync();

            return Json(models);
        }

        [HttpDelete]
        public async Task DeleteModel(string modelName)
        {
            var model = await ContextDB.AIModels.AsNoTracking()
                .Where(model => model.UserId == ContextDB.Users
                    .FirstOrDefault(user => user.Name == User.Identity.Name).Id)
                        .FirstOrDefaultAsync(model => model.Name == modelName);

            ContextDB.AIModels.Remove(model);
            await ContextDB.SaveChangesAsync();
        }

        public class RequesModelGetMyModels
        {
            public int Skip { get; set; } = 0;
            public int Take { get; set; } = 100;
        }
    }
}
