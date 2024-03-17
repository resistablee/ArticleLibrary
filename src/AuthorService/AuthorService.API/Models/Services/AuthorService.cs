using AuthorService.API.Models.Context;
using AuthorService.API.Models.DTO;
using AuthorService.API.Models.Entities;
using AuthorService.API.Models.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorService.API.Models.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AuthorDbContext _authorDbContext;
        private readonly IMapper _Mapper;

        public AuthorService(AuthorDbContext authorDbContext, IMapper mapper)
        {
            _authorDbContext = authorDbContext;
            _Mapper = mapper;
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
            if (!tracking) query = query.AsNoTracking();
            return query;
        }

        public async Task<Author> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking) query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        }

        public async Task<dynamic> RemoveAsync(string id)
        {
            await RemoveAsync(id);
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
