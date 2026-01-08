using AuthorService.API.Models.Context;
using AuthorService.API.Models.DTO;
using AuthorService.API.Models.Entities;
using AuthorService.API.Models.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace AuthorService.API.Models.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AuthorDbContext _authorDbContext;
        private readonly IMapper _Mapper;
        private readonly IDistributedCache _cache;

        private const string CacheKey = "AuthorCache";

        public AuthorService(AuthorDbContext authorDbContext, IMapper mapper, IDistributedCache cache)
        {
            _authorDbContext = authorDbContext;
            _Mapper = mapper;
            _cache = cache;
        }

        public DbSet<Author> Table => _authorDbContext.Set<Author>();

        public async Task<dynamic> AddAsync(DtoAuthorAdd authorAdd)
        {
            var model = _Mapper.Map<Author>(authorAdd);
            await Table.AddAsync(model);
            await SaveChangesAsync();
            return true;
        }

        public IQueryable<Author> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking) 
                query = query.AsNoTracking();

            return query;
        }

        public async Task<Author?> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking) 
                query = query.AsNoTracking();

            if (_cache.GetString($"{CacheKey}_{id}") is not null)
            {
                var cachedAuthor = _cache.GetString($"{CacheKey}_{id}");
                return JsonSerializer.Deserialize<Author>(cachedAuthor);
            }

            var author = await query.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));

            var serializedAuthor = JsonSerializer.Serialize(author);
            var options = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                .SetAbsoluteExpiration(DateTime.Now.AddHours(1));

            await _cache.SetStringAsync($"{CacheKey}_{id}", serializedAuthor, options);

            return author;
        }

        public async Task<dynamic> RemoveAsync(string id)
        {
            // cache'de varsa sil
            if (_cache.GetString($"{CacheKey}_{id}") is not null)
            {
                await _cache.RemoveAsync($"{CacheKey}_{id}");
            }

            await SaveChangesAsync();
            return true;
        }

        public async Task<dynamic> UpdateAsync(DtoAuthorUpdate authorUpdate)
        {
            var model = _Mapper.Map<Author>(authorUpdate);
            Table.Update(model);
            await SaveChangesAsync();
            return true;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _authorDbContext.SaveChangesAsync();
        }
    }
}
