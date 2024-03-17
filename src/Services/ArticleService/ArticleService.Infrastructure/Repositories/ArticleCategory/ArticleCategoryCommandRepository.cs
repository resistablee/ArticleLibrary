using ArticleService.Application.Interfaces.Article;
using ArticleService.Application.Interfaces.ArticleCategory;
using ArticleService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using ArticleCategoryModel = ArticleService.Domain.Entities.ArticleCategory;

namespace ArticleService.Infrastructure.Repositories.ArticleCategory
{
    public class ArticleCategoryCommandRepository : IArticleCategoryCommandRepository
    {
        private readonly ArticleDbContext _articleDbContext;
        public ArticleCategoryCommandRepository(ArticleDbContext articleDbContext) => _articleDbContext = articleDbContext;

        public DbSet<ArticleCategoryModel> Table => _articleDbContext.Set<ArticleCategoryModel>();

        public async Task<Domain.Entities.ArticleCategory> AddAsync(Domain.Entities.ArticleCategory entity)
        {
            await Table.AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<bool> AddRangeAsync(List<Domain.Entities.ArticleCategory> entities)
        {
            await Table.AddRangeAsync(entities);
            await SaveChangesAsync();
            return true;
        }

        public async Task<Domain.Entities.ArticleCategory> RemoveAsync(Domain.Entities.ArticleCategory entity)
        {
            Table.Remove(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<Domain.Entities.ArticleCategory> RemoveByIdAsync(string id)
        {
            var entity = await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            await RemoveAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<bool> RemoveRangeAsync(List<Domain.Entities.ArticleCategory> entities)
        {
            Table.RemoveRange(entities);
            await SaveChangesAsync();
            return true;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _articleDbContext.SaveChangesAsync();
        }

        public async Task<Domain.Entities.ArticleCategory> UpdateAsync(Domain.Entities.ArticleCategory entity)
        {
            Table.Update(entity);
            await SaveChangesAsync();
            return entity;
        }
    }
}
