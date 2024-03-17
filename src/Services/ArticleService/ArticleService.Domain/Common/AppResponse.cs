
namespace ArticleService.Domain.Common
{
    public class AppResponse<T>
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T? Result { get; set; }
    }
}
