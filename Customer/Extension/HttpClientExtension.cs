using Newtonsoft.Json;
using System.Text;

namespace Customer.Extension
{
    public static class HttpClientExtension
    {
        public static async Task<T?> GetAsJsonAsync<T>(this HttpClient httpClient, string url)
        {
            var response = await httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(content);
            return result;
        }


        public static async Task<T?> PostAsJsonAsync<Param, T>(this HttpClient httpClient, string url, Param param)
        {
            var objParam = JsonConvert.SerializeObject(param);
            var responcse = await httpClient.PostAsync(url, new StringContent(objParam, Encoding.UTF8, "application/json"));
            var content = await responcse.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(content);
            return result;

        }
    }
}
