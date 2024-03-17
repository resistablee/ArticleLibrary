using ArticleModel = ArticleService.Domain.Entities.Article;

namespace ArticleService.Application.Interfaces.Article
{
    public interface IArticleCommandRepository
    {
        Task<ArticleModel> AddAsync(ArticleModel entity);
        Task<bool> AddRangeAsync(List<ArticleModel> entities);
        Task<ArticleModel> RemoveAsync(ArticleModel entity);
        Task<ArticleModel> RemoveByIdAsync(string id);
        Task<bool> RemoveRangeAsync(List<ArticleModel> entities);
        Task<ArticleModel> UpdateAsync(ArticleModel entity);
        Task<int> SaveChangesAsync();
    }
}
