using ArticleService.Application.Interfaces.Article;
using ArticleService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using ArticleModel = ArticleService.Domain.Entities.Article;

namespace ArticleService.Infrastructure.Repositories.Article
{
    public class ArticleCommandRepository : IArticleCommandRepository
    {
        private readonly ArticleDbContext _articleDbContext;
        public ArticleCommandRepository(ArticleDbContext articleDbContext) => _articleDbContext = articleDbContext;

        public DbSet<ArticleModel> Table => _articleDbContext.Set<ArticleModel>();

        public async Task<Domain.Entities.Article> AddAsync(Domain.Entities.Article entity)
        {
            await Table.AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<bool> AddRangeAsync(List<Domain.Entities.Article> entities)
        {
            await Table.AddRangeAsync(entities);
            await SaveChangesAsync();
            return true;
        }

        public async Task<Domain.Entities.Article> RemoveAsync(Domain.Entities.Article entity)
        {
            Table.Remove(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<Domain.Entities.Article> RemoveByIdAsync(string id)
        {
            var entity = await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            await RemoveAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<bool> RemoveRangeAsync(List<Domain.Entities.Article> entities)
        {
            Table.RemoveRange(entities);
            await SaveChangesAsync();
            return true;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _articleDbContext.SaveChangesAsync();
        }

        public async Task<Domain.Entities.Article> UpdateAsync(Domain.Entities.Article entity)
        {
            Table.Update(entity);
            await SaveChangesAsync();
            return entity;
        }
    }
}
