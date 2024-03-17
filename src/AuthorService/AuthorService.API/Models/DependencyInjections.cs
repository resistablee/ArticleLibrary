using AuthorService.API.Models.Context;
using AuthorService.API.Models.Interfaces;
using AuthorService.API.Models.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AuthorService.API.Models
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddAuthorDbContext(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<AuthorDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

            return serviceCollection;
        }

        public static IServiceCollection AddAuthorService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAuthorService, Services.AuthorService>();

            return serviceCollection;
        }

        public static IServiceCollection AddExtensionAutoMapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(DependencyInjections));
            return serviceCollection;
        }

        public static IServiceCollection AddIdentityService(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Identity:Secret"]));

            serviceCollection.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey
                };
            });

            serviceCollection.AddAutoMapper(typeof(DependencyInjections));

            return serviceCollection;
        }

        public static IServiceCollection AddUserService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpContextAccessor();

            serviceCollection.AddTransient<IUserService, UserService>();

            return serviceCollection;
        }
    }
}
