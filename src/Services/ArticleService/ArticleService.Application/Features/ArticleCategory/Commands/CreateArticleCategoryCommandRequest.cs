using MediatR;

namespace ArticleService.Application.Features.ArticleCategory.Commands
{
    public class CreateArticleCategoryCommandRequest : IRequest<CreateArticleCategoryCommandResponse>
    {
        public string Category { get; set; }
    }
}
