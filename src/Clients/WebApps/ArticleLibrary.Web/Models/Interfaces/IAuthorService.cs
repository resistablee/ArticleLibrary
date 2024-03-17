using ArticleLibrary.Web.Models.DTO;

namespace ArticleLibrary.Web.Models.Interfaces
{
    public interface IAuthorService
    {
        public Task<AuthorDTO> GetByIdAsync(string Id);
        public Task<List<AuthorDTO>> GetAllAsync();
        public Task AddAsync(AuthorAddDTO authorAdd);
        public Task UpdateAsync(AuthorUpdateDTO authorUpdate);
        public Task DeleteAsync(string Id);
    }
}
