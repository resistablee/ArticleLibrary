using MediatR;

namespace ArticleService.Application.Features.Article.Queries
{
    public record GetAllArticleQueryRequest : IRequest<List<GetAllArticleQueryResponse>>
    {
    }
}
