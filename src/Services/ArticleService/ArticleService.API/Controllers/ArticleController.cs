using ArticleService.Application.Features.Article.Commands;
using ArticleService.Application.Features.Article.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArticleService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateArticleCommandRequest createArticleCommandRequest) 
            => Ok(await _mediator.Send(createArticleCommandRequest));

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateArticleCommandRequest updateArticleCommandRequest) 
            => Ok(await _mediator.Send(updateArticleCommandRequest));

        [HttpGet("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveArticleCommandRequest removeArticleCommandRequest) 
            => Ok(await _mediator.Send(removeArticleCommandRequest));

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdArticleQueryRequest getByIdArticleQueryRequest) 
            => Ok(await _mediator.Send(getByIdArticleQueryRequest));

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllArticleQueryRequest getAllArticleQueryRequest) 
            => Ok(await _mediator.Send(getAllArticleQueryRequest));
    }
}
