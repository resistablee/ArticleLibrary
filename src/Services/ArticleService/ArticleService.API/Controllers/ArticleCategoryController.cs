using ArticleService.Application.Features.ArticleCategory.Commands;
using ArticleService.Application.Features.ArticleCategory.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArticleService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateArticleCategoryCommandRequest createArticleCategoryCommandRequest)
            => Ok(await _mediator.Send(createArticleCategoryCommandRequest));

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateArticleCategoryCommandRequest updateArticleCategoryCommandRequest)
            => Ok(await _mediator.Send(updateArticleCategoryCommandRequest));

        [HttpGet("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveArticleCategoryCommandRequest removeArticleCategoryCommandRequest)
            => Ok(await _mediator.Send(removeArticleCategoryCommandRequest));

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdArticleCategoryQueryRequest getByIdArticleCategoryQueryRequest)
            => Ok(await _mediator.Send(getByIdArticleCategoryQueryRequest));

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllArticleCategoryQueryRequest getAllArticleCategoryQueryRequest)
            => Ok(await _mediator.Send(getAllArticleCategoryQueryRequest));
    }
}
