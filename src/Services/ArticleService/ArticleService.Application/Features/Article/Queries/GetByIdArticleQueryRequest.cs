using MediatR;

namespace ArticleService.Application.Features.Article.Queries
{
    public class GetByIdArticleQueryRequest : IRequest<GetByIdArticleQueryResponse>
    {
        public string Id { get; set; }
    }
}
