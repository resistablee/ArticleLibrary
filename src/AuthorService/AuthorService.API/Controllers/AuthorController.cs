using AuthorService.API.Models.DTO;
using AuthorService.API.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthorService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DtoAuthorAdd authorAdd)
            => Ok(await _authorService.AddAsync(authorAdd));

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] DtoAuthorUpdate authorUpdate)
            => Ok(await _authorService.UpdateAsync(authorUpdate));

        [HttpGet("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] string Id)
            => Ok(await _authorService.RemoveAsync(Id));

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] string Id)
            => Ok(await _authorService.GetByIdAsync(Id));

        [HttpGet]
        public IActionResult GetAll()
            => Ok(_authorService.GetAll());
    }
}
