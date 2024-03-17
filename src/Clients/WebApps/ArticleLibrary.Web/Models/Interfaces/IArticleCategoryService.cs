using ArticleLibrary.Web.Models.DTO;

namespace ArticleLibrary.Web.Models.Interfaces
{
    public interface IArticleCategoryService
    {
        public Task<ArticleCategoryDTO> GetByIdAsync(string Id);
        public Task<List<ArticleCategoryDTO>> GetAllAsync();
        public Task AddAsync(ArticleCategoryAddDTO articleCategoryAdd);
        public Task UpdateAsync(ArticleCategoryUpdateDTO articleUpdate);
        public Task DeleteAsync(string Id);
    }
}
