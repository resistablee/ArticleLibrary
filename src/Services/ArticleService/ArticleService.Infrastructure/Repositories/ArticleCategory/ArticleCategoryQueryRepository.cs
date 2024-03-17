using ArticleService.Application.Interfaces.Article;
using ArticleService.Application.Interfaces.ArticleCategory;
using ArticleService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ArticleCategoryModel = ArticleService.Domain.Entities.ArticleCategory;


namespace ArticleService.Infrastructure.Repositories.ArticleCategory
{
    public class ArticleCategoryQueryRepository : IArticleCategoryQueryRepository
    {
        private readonly ArticleDbContext _articleDbContext;
        public ArticleCategoryQueryRepository(ArticleDbContext articleDbContext) => _articleDbContext = articleDbContext;

        public DbSet<ArticleCategoryModel> Table => _articleDbContext.Set<ArticleCategoryModel>();

        public IQueryable<Domain.Entities.ArticleCategory> GetAll(Expression<Func<Domain.Entities.ArticleCategory, bool>> filter = null, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (filter is not null) query = query.Where(filter);
            if (!tracking) query = query.AsNoTracking();
            return query;
        }

        public async Task<Domain.Entities.ArticleCategory> GetByFilterAsync(Expression<Func<Domain.Entities.ArticleCategory, bool>> filter, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking) query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<Domain.Entities.ArticleCategory> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking) query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        }
    }
}
