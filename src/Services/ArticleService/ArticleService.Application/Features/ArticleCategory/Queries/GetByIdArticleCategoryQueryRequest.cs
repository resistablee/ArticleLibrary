using MediatR;

namespace ArticleService.Application.Features.ArticleCategory.Queries
{
    public class GetByIdArticleCategoryQueryRequest : IRequest<IQueryable<GetByIdArticleCategoryQueryResponse>>
    {
        public string Id { get; set; }
    }
}
