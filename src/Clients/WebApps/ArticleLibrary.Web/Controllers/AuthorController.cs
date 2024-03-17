using ArticleLibrary.Web.Models.DTO;
using ArticleLibrary.Web.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArticleLibrary.Web.Controllers
{
    [Route("[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _AuthorService;

        public AuthorController(IAuthorService authorService)
        {
            _AuthorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _AuthorService.GetAllAsync();
            return View(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] string Id)
        {
            var result = await _AuthorService.GetByIdAsync(Id);
            return View(result);
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm] AuthorAddDTO authorAdd)
        {
            await _AuthorService.AddAsync(authorAdd);
            return RedirectToAction("GetAll");
        }

        [HttpGet("Update/{Id}")]
        public async Task<IActionResult> Update([FromRoute] string Id)
        {
            var model = await _AuthorService.GetByIdAsync(Id);
            return View(model);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromForm] AuthorUpdateDTO authorUpdate)
        {
            await _AuthorService.UpdateAsync(authorUpdate);
            return View();
        }

        [HttpGet("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] string Id)
        {
            await _AuthorService.DeleteAsync(Id);
            return RedirectToAction("GetAll");
        }
    }
}
