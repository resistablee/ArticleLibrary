
namespace ArticleService.Application.Features.Article.Queries
{
    public class GetByIdArticleQueryResponse
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid AuthorID { get; set; }
        public Guid CategoryID { get; set; }
    }
}
