using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WowDotNetAPI.Utilities
{
    public static class JsonUtility
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public static async Task<string> GetJsonAsync(HttpRequestMessage req)
        {
            var res = await HttpClient.SendAsync(req);
            return await res.Content.ReadAsStringAsync();
        }

        public static async Task<T> FromJsonAsync<T>(string url) where T : class
        {
            var req = new HttpRequestMessage(HttpMethod.Get, url);
            return JsonConvert.DeserializeObject<T>(await GetJsonAsync(req));
        }

        public static T FromJsonString<T>(string str) where T : class
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}
