using ArticleLibrary.Web.Models.DTO;

namespace ArticleLibrary.Web.Models.Interfaces
{
    public interface IArticleService
    {
        public Task<ArticleDTO> GetByIdAsync(string Id);
        public Task<List<ArticleDTO>> GetAllAsync();
        public Task AddAsync(ArticleAddDTO authorAdd);
        public Task UpdateAsync(ArticleUpdateDTO authorUpdate);
        public Task DeleteAsync(string Id);
    }
}
