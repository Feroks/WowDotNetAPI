using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WowDotNetAPI.Utilities
{
    public static class JsonUtility
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public static string GetJson(HttpRequestMessage req)
        {
            var task = GetJsonAsync(req);
            task.Wait();
            return task.Result;
        }

        public static async Task<string> GetJsonAsync(HttpRequestMessage req)
        {
            var res = await HttpClient.SendAsync(req);
            return await res.Content.ReadAsStringAsync();
        }

        public static T FromJson<T>(string url) where T : class
        {
            var req = new HttpRequestMessage(HttpMethod.Get, url);
            return JsonConvert.DeserializeObject<T>(GetJson(req));
        }

        public static T FromJsonString<T>(string str) where T : class
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}
