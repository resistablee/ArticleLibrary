using System.Linq.Expressions;
using ArticleModel = ArticleService.Domain.Entities.Article;

namespace ArticleService.Application.Interfaces.Article
{
    public interface IArticleQueryRepository
    {
        IQueryable<ArticleModel> GetAll(Expression<Func<ArticleModel, bool>> filter = null, bool tracking = true);
        Task<ArticleModel> GetByFilterAsync(Expression<Func<ArticleModel, bool>> filter, bool tracking = true);
        Task<ArticleModel> GetByIdAsync(string id, bool tracking = true);
    }
}
