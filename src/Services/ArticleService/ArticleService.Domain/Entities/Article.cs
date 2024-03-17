using ArticleService.Domain.Common.Models;

namespace ArticleService.Domain.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid AuthorID { get; set; }
        public Guid CategoryID { get; set; }
    }
}
