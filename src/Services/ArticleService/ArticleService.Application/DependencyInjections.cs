using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ArticleService.Application
{
    public static class DependencyInjections
    {
        public static void AddExtensionMediatR(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(DependencyInjections));
        }

        public static void AddExtensionAutoMapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(DependencyInjections));
        }
    }
}
