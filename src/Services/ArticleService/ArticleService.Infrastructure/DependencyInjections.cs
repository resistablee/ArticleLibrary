using ArticleService.Application.Interfaces.Article;
using ArticleService.Application.Interfaces.ArticleCategory;
using ArticleService.Infrastructure.Context;
using ArticleService.Infrastructure.Repositories.Article;
using ArticleService.Infrastructure.Repositories.ArticleCategory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArticleService.Infrastructure
{
    public static class DependencyInjections
    {
        public static void AddArticleDbContext(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        {
            serviceCollection.AddDbContext<ArticleDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
        }

        public static void AddArticleService(this IServiceCollection serviceCollection)
        {
            //Article
            serviceCollection.AddScoped<IArticleCommandRepository, ArticleCommandRepository>();
            serviceCollection.AddScoped<IArticleQueryRepository, ArticleQueryRepository>();
        }

        public static void AddArticleCategoryService(this IServiceCollection serviceCollection)
        {
            //Article
            serviceCollection.AddScoped<IArticleCategoryCommandRepository, ArticleCategoryCommandRepository>();
            serviceCollection.AddScoped<IArticleCategoryQueryRepository, ArticleCategoryQueryRepository>();
        }
    }
}
