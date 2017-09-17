using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Instagram
{
    public interface IInstagramClient
    {
        Task<T> GetAsync<T>(string accessToken, string endpoint);
    }

    public class InstagramClient : IInstagramClient
    {
        private readonly HttpClient _httpClient;

        public InstagramClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.instagram.com/v1/")
            };
            _httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetAsync<T>(string accessToken, string endpoint)
        {
            var response = await _httpClient.GetAsync($"{endpoint}?access_token={accessToken}");
            
            if (!response.IsSuccessStatusCode)
                return default(T);

            var result = await response.Content.ReadAsStringAsync();
           
            return JsonConvert.DeserializeObject<T>(result);
            
        }

        //private static StringContent GetPayload(object data)
        //{
        //    var json = JsonConvert.SerializeObject(data);

        //    return new StringContent(json, Encoding.UTF8, "application/json");
        //}

    }
}
