using MediatR;

namespace ArticleService.Application.Features.ArticleCategory.Queries
{
    public class GetAllArticleCategoryQueryRequest : IRequest<List<GetAllArticleCategoryQueryResponse>>
    {
    }
}
