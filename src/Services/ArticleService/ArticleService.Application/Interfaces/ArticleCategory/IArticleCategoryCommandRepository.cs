using ArticleCategoryModel = ArticleService.Domain.Entities.ArticleCategory;

namespace ArticleService.Application.Interfaces.ArticleCategory
{
    public interface IArticleCategoryCommandRepository
    {
        Task<ArticleCategoryModel> AddAsync(ArticleCategoryModel entity);
        Task<bool> AddRangeAsync(List<ArticleCategoryModel> entities);
        Task<ArticleCategoryModel> RemoveAsync(ArticleCategoryModel entity);
        Task<ArticleCategoryModel> RemoveByIdAsync(string id);
        Task<bool> RemoveRangeAsync(List<ArticleCategoryModel> entities);
        Task<ArticleCategoryModel> UpdateAsync(ArticleCategoryModel entity);
        Task<int> SaveChangesAsync();
    }
}
