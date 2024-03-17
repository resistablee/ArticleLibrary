namespace IdentityService.API.Models
{
    public class AppResponse<T>
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T? Result { get; set; }
    }
}
