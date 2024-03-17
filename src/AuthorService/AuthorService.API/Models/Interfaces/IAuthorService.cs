using AuthorService.API.Models.DTO;
using AuthorService.API.Models.Entities;

namespace AuthorService.API.Models.Interfaces
{
    public interface IAuthorService
    {
        Task<dynamic> AddAsync(DtoAuthorAdd authorAdd);
        Task<dynamic> UpdateAsync(DtoAuthorUpdate authorUpdate);
        Task<dynamic> RemoveAsync(string id);
        Task<Author> GetByIdAsync(string id, bool tracking = true);
        IQueryable<Author> GetAll(bool tracking = true);
        Task<int> SaveChangesAsync();
    }
}
