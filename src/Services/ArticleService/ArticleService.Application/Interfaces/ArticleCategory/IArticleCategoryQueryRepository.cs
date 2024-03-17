using System.Linq.Expressions;
using ArticleCategoryModel = ArticleService.Domain.Entities.ArticleCategory;

namespace ArticleService.Application.Interfaces.ArticleCategory
{
    public interface IArticleCategoryQueryRepository
    {
        IQueryable<ArticleCategoryModel> GetAll(Expression<Func<ArticleCategoryModel, bool>> filter = null, bool tracking = true);
        Task<ArticleCategoryModel> GetByFilterAsync(Expression<Func<ArticleCategoryModel, bool>> filter, bool tracking = true);
        Task<ArticleCategoryModel> GetByIdAsync(string id, bool tracking = true);
    }
}
