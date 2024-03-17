using ArticleLibrary.Web.Models.DTO;
using ArticleLibrary.Web.Models.Interfaces;
using ArticleLibrary.Web.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArticleLibrary.Web.Controllers
{
    [Route("[controller]")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _articleService.GetAllAsync();
            return View(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] string Id)
        {
            var result = await _articleService.GetByIdAsync(Id);
            return View(result);
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm] ArticleAddDTO articleAdd)
        {
            await _articleService.AddAsync(articleAdd);
            return RedirectToAction("GetAll");
        }

        [HttpGet("Update/{Id}")]
        public async Task<IActionResult> Update([FromRoute] string Id)
        {
            var model = await _articleService.GetByIdAsync(Id);
            return View(model);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromForm] ArticleUpdateDTO articleUpdate)
        {
            await _articleService.UpdateAsync(articleUpdate);
            return View();
        }

        [HttpGet("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] string Id)
        {
            await _articleService.DeleteAsync(Id);
            return RedirectToAction("GetAll");
        }
    }
}
