using System.Net.Http.Headers;

namespace Customer.Services
{
    public class BaseServices
    {
        protected readonly HttpClient httpClient;
        public BaseServices(IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor)
        {
            httpClient = clientFactory.CreateClient();

            //var token = httpContextAccessor.HttpContext?.Session.GetString("JWToken");

            //if (!string.IsNullOrEmpty(token))
            //{
            //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //}
        }
    }
}
