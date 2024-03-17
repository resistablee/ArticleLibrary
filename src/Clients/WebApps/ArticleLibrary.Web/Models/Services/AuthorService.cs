using ArticleLibrary.Web.Models.DTO;
using ArticleLibrary.Web.Models.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace ArticleLibrary.Web.Models.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseUrl = "";

        public AuthorService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = new TimeSpan(0, 1, 0);

            BaseUrl = $"{configuration["GatewayUrl"]}/author";
        }

        public async Task AddAsync(AuthorAddDTO authorAdd)
        {
            string sendUrl = $"{BaseUrl}/add";
            await PostRequestAsync(sendUrl, authorAdd);
        }

        public async Task DeleteAsync(string Id)
        {
            string sendUrl = $"{BaseUrl}/delete/{Id}";
            await GetRequestAsync<dynamic>(sendUrl);
        }

        public async Task<List<AuthorDTO>> GetAllAsync()
        {
            string sendUrl = $"{BaseUrl}/getall";

            var result = await GetRequestAsync<List<AuthorDTO>>(sendUrl);
            return result;
        }

        public async Task<AuthorDTO> GetByIdAsync(string Id)
        {
            string sendUrl = $"{BaseUrl}/getbyid/{Id}";

            var result = await GetRequestAsync<AuthorDTO>(sendUrl);
            return result;
        }

        public async Task UpdateAsync(AuthorUpdateDTO authorUpdate)
        {
            string sendUrl = $"{BaseUrl}/update";
            await PostRequestAsync(sendUrl, authorUpdate);
        }

        private async Task<TEntity> GetRequestAsync<TEntity>(string sendUrl) where TEntity : class
        {
            HttpResponseMessage responseMessage = null;

            try
            {
                using (HttpRequestMessage requestMessage = new HttpRequestMessage())
                {
                    requestMessage.Method = HttpMethod.Get;
                    requestMessage.RequestUri = new Uri(sendUrl);
                    responseMessage = await _httpClient.SendAsync(requestMessage);
                }
            }
            catch (Exception)
            {
                return null;
            }

            if (!responseMessage.IsSuccessStatusCode)
                return null;

            string responseString = responseMessage.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<TEntity>(responseString);
            return result;
        }

        private async Task PostRequestAsync(string sendUrl, object model)
        {
            HttpResponseMessage responseMessage = null;

            try
            {
                using (HttpRequestMessage requestMessage = new HttpRequestMessage())
                {
                    string payload = JsonConvert.SerializeObject(model);

                    requestMessage.Method = HttpMethod.Post;
                    requestMessage.RequestUri = new Uri(sendUrl);
                    requestMessage.Content = new StringContent(payload, Encoding.UTF8, "application/json");
                    responseMessage = await _httpClient.SendAsync(requestMessage);
                }
            }
            catch (Exception)
            {
                return;
            }

            if (!responseMessage.IsSuccessStatusCode)
                return;

            string responseString = responseMessage.Content.ReadAsStringAsync().Result;

            if (responseMessage.IsSuccessStatusCode)
            {

            }
        }
    }
}
