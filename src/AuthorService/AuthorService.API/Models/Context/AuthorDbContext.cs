using AuthorService.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthorService.API.Models.Context
{
    public class AuthorDbContext : DbContext
    {
        public AuthorDbContext(DbContextOptions<AuthorDbContext> options) : base(options)
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

        public DbSet<Entities.Author> Author { get; set; }
    }
}
