using ArticleService.Application.Interfaces.Article;
using ArticleService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ArticleModel = ArticleService.Domain.Entities.Article;


namespace ArticleService.Infrastructure.Repositories.Article
{
    public class ArticleQueryRepository : IArticleQueryRepository
    {
        private readonly ArticleDbContext _articleDbContext;
        public ArticleQueryRepository(ArticleDbContext articleDbContext) => _articleDbContext = articleDbContext;

        public DbSet<ArticleModel> Table => _articleDbContext.Set<ArticleModel>();

        public IQueryable<Domain.Entities.Article> GetAll(Expression<Func<Domain.Entities.Article, bool>> filter = null, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (filter is not null) query = query.Where(filter);
            if (!tracking) query = query.AsNoTracking();
            return query;
        }

        public async Task<Domain.Entities.Article> GetByFilterAsync(Expression<Func<Domain.Entities.Article, bool>> filter, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking) query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<Domain.Entities.Article> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking) query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        }
    }
}
