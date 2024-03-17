using MediatR;

namespace ArticleService.Application.Features.ArticleCategory.Commands
{
    public class RemoveArticleCategoryCommandRequest : IRequest<RemoveArticleCategoryCommandResponse>
    {
    }
}
