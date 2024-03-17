using ArticleService.Domain.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticleService.Infrastructure.Context
{
    public class ArticleDbContext : DbContext
    {
        public ArticleDbContext(DbContextOptions<ArticleDbContext> options) : base(options)
        {
            
        }

        // Interceptor
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTimeOffset.UtcNow;
                        entry.Entity.IsDeleted = false;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = DateTimeOffset.UtcNow;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.IsDeleted = true;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Domain.Entities.Article> Article { get; set; }
        public DbSet<Domain.Entities.ArticleCategory> ArticleCategory { get; set; }
    }
}
