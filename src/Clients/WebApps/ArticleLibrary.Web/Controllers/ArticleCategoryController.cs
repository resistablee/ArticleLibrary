using ArticleLibrary.Web.Models.DTO;
using ArticleLibrary.Web.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArticleLibrary.Web.Controllers
{
    [Route("[controller]")]
    public class ArticleCategoryController : Controller
    {
        private readonly IArticleCategoryService _articleCategoryService;

        public ArticleCategoryController(IArticleCategoryService articleCategoryService)
        {
            _articleCategoryService = articleCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _articleCategoryService.GetAllAsync();
            return View(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] string Id)
        {
            var result = await _articleCategoryService.GetByIdAsync(Id);
            return View(result);
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm] ArticleCategoryAddDTO articleCategoryAdd)
        {
            await _articleCategoryService.AddAsync(articleCategoryAdd);
            return RedirectToAction("GetAll");
        }

        [HttpGet("Update/{Id}")]
        public async Task<IActionResult> Update([FromRoute] string Id)
        {
            var model = await _articleCategoryService.GetByIdAsync(Id);
            return View(model);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromForm] ArticleCategoryUpdateDTO articleCategoryUpdate)
        {
            await _articleCategoryService.UpdateAsync(articleCategoryUpdate);
            return View();
        }

        [HttpGet("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] string Id)
        {
            await _articleCategoryService.DeleteAsync(Id);
            return RedirectToAction("GetAll");
        }
    }
}
